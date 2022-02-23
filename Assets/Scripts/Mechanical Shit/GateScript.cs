using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GateScript : MonoBehaviour {

    public int Mode;
    Output Output;

    //0 = buffer
    //1 = NOT
    //2 = AND
    // Update is called once per frame
    private void Start()
    {
        Output = gameObject.GetComponent<Output>();
    }
    void Update () {
        if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)) != null)
        {
            if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)).sprite != Resources.LoadAll<Sprite>("Machine Tiles/gates")[Mode])
            {
               Destroy(gameObject);
            }
            else
            {
                //buffer
                if (Mode == 0)
                {
                    if (Output.Inputs.Count > 0)
                    {
                        Output.Signal = Output.Inputs[0].Signal;
                    } else
                    {
                        Output.Signal = false;
                    }
                }
                //NOT
                else if (Mode == 1)
                {
                    if (Output.Inputs.Count > 0)
                    {
                        Output.Signal = !Output.Inputs[0].Signal;
                    }
                    else
                    {
                        Output.Signal = false;
                    }
                    }
                //AND
                else if (Mode == 2)
                {
                    if (Output.Inputs.Count > 1)
                    {
                        Output.Signal = true;
                        foreach (Output input in Output.Inputs)
                        {
                            if (input.Signal == false)
                            {
                                Output.Signal = false;
                                return;
                            }
                        }
                    }
                    else
                    {
                        Output.Signal = false;
                    }
                }
                //NAND
                else if (Mode == 3)
                {
                    if (Output.Inputs.Count > 1)
                    {
                        Output.Signal = false;
                        foreach (Output input in Output.Inputs)
                        {
                            if (input.Signal == false)
                            {
                                Output.Signal = true;
                                return;
                            }
                        }
                    }
                    else
                    {
                        Output.Signal = false;
                    }
                }
                //OR
                else if (Mode == 4)
                {
                    if (Output.Inputs.Count > 1)
                    {
                        Output.Signal = false;
                        foreach (Output input in Output.Inputs)
                        {
                            if (input.Signal == true)
                            {
                                Output.Signal = true;
                                return;
                            }
                        }
                    }
                    else
                    {
                        Output.Signal = false;
                    }
                }
                //NOR
                else if (Mode == 5)
                {
                    if (Output.Inputs.Count > 1)
                    {
                        Output.Signal = true;
                        foreach (Output input in Output.Inputs)
                        {
                            if (input.Signal == true)
                            {
                                Output.Signal = false;
                                return;
                            }
                        }
                    }
                    else
                    {
                        Output.Signal = false;
                    }
                }
                //XOR
                else if (Mode == 6)
                {
                    if (Output.Inputs.Count > 1)
                    {
                        Output.Signal = false;
                        int HighInputs = 0;
                        foreach (Output input in Output.Inputs)
                        {
                            if (input.Signal == true)
                            {
                                Output.Signal = true;
                                HighInputs += 1;
                            }
                        }
                        if (HighInputs >= Output.Inputs.Count)
                        {
                            Output.Signal = false;
                        }
                    }
                    else
                    {
                        Output.Signal = false;
                    }
                }
                //XNOR
                else if (Mode == 7)
                {
                    if (Output.Inputs.Count > 1)
                    {
                        Output.Signal = false;
                        int HighInputs = 0;
                        foreach (Output input in Output.Inputs)
                        {
                            if (input.Signal == true)
                            {
                                HighInputs += 1;
                            }
                        }
                        if (HighInputs == Output.Inputs.Count || HighInputs == 0)
                        {
                            Output.Signal = true;
                        }
                    }
                    else
                    {
                        Output.Signal = false;
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
            if (GameObject.Find("Machines").GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.transform.position)).sprite == Resources.LoadAll<Sprite>("Machine Tiles/gates")[Mode])
            {
                GameObject.Find("Machines").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.transform.position), null);
            }
        }
    }
}