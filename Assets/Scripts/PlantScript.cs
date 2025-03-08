using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantScript : Food
{
    public string TileName { get; set; }

    private void Start()
    {
        InvokeRepeating("Clean", 0, 30);
    }

    private void Update()
    {
        if (FindPlantsTilemap().GetTile(Vector3Int.FloorToInt(gameObject.transform.position)) != (Tile)(Resources.Load(TileName)))
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        FindPlantsTilemap().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), null);
    }

    void Clean()
    {
        FindSplattersTilemap().SetTile(Vector3Int.FloorToInt(gameObject.transform.position - new Vector3(0, 1, 0)), null);
    }

    private Tilemap FindPlantsTilemap()
    {
        return GameObject.Find("Grid").transform.GetChild(3).GetComponent<Tilemap>();
    }

    private Tilemap FindSplattersTilemap()
    {
        return GameObject.Find("Grid").transform.GetChild(2).GetComponent<Tilemap>();
    }
}
