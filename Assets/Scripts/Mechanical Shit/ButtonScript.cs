using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ButtonScript : MonoBehaviour {



    // Update is called once per frame
    private void Update()
    {
        if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)) != null)
        {
            if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)).sprite.texture != (Texture2D)Resources.Load("Machine Tiles/button"))
            {
                Destroy(gameObject);
            }
            else
            {
                if (Physics2D.BoxCast(gameObject.transform.position - new Vector3(0, 0.4f), new Vector2(0.4f, 0.2f), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Object Collision")))
                {
                    gameObject.GetComponent<Output>().Signal = true;
                    GameObject.Find("Machines").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), (Tile)Resources.Load("Machine Tiles/Tiles/buttondown"));
                }
                else
                {
                    gameObject.GetComponent<Output>().Signal = false;
                    GameObject.Find("Machines").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), (Tile)Resources.Load("Machine Tiles/Tiles/button"));
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)) != null)
        {
            if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)).sprite.texture == (Texture2D)Resources.Load("Machine Tiles/button"))
            {
                GameObject.Find("Machines").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), null);
            }
        }
    }

}
