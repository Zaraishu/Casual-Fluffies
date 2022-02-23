using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FanScript : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.GetComponent<Output>().Inputs.Count > 0)
        {
            if (gameObject.GetComponent<Output>().Inputs[0].Signal == true)
            {
                if (collision.gameObject.CompareTag("Fluffy"))
                {
                    FluffyScript Fluffy = collision.gameObject.GetComponent<FluffyScript>();
                    Fluffy.Needs.Health -= 25;
                    Fluffy.PlaySound("scree", true);
                    Fluffy.Message("SCREEEEEEEEEEE!", null, null, null);
                } else if (collision.gameObject.CompareTag("Corpse"))
                {
                    if (collision.gameObject.transform.parent != null)
                    {
                        GameObject child = collision.gameObject;
                        GameObject SpawnedBlood = Instantiate((GameObject)Resources.Load("Blood"));
                        SpawnedBlood.transform.position = child.transform.position;
                        child.transform.SetParent(null);
                        Destroy(child.transform.GetComponent<HingeJoint2D>());
                        GameObject Clip = Instantiate((GameObject)Resources.Load("Audio"));
                        Clip.transform.position = child.transform.position;
                        Clip.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("break");
                        Clip.GetComponent<AudioSource>().Play();
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)) != null)
        {
            if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)).sprite != Resources.LoadAll<Sprite>("Machine Tiles/fan")[0])
            {
                Destroy(gameObject);
            }
            else
            {
                if (gameObject.GetComponent<Output>().Inputs.Count > 0)
                {
                    if (gameObject.GetComponent<Output>().Inputs[0].Signal == true)
                    {
                        gameObject.GetComponent<Output>().Signal = true;
                        gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        RaycastHit2D[] Hits = Physics2D.CircleCastAll(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), 10, new Vector2(0, 0), 0);
                        foreach (RaycastHit2D hit in Hits)
                        {
                            if (hit.collider.gameObject.GetComponent<Rigidbody2D>())
                            {
                                Vector3 Difference = (hit.collider.gameObject.transform.position - gameObject.transform.position);
                                Ray2D Ray = new Ray2D(gameObject.transform.position, hit.collider.gameObject.transform.position - gameObject.transform.position);
                                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Ray.direction.x * (10 - Difference.magnitude), Ray.direction.y * 10 - Difference.magnitude));
                            }
                        }
                    }
                    else
                    {
                        gameObject.GetComponent<Output>().Signal = false;
                        gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    }
                }
                else
                {
                    gameObject.GetComponent<Output>().Signal = false;
                    gameObject.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        } else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)) != null)
        {
            if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)).sprite.texture == (Texture2D)Resources.Load("Machine Tiles/fan"))
            {
                GameObject.Find("Machines").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), null);
            }
        }
    }
}
