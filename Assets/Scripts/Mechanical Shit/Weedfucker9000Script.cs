using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Weedfucker9000Script : MonoBehaviour
{

    public static bool Active;

    // Use this for initialization
    void Start()
    {
        Active = true;
        foreach (GameObject plant in GameObject.FindObjectsOfType<GameObject>())
        {
            if (plant.name == "Plant(Clone)")
            {
                if (plant.transform.childCount > 0)
                {
                    Destroy(plant);
                }
            }
        }
    }

    void OnDestroy()
    {
        if (GameObject.Find("Machine Blocks").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)) != null)
        {
            if (GameObject.Find("Machine Blocks").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)).sprite.texture == (Texture2D)Resources.Load("Big Fucking Machines/weedfucker9000"))
            {
                GameObject.Find("Machine Blocks").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), null);
            }
        }
    }
}