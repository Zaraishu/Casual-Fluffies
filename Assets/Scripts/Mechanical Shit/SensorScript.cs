using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SensorScript : MonoBehaviour {

    public bool CheckVariables;

    public float Pregnancy;
    public float Hunger;
    public float SexDrive;
    public float Morality;

    public float Radius;


    public float Cannibal;

    public float Age;
    public int Sex;

    public int FluffLength;
    public float Size;

    public int Race;

    Output Output;

    private void Start()
    {
        Output = gameObject.GetComponent<Output>();
        Race = -1;
        FluffLength = -1;
        Size = 0.9f;
        Sex = -1;
    }

    // Update is called once per frame
    void Update () {
        if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)) != null)
        {
            if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)).sprite != Resources.Load<Sprite>("Machine Tiles/sensors"))
            {
                Destroy(gameObject);
            }
            RaycastHit2D[] Hit = Physics2D.CircleCastAll(gameObject.transform.position, Radius, new Vector2(0, 0), 0);
            Output.Signal = false;
            foreach (RaycastHit2D fluffy in Hit)
            {
                if (fluffy.collider.gameObject.CompareTag("Fluffy"))
                {
                    if (CheckVariables == true)
                    {
                        FluffyVariables Fluffy = fluffy.collider.gameObject.GetComponent<FluffyVariables>();
                        if (Pregnancy > 0)
                        {
                            if (Fluffy.Gestation >= Pregnancy)
                            {
                                Output.Signal = true;
                                return;
                            }
                        }

                        if (Hunger > 0)
                        {
                            if (Fluffy.Hunger >= Hunger)
                            {
                                Output.Signal = true;
                                return;
                            }
                        }

                        if (SexDrive > 0)
                        {
                            if (Fluffy.SexDrive >= SexDrive)
                            {
                                Output.Signal = true;
                                return;
                            }
                        }

                        if (Morality > 0)
                        {
                            if (Fluffy.Morality >= Morality)
                            {
                                Output.Signal = true;
                                return;
                            }
                        }

                        if (Cannibal > 0)
                        {
                            if (Fluffy.Cannibalism >= Cannibal)
                            {
                                Output.Signal = true;
                                return;
                            }
                        }

                        if (Age > 0)
                        {
                            if (Fluffy.Age >= Age)
                            {
                                Output.Signal = true;
                                return;
                            }
                        }

                        if (Sex > -1)
                        {
                            if (Fluffy.Sex == Sex)
                            {
                                Output.Signal = true;
                                return;
                            }
                        }
                        if (FluffLength > -1)
                        {
                            if (Fluffy.Hair == FluffLength)
                            {
                                Output.Signal = true;
                                return;
                            }
                        }
                        if (Size > 0.9f)
                        {
                            if (Fluffy.Size > Size)
                            {
                                Output.Signal = true;
                                return;
                            }
                        }

                        if (Race > -1)
                        {
                            if (Fluffy.Race == Race)
                            {
                                Output.Signal = true;
                                return;
                            }
                        }
                    }
                    else
                    {
                        Output.Signal = true;
                    }
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
            if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)).sprite.texture == (Texture2D)Resources.Load("Machine Tiles/sensors"))
            {
                GameObject.Find("Machines").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), null);
            }
        }
    }
}
