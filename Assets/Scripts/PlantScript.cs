using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantScript : MonoBehaviour {

    public string TileName;

    private void Start()
    {
        InvokeRepeating("Clean", 0, 30);
    }

    private void Update()
    {
        if (GameObject.Find("Plants").GetComponent<Tilemap>().GetTile(Vector3Int.FloorToInt(gameObject.transform.position)) != (Tile)(Resources.Load(TileName)))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void OnDestroy () {
        if (GameObject.Find("Plants"))
        {
            GameObject.Find("Plants").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), null);
        }
    }

    void Clean()
    {
        GameObject.Find("Splatters").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position - new Vector3(0, 1, 0)), null);
    }
}
