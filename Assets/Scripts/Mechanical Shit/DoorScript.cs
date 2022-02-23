using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorScript : MonoBehaviour {

    bool DoorState;

	// Use this for initialization
	void Start () {
        DoorState = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)) != null)
        {
            if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)).sprite.texture != (Texture2D)Resources.Load("Machine Tiles/door"))
            {
                Destroy(gameObject);
            }
            else
            {
                if (gameObject.GetComponent<Output>().Inputs.Count > 0)
                {
                    if (gameObject.GetComponent<Output>().Inputs[0].Signal == true)
                    {
                        if (DoorState == false)
                        {
                            StartCoroutine(OpenDoor());
                        }
                    }
                    else
                    {
                        if (DoorState == true)
                        {
                            StartCoroutine(CloseDoor());
                        }
                    }
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator OpenDoor()
    {
        GameObject.Find("Machines").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), (Tile)Resources.Load("Machine Tiles/Tiles/doorhalf"));
        yield return new WaitForSeconds(0.1f);
        GameObject.Find("Machines").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), (Tile)Resources.Load("Machine Tiles/Tiles/dooropen"));
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Output>().Signal = true;
        DoorState = true;
    }

    IEnumerator CloseDoor()
    {
        GameObject.Find("Machines").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), (Tile)Resources.Load("Machine Tiles/Tiles/doorhalf"));
        yield return new WaitForSeconds(0.1f);
        GameObject.Find("Machines").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), (Tile)Resources.Load("Machine Tiles/Tiles/doorclosed"));
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<Output>().Signal = false;
        DoorState = false;
    }

    void OnDestroy()
    {
        if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)) != null)
        {
            if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)).sprite.texture == (Texture2D)Resources.Load("Machine Tiles/door"))
            {
                GameObject.Find("Machines").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), null);
            }
        }
    }
}
