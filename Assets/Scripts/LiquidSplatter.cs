using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LiquidSplatter : MonoBehaviour {

    public string String;
    public string Effect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Find("Splatters").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(collision.contacts[0].point - new Vector2(0, 0.5f)), (Tile)Resources.Load(String));
        GameObject Particle = Instantiate((GameObject)Resources.Load(Effect));
        Particle.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }
}
