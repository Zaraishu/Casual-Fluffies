using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SwitchScript : MonoBehaviour {

    private void Update()
    {
        if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)) != null)
        {
            if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)).sprite.texture != (Texture2D)Resources.Load("Machine Tiles/switch"))
            {
                Destroy(gameObject);
            }
        } else
        {
            Destroy(gameObject);
        }
    }

    public void OnMouseDown()
    {
        if (GameObject.Find("Main Camera").GetComponent<PlayerControls>().Mode == 0)
        {
            if (gameObject.GetComponent<Output>().Signal == false)
            {
                gameObject.GetComponent<Output>().Signal = true;
                GameObject.Find("Machines").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), (Tile)Resources.Load("Machine Tiles/Tiles/switchon"));
            }
            else
            {
                gameObject.GetComponent<Output>().Signal = false;
                GameObject.Find("Machines").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), (Tile)Resources.Load("Machine Tiles/Tiles/switchoff"));
            }
        }
    }

    void OnDestroy()
    {
        if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)) != null)
        {
            if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)).sprite.texture == (Texture2D)Resources.Load("Machine Tiles/switch"))
            {
                GameObject.Find("Machines").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), null);
            }
        }
    }
}
