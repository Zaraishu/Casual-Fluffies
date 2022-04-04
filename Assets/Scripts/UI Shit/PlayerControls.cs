using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class PlayerControls : MonoBehaviour
{

    GameObject HeldObject;

    int FoodValue;
    public int Mode;
    GameObject Data;
    public Vector3 ScreenBounds;
    float TotalMood;
    int FluffyNumber;
    GameObject SelectedFluffy;
    bool Editing;
    public bool Building;
    public bool Mechanic;
    public bool Feeding;
    public bool Spawning;
    bool Storing;

    public float Money;

    public FoodPreset Food;

    public string BuildTile;
    public string Layer;
    public string BuildSprite;
    public string Prefab;
    bool Placing;

    public GameObject Selector;

    public GameObject SelectedObject;

    public void GainMoney(float GainedMoney)
    {
        Money += Mathf.RoundToInt(GainedMoney * 100) / 100;
        transform.Find("Weird Technical Shit").GetChild(0).GetChild(0).GetComponent<Text>().text = "$" + Money.ToString();
    }

    #region Setting a Bunch of Shit

    public void SetMode(int Number)
    {
        Mode = Number;
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = (Sprite)Resources.LoadAll("tray")[Number + 1];
        if (Mode == 0)
        {
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Click and drag to pick up fluffies, food bowls, and other objects. Some static objects can be interacted with as well.";
            gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StopAllCoroutines();
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StartCoroutine("Fade");
        }
        else if (Mode == 1)
        {
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Use the feeding menu to fill bowls with different foods.";
            gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StopAllCoroutines();
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StartCoroutine("Fade");
        }
        else if (Mode == 2)
        {
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Click and drag over spills, poop, and other messes to clean them up.";
            gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StopAllCoroutines();
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StartCoroutine("Fade");
        }
        else if (Mode == 3)
        {
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Click on fluffies' body parts to cut them off.";
            gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StopAllCoroutines();
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StartCoroutine("Fade");
        }
        else if (Mode == 4)
        {
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Click and drag over dead fluffies to remove them.";
            gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StopAllCoroutines();
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StartCoroutine("Fade");
        }
        else if (Mode == 5)
        {
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Click on fluffies to view their age and edit their names and descriptions, and press escape to close the editing window. Some other objects have statistics that can be viewed and edited as well.";
            gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StopAllCoroutines();
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StartCoroutine("Fade");
        }
        else if (Mode == 6)
        {
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Use the building menu to build structures and machines.";
            gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StopAllCoroutines();
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StartCoroutine("Fade");
        }
        else if (Mode == 7)
        {
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Use the inventory menu to place items.";
            gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StopAllCoroutines();
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StartCoroutine("Fade");
        }
        else if (Mode == 8)
        {
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Use the Fluffy Business menu to perform various fluffy-related tasks.";
            gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StopAllCoroutines();
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StartCoroutine("Fade");
        }
        gameObject.transform.GetChild(7).gameObject.SetActive(false);
        gameObject.transform.GetChild(5).gameObject.SetActive(false);
        gameObject.transform.GetChild(8).gameObject.SetActive(false);
        gameObject.transform.GetChild(10).gameObject.SetActive(false);
        if (Mode == 1)
        {
            gameObject.transform.GetChild(8).gameObject.SetActive(true);
            FoodButton Tile = gameObject.transform.GetChild(8).GetChild(0).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetComponent<FoodButton>();
            Tile.SetSprite();
        }
        else if (Mode == 6)
        {
            gameObject.transform.GetChild(5).gameObject.SetActive(true);
            TileButton Tile = gameObject.transform.GetChild(5).GetChild(0).GetChild(4).GetChild(0).GetChild(0).GetChild(0).GetComponent<TileButton>();
            Tile.SetSprite();
        }
        else if (Mode == 7)
        {
            gameObject.transform.GetChild(7).gameObject.SetActive(true);
            TileButton Tile = gameObject.transform.GetChild(7).GetChild(0).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetComponent<TileButton>();
            Tile.SetSprite();
        } else if (Mode == 8)
        {
            gameObject.transform.GetChild(10).gameObject.SetActive(true);

            transform.GetChild(10).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = "Select a fluffy and click the Spawn button to place it in the world.";
            transform.GetChild(10).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(10).GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
            transform.GetChild(10).GetChild(0).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
        }
    }

    public void SetDescription(string Description)
    {
        SelectedFluffy.GetComponent<FluffyVariables>().Description = Description;
    }

    public void SetName(string Name)
    {
        string oldName = SelectedFluffy.GetComponent<FluffyVariables>().Name;
        SelectedFluffy.GetComponent<FluffyVariables>().Name = Name;
        if (oldName != Name && Name != "")
        {
            SelectedFluffy.GetComponent<FluffyScript>().PlaySound("happytalk", true);
            SelectedFluffy.GetComponent<FluffyScript>().Message("fwuffy nyu namesie is <name>? <name> wubs nyu namesie!", null, null, null);
        }
    }

    public void SetBuilding()
    {
        gameObject.transform.GetChild(5).GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(5).GetChild(1).gameObject.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Building = true;
    }

    public void SetPlacing()
    {
        gameObject.transform.GetChild(7).GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(7).GetChild(1).gameObject.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Placing = true;
    }

    public void SetFeeding()
    {
        gameObject.transform.GetChild(8).GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(8).GetChild(1).gameObject.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Feeding = true;
    }

    public void SetMechanic()
    {
        gameObject.transform.GetChild(5).GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(5).GetChild(2).gameObject.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Mechanic = true;
        foreach (Output output in FindObjectsOfType<Output>())
        {
            foreach (Output input in output.Inputs)
            {
                GameObject Line = Instantiate((GameObject)Resources.Load("Machine Tiles/Prefabs/Connection Line"));
                Line.GetComponent<LineRenderer>().SetPosition(0, input.gameObject.transform.position);
                Line.GetComponent<LineRenderer>().SetPosition(1, output.gameObject.transform.position);
                Line.transform.parent = input.gameObject.transform;
            }
        }
    }

    public void SetSpawning()
    {
        GameObject.Find("Fluffy Business Menu").GetComponent<FluffyBusinessScript>().StartCoroutine("SetSpawning", gameObject);
    }

    public void SetStoring()
    {
        gameObject.transform.GetChild(10).GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(10).GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(10).GetChild(2).gameObject.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Storing = true;
    }

    #endregion

    // Use this for initialization
    void Start()
    {
        Cursor.SetCursor(Resources.Load("mouse") as Texture2D, new Vector2(0, 0), CursorMode.Auto);
        Screen.fullScreen = false;
        if (Screen.currentResolution.height < 768)
        {
            Screen.SetResolution(512, 384, false);
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Press space to spawn a random fluffy. Instructions for various modes of interaction can be seen by clicking their icons on the tray. Have fun! \n \nNOTE: Your screen resolution is too small for the full-sized window, so the game has launched in Potato Mode. That's why it looks like shit.";
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StartCoroutine("Fade");
        }
        else {
            Screen.SetResolution(1024, 768, false);
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Press space to spawn a random fluffy. Instructions for various modes of interaction can be seen by clicking their icons on the tray. Have fun!";
            gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextScript>().StartCoroutine("Fade");
        }
        Data = gameObject.transform.GetChild(2).gameObject;
        Selector = GameObject.Find("Selector");
    }
    // Update is called once per frame
    void Update()
    {
        //set screen size
        ScreenBounds = gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)) - gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0, 0, 0));
        //set ambient mood
        RaycastHit2D[] Fluffies;
        Fluffies = Physics2D.BoxCastAll(gameObject.transform.position, new Vector2(ScreenBounds.x, ScreenBounds.y), 0, new Vector2(0, 0));
        TotalMood = 0;
        FluffyNumber = 0;
        foreach (RaycastHit2D Fluff in Fluffies)
        {
            if (Fluff.collider.gameObject.CompareTag("Fluffy"))
            {
                TotalMood += Fluff.collider.gameObject.GetComponent<FluffyScript>().Mood;
                FluffyNumber += 1;
            }
        }
        if (FluffyNumber > 0)
        {
            float Total = (TotalMood / FluffyNumber) / 100;
            gameObject.GetComponent<AudioSource>().pitch = 0.25f + (Total * 0.75f);
        }
        //menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Feeding == true)
            {
                gameObject.transform.GetChild(8).GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(8).GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Feeding = false;
            }
            else if (Editing == true)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(6).gameObject.SetActive(false);
                Editing = false;
            }
            else if (Building == true)
            {
                gameObject.transform.GetChild(5).GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Building = false;
            }
            else if (Mechanic == true)
            {
                gameObject.transform.GetChild(5).GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(5).GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                SelectedObject = null;
                Selector.GetComponent<SpriteRenderer>().enabled = false;
                foreach (LineRenderer line in GameObject.FindObjectsOfType<LineRenderer>())
                {
                    Destroy(line.gameObject);
                }
                Mechanic = false;
            }
            else if (Placing == true)
            {
                gameObject.transform.GetChild(7).GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(7).GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Placing = false;
            }
            else if (Spawning == true)
            {
                gameObject.transform.GetChild(10).GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(10).GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(10).GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Spawning = false;
            } else if (Storing == true)
            {
                gameObject.transform.GetChild(10).GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(10).GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(10).GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Storing = false;
            }
            else
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.transform.GetChild(3).gameObject.SetActive(false);
                Time.timeScale = 0;
            }
        }
        if (Editing == false)
        {

            //spawning controls
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject Thing = Instantiate((GameObject)Resources.Load("Fluffy"));
                Thing.transform.position = gameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
                Thing.GetComponent<FluffyScript>().SetRace(Random.Range(0, 3), Random.Range(0, 3));
                Thing.GetComponent<FluffyScript>().SetAlicorn(Random.Range(0, 2) == 0, Random.Range(0, 2) == 0);
                Thing.GetComponent<FluffyScript>().SetBase(Random.ColorHSV(), Random.ColorHSV());
                Thing.GetComponent<FluffyScript>().SetMane(Random.ColorHSV(), Random.ColorHSV());
                Thing.GetComponent<FluffyScript>().SetEyes(Random.ColorHSV(), Random.ColorHSV());
                Thing.GetComponent<FluffyScript>().SetHair(Random.Range(0, 3), Random.Range(0, 3));
                Thing.GetComponent<FluffyScript>().SetSize(Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f));
                Thing.GetComponent<FluffyVariables>().Age = 600;
                if (Thing.GetComponent<FluffyVariables>().AlicornGenes[0] == true && Thing.GetComponent<FluffyVariables>().AlicornGenes[1] == true)
                {
                    bool HasPegasus = false;
                    bool HasUnicorn = false;
                    if (Thing.GetComponent<FluffyVariables>().RaceGenes[0] == 1 || Thing.GetComponent<FluffyVariables>().RaceGenes[1] == 1)
                    {
                        HasPegasus = true;
                    }
                    if (Thing.GetComponent<FluffyVariables>().RaceGenes[0] == 2 || Thing.GetComponent<FluffyVariables>().RaceGenes[1] == 2)
                    {
                        HasUnicorn = true;
                    }
                    if (HasPegasus == false || HasUnicorn == false)
                    {
                        Thing.GetComponent<FluffyVariables>().AlicornGenes[Random.Range(0, 2)] = false;
                    }
                }
            }

            // NEW FUNCTION: Destroys a game object under the cursor by pressing the x key
            if (Input.GetKeyDown(KeyCode.X))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector2(0, 0));
                if (hit)
                {
                    Destroy(hit.collider.gameObject);
                }
            }

            //interaction
            if (Input.GetMouseButtonDown(0))
            {
                if (Spawning == true)
                {
                    GameObject.Find("Fluffy Business Menu").GetComponent<FluffyBusinessScript>().SpawnFluffy(gameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                }
                else
                {
                    RaycastHit2D[] Hits = Physics2D.RaycastAll(gameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), new Vector2(0, 0), 0, LayerMask.GetMask("Interactable"));
                    foreach (RaycastHit2D Hit in Hits)
                    {
                        if (Hit.collider != null)
                        {
                            if (Mechanic == true)
                            {
                                if (Hit.collider.gameObject.CompareTag("Machine"))
                                    if (SelectedObject != Hit.collider.gameObject.transform.parent.gameObject)
                                    {
                                        if (SelectedObject == null)
                                        {
                                            SelectedObject = Hit.collider.gameObject.transform.parent.gameObject;
                                            Selector.transform.position = SelectedObject.transform.position;
                                            Selector.GetComponent<SpriteRenderer>().enabled = true;
                                        }
                                        else
                                        {
                                            if (!Hit.collider.gameObject.transform.parent.GetComponent<Output>().Inputs.Contains(SelectedObject.GetComponent<Output>()))
                                            {
                                                if (Hit.collider.gameObject.transform.parent.GetComponent<Output>().HasInput == true)
                                                {
                                                    Hit.collider.gameObject.transform.parent.GetComponent<Output>().Inputs.Add(SelectedObject.GetComponent<Output>());
                                                    GameObject Line = Instantiate((GameObject)Resources.Load("Machine Tiles/Prefabs/Connection Line"));
                                                    Line.GetComponent<LineRenderer>().SetPosition(0, SelectedObject.transform.position);
                                                    Line.GetComponent<LineRenderer>().SetPosition(1, Hit.collider.gameObject.transform.position);
                                                    Line.transform.parent = SelectedObject.transform;
                                                }
                                            }
                                            else
                                            {
                                                Hit.collider.gameObject.transform.parent.GetComponent<Output>().Inputs.Remove(SelectedObject.GetComponent<Output>());
                                                foreach (Transform child in SelectedObject.transform)
                                                {
                                                    if (child.GetComponent<LineRenderer>())
                                                    {
                                                        if (child.GetComponent<LineRenderer>().GetPosition(1) == Hit.collider.gameObject.transform.parent.position)
                                                        {
                                                            Destroy(child.gameObject);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        SelectedObject = null;
                                        Selector.GetComponent<SpriteRenderer>().enabled = false;
                                    }
                                break;
                            }
                            if (Mode == 0)
                            {
                                if (Hit.collider.gameObject.name == "Pickup")
                                {
                                    HeldObject = Hit.collider.gameObject.transform.parent.gameObject;
                                    HeldObject.AddComponent<TargetJoint2D>();
                                    HeldObject.GetComponent<TargetJoint2D>().anchor = new Vector2(HeldObject.GetComponent<Collider2D>().offset.x, HeldObject.GetComponent<Collider2D>().offset.y);
                                    if (HeldObject.CompareTag("Fluffy"))
                                    {
                                        if (HeldObject.GetComponent<FluffyVariables>().Age > 200)
                                        {
                                            HeldObject.GetComponent<FluffyScript>().FluffyEvent(0, 0, null, 0, "Hold", 2, 0, true);

                                        }
                                        else
                                        {
                                            HeldObject.GetComponent<FluffyScript>().FluffyEvent(0, 0, null, 0, "Hold", 2, 8, true);
                                        }
                                        HeldObject.GetComponent<FluffyScript>().FrozenState = true;
                                        HeldObject.GetComponent<FluffyScript>().Held = true;
                                    }
                                    break;
                                }
                            }
                            else if (Hit.collider.gameObject.name == "Dismember")
                            {
                                if (Mode == 3)
                                {
                                    GameObject SpawnedBlood = Instantiate((GameObject)Resources.Load("Blood"));
                                    SpawnedBlood.transform.position = Hit.collider.gameObject.transform.position;
                                    // WHAT??? Why would you check the name of a limb GameObject to lose it?
                                    // YOU ALREADY HAVE THE OBJECT, YOU DON'T NEED TO CALL ANOTHER FUNCTION FOR EVERY LIMB!
                                    if (Hit.collider.gameObject.transform.parent.parent.name == "tail_000")
                                    {
                                        Hit.collider.gameObject.transform.parent.parent.parent.parent.parent.GetComponent<FluffyScript>().LoseLimb(0);
                                    }
                                    else if (Hit.collider.gameObject.transform.parent.parent.name == "rearleg_r")
                                    {
                                        Hit.collider.gameObject.transform.parent.parent.parent.parent.parent.GetComponent<FluffyScript>().LoseLimb(1);
                                    }
                                    else if (Hit.collider.gameObject.transform.parent.parent.name == "rearleg_r_001")
                                    {
                                        Hit.collider.gameObject.transform.parent.parent.parent.parent.parent.GetComponent<FluffyScript>().LoseLimb(2);
                                    }
                                    else if (Hit.collider.gameObject.transform.parent.parent.name == "frontleg_r")
                                    {
                                        Hit.collider.gameObject.transform.parent.parent.parent.parent.parent.GetComponent<FluffyScript>().LoseLimb(3);
                                    }
                                    else if (Hit.collider.gameObject.transform.parent.parent.name == "frontleg_r_001")
                                    {
                                        Hit.collider.gameObject.transform.parent.parent.parent.parent.parent.GetComponent<FluffyScript>().LoseLimb(4);
                                    }
                                    else if (Hit.collider.gameObject.transform.parent.parent.name == "ear_r")
                                    {
                                        Hit.collider.gameObject.transform.parent.parent.parent.parent.parent.parent.GetComponent<FluffyScript>().LoseLimb(6);
                                    }
                                    else if (Hit.collider.gameObject.transform.parent.parent.name == "ear_r_001")
                                    {
                                        Hit.collider.gameObject.transform.parent.parent.parent.parent.parent.parent.GetComponent<FluffyScript>().LoseLimb(7);
                                    }
                                    else if (Hit.collider.gameObject.transform.parent.name == "Cutie Mark")
                                    {
                                        Hit.collider.gameObject.transform.parent.parent.parent.parent.GetComponent<FluffyScript>().LoseLimb(8);
                                    }
                                    else if (Hit.collider.gameObject.transform.parent.name == "Base")
                                    {
                                        if (Hit.collider.gameObject.transform.parent.parent.name == "bone_005")
                                        {
                                            Hit.collider.gameObject.transform.parent.parent.parent.parent.GetComponent<FluffyScript>().LoseLimb(9);
                                        }
                                        else if (Hit.collider.gameObject.transform.parent.parent.name == "head")
                                        {
                                            Hit.collider.gameObject.transform.parent.parent.parent.parent.parent.GetComponent<FluffyScript>().LoseLimb(10);
                                        }
                                    }
                                    else if (Hit.collider.gameObject.transform.parent.name == "Eye")
                                    {
                                        Hit.collider.gameObject.transform.parent.parent.parent.parent.parent.GetComponent<FluffyScript>().LoseLimb(11);
                                    }
                                    else
                                    {
                                        Hit.collider.gameObject.transform.parent.SetParent(null);
                                        Destroy(Hit.collider.gameObject.transform.parent.GetComponent<HingeJoint2D>());
                                        Destroy(Hit.collider.gameObject.gameObject);
                                    }
                                    GameObject Clip = Instantiate((GameObject)Resources.Load("Audio"));
                                    Clip.transform.position = Hit.collider.gameObject.transform.position;
                                    Clip.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("break");
                                    Clip.GetComponent<AudioSource>().Play();
                                    break;
                                }
                            }
                            // This seems to open the Fluffy Stats Panel
                            else if (Hit.collider.gameObject.transform.parent.CompareTag("Fluffy"))
                            {
                                if (Mode == 5)
                                {
                                    Editing = true;
                                    SelectedFluffy = Hit.collider.gameObject.transform.parent.gameObject;
                                    Data.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<InputField>().text = SelectedFluffy.GetComponent<FluffyVariables>().Name;
                                    if (SelectedFluffy.GetComponent<FluffyVariables>().Sex == 0)
                                    {
                                        Data.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Sex: Male";
                                    }
                                    else
                                    {
                                        Data.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Sex: Female";
                                    }
                                    Data.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "Age: " + Mathf.FloorToInt(SelectedFluffy.GetComponent<FluffyVariables>().Age);
                                    Data.transform.GetChild(0).GetChild(3).GetComponent<InputField>().text = SelectedFluffy.GetComponent<FluffyVariables>().Description;
                                    Data.SetActive(true);
                                    gameObject.transform.GetChild(0).gameObject.SetActive(false);
                                    break;
                                } else if (Storing)
                                {
                                    GameObject Button = Instantiate((GameObject)Resources.Load("Spawn Button"));
                                    Button.transform.SetParent(gameObject.transform.GetChild(10).GetChild(0).GetChild(2).GetChild(0).GetChild(0));
                                    FluffyVariables Fluffy = Hit.collider.gameObject.transform.parent.GetComponent<FluffyVariables>();
                                    System.Type type = Fluffy.GetType();
                                    FluffyVariables copy = Button.GetComponent<FluffyVariables>();
                                    // Copied fields can be restricted with BindingFlags
                                    System.Reflection.FieldInfo[] fields = type.GetFields();
                                    foreach (System.Reflection.FieldInfo field in fields)
                                    {
                                        field.SetValue(copy, field.GetValue(Fluffy));
                                    }
                                    Destroy(Fluffy.gameObject);
                                }
                            }
                            else if (Hit.collider.gameObject.transform.parent.CompareTag("Sensor"))
                            {
                                if (Mode == 5)
                                {
                                    Editing = true;
                                    GameObject Sensor = gameObject.transform.GetChild(6).gameObject;
                                    Sensor.GetComponent<SensorMenu>().SelectedSensor = Hit.collider.gameObject.transform.parent.gameObject;
                                    GameObject Menu = Sensor.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).gameObject;
                                    Sensor.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Toggle>().isOn = Sensor.GetComponent<SensorMenu>().SelectedSensor.GetComponent<SensorScript>().CheckVariables;
                                    Menu.transform.GetChild(0).GetComponent<Slider>().value = Sensor.GetComponent<SensorMenu>().SelectedSensor.GetComponent<SensorScript>().Age;
                                    Menu.transform.GetChild(1).GetComponent<Slider>().value = Sensor.GetComponent<SensorMenu>().SelectedSensor.GetComponent<SensorScript>().Hunger;
                                    Menu.transform.GetChild(2).GetComponent<Slider>().value = Sensor.GetComponent<SensorMenu>().SelectedSensor.GetComponent<SensorScript>().SexDrive;
                                    Menu.transform.GetChild(3).GetComponent<Slider>().value = Sensor.GetComponent<SensorMenu>().SelectedSensor.GetComponent<SensorScript>().Morality;
                                    Menu.transform.GetChild(4).GetComponent<Slider>().value = Sensor.GetComponent<SensorMenu>().SelectedSensor.GetComponent<SensorScript>().Pregnancy;
                                    Menu.transform.GetChild(5).GetComponent<Slider>().value = Sensor.GetComponent<SensorMenu>().SelectedSensor.GetComponent<SensorScript>().Sex;
                                    Menu.transform.GetChild(6).GetComponent<Slider>().value = Sensor.GetComponent<SensorMenu>().SelectedSensor.GetComponent<SensorScript>().Cannibal;
                                    Menu.transform.GetChild(7).GetComponent<Slider>().value = Sensor.GetComponent<SensorMenu>().SelectedSensor.GetComponent<SensorScript>().FluffLength;
                                    Menu.transform.GetChild(8).GetComponent<Slider>().value = Sensor.GetComponent<SensorMenu>().SelectedSensor.GetComponent<SensorScript>().Size;
                                    Menu.transform.GetChild(9).GetComponent<Slider>().value = Sensor.GetComponent<SensorMenu>().SelectedSensor.GetComponent<SensorScript>().Race;
                                    Sensor.SetActive(true);
                                    gameObject.transform.GetChild(0).gameObject.SetActive(false);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (HeldObject)
            {
                HeldObject.GetComponent<TargetJoint2D>().target = gameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10) + new Vector3(0, 0, HeldObject.transform.position.z));
            }
            //drop
            if (Input.GetMouseButtonUp(0))
            {
                if (HeldObject)
                {
                    foreach (Component child in HeldObject.GetComponents<TargetJoint2D>())
                        Destroy(child);
                    if (HeldObject.CompareTag("Fluffy"))
                    {
                        if (HeldObject.GetComponent<FluffyScript>().Falling == true)
                        {
                            HeldObject.GetComponent<FluffyScript>().FluffyEvent(0, 0, null, 0, "Fall", 2, 10, true);
                        }
                        else
                        {
                            HeldObject.GetComponent<FluffyScript>().FrozenState = false;
                            if (HeldObject.GetComponent<FluffyVariables>().Age > 200)
                            {
                                HeldObject.GetComponent<FluffyScript>().FluffyEvent(0, 0, null, 0, "Stand", 2, 0, true);
                            }
                            else
                            {
                                HeldObject.GetComponent<FluffyScript>().FluffyEvent(0, 0, null, 0, "Lay", 2, 8, true);
                            }
                        }
                        HeldObject.GetComponent<FluffyScript>().Held = false;
                    }
                }
                HeldObject = null;
            }
            //continuous interaction
            if (Building == true)
            {
                if (Input.GetMouseButton(0))
                {
                    if (GameObject.Find(Layer).GetComponent<Tilemap>().GetTile(Vector3Int.FloorToInt(gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)))) != (Tile)Resources.Load(BuildTile))
                    {
                        GameObject.Find(Layer).GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10))), (Tile)Resources.Load(BuildTile));
                        if (Layer == "Machines")
                        {
                            GameObject.Find("Tilemap").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10))), null);
                        }
                        else if (Layer == "Tilemap")
                        {
                            GameObject.Find("Machines").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10))), null);
                        }
                        if (Layer == "Machines" || Layer == "Tilemap")
                        {
                            GameObject.Find("Plants").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10))), null);
                            GameObject.Find("Plants").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10))) + new Vector3Int(0, 1, 0), null);
                        }
                        GameObject Clip = Instantiate((GameObject)Resources.Load("Audio"));
                        Clip.transform.position = gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
                        Clip.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("build");
                        Clip.GetComponent<AudioSource>().Play();
                        GameObject Emitter = Instantiate((GameObject)Resources.Load("Build Particle"));
                        Vector3 Position = gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                        Emitter.transform.position = new Vector3(Mathf.FloorToInt(Position.x) + 0.5f, Mathf.FloorToInt(Position.y) + 0.5f, 0);
                        var Shape = Emitter.GetComponent<ParticleSystem>().shape;
                        Shape.texture = Resources.Load<Texture2D>(BuildSprite);
                        if (!string.IsNullOrEmpty(Prefab))
                        {
                            GameObject Object = Instantiate((GameObject)Resources.Load(Prefab));
                            Object.transform.position = new Vector3(Mathf.FloorToInt(Position.x) + 0.5f, Mathf.FloorToInt(Position.y) + 0.5f, 0);
                        }
                    }
                }
                else if (Input.GetMouseButton(1))
                {
                    if (GameObject.Find(Layer).GetComponent<Tilemap>().GetTile(Vector3Int.FloorToInt(gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)))) != null)
                    {
                        GameObject Emitter = Instantiate((GameObject)Resources.Load("Build Particle"));
                        Vector3 Position = gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                        Emitter.transform.position = new Vector3(Mathf.FloorToInt(Position.x) + 0.5f, Mathf.FloorToInt(Position.y) + 0.5f, 0);
                        var Shape = Emitter.GetComponent<ParticleSystem>().shape;
                        Shape.texture = GameObject.Find(Layer).GetComponent<Tilemap>().GetTile<Tile>(Vector3Int.FloorToInt(gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)))).sprite.texture;
                        GameObject.Find(Layer).GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10))), null);
                        GameObject.Find("Splatters").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10))), null);
                        if (Layer == "Machines" || Layer == "Tilemap")
                        {
                            GameObject.Find("Plants").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10))), null);
                            GameObject.Find("Plants").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10))) + new Vector3Int(0, 1, 0), null);
                        }
                        GameObject Clip = Instantiate((GameObject)Resources.Load("Audio"));
                        Clip.transform.position = gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
                        Clip.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("erase");
                        Clip.GetComponent<AudioSource>().Play();
                    }
                }
            }
            else if (Placing == true)
            {
                if (Input.GetMouseButtonDown(0))
                {

                    GameObject Thing = Instantiate((GameObject)Resources.Load(Prefab));
                    Thing.transform.position = gameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
                    GameObject Clip = Instantiate((GameObject)Resources.Load("Audio"));
                    Clip.transform.position = gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
                    Clip.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("build");
                    Clip.GetComponent<AudioSource>().Play();
                    GameObject Emitter = Instantiate((GameObject)Resources.Load("Build Particle"));
                    Vector3 Position = gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                    Emitter.transform.position = new Vector3(Position.x, Position.y, 0);
                    var Shape = Emitter.GetComponent<ParticleSystem>().shape;
                    Shape.texture = Resources.Load<Texture2D>(BuildSprite);
                }
                else if (Input.GetMouseButton(1))
                {
                    RaycastHit2D[] Hit;
                    Hit = Physics2D.RaycastAll(gameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), new Vector2(0, 0), 0, LayerMask.GetMask("Interactable"));
                    foreach (RaycastHit2D hit in Hit)
                    {
                        if (hit.collider != null)
                        {
                            foreach (Transform child in hit.collider.gameObject.transform.parent)
                            {
                                if (child.name == "Remove")
                                {
                                    GameObject Emitter = Instantiate((GameObject)Resources.Load("Build Particle"));
                                    Emitter.transform.position = child.position;
                                    var Shape = Emitter.GetComponent<ParticleSystem>().shape;
                                    Shape.texture = child.parent.GetComponent<SpriteRenderer>().sprite.texture;
                                    GameObject Clip = Instantiate((GameObject)Resources.Load("Audio"));
                                    Clip.transform.position = gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(child.position.x, child.position.y, -10));
                                    Clip.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("erase");
                                    Clip.GetComponent<AudioSource>().Play();
                                    Destroy(child.parent.gameObject);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    if (Mode == 2)
                    {
                        GameObject.Find("Splatters").GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10))), null);
                    }
                    else
                    {
                        RaycastHit2D[] Hit;
                        Hit = Physics2D.RaycastAll(gameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), new Vector2(0, 0), 0, LayerMask.GetMask("Interactable"));
                        foreach (RaycastHit2D hit in Hit)
                        {
                            if (hit.collider != null)
                            {
                                foreach (Transform child in hit.collider.gameObject.transform.parent)
                                {
                                    if (child.name == "Fill")
                                    {
                                        if (Feeding)
                                        {
                                            GameObject Bowl = child.parent.gameObject;
                                            if (Bowl.GetComponent<FoodScript>().Uses < 5)
                                            {
                                                Bowl.GetComponent<FoodScript>().Uses = Bowl.GetComponent<FoodScript>().MaxUses;
                                                GameObject Clip = Instantiate((GameObject)Resources.Load("Audio"));
                                                Clip.transform.position = Bowl.transform.position;
                                                Clip.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("build");
                                                Clip.GetComponent<AudioSource>().Play();
                                                GameObject Emitter = Instantiate((GameObject)Resources.Load("Build Particle"));
                                                Vector3 Position = Bowl.transform.position;
                                                Emitter.transform.position = Position;
                                                var Shape = Emitter.GetComponent<ParticleSystem>().shape;
                                                Shape.texture = Resources.Load<Texture2D>(Food.Sprite);
                                                foreach (Transform food in Bowl.transform)
                                                {
                                                    if (food.name == "Food")
                                                    {
                                                        food.gameObject.SetActive(true);
                                                        food.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Food.Sprite);
                                                    }
                                                }
                                                Bowl.GetComponent<FoodScript>().Hunger = Food.Hunger;
                                                Bowl.GetComponent<FoodScript>().Message = Food.Message;
                                                Bowl.GetComponent<FoodScript>().CannibalMessage = Food.CannibalMessage;
                                                Bowl.tag = Food.Tag;
                                                foreach (Transform effect in Bowl.transform)
                                                {
                                                    if (effect.name == "Effects")
                                                    {
                                                        Destroy(effect.gameObject);
                                                    }
                                                }
                                                if (Food.HasEffect)
                                                {
                                                    GameObject EffectObject = new GameObject();
                                                    EffectObject.transform.parent = Bowl.transform;
                                                    EffectObject.AddComponent<EffectScript>();
                                                    EffectScript Effect = EffectObject.GetComponent<EffectScript>();
                                                    Effect.Sound = Food.Sound;
                                                    Effect.Message = Food.EffectMessage;
                                                    Effect.Bleed = Food.Bleed;
                                                    Effect.Poop = Food.Poop;
                                                    Effect.Pose = Food.Pose;
                                                    Effect.Face = Food.Face;
                                                    Effect.Poison = Food.Poison;
                                                    Effect.Duration = Food.Duration;
                                                    Effect.PoseTime = Food.PoseTime;
                                                    Effect.Interval = Food.Interval;
                                                    Effect.MoodValue = Food.MoodValue;
                                                    Effect.Vomit = Food.Vomit;
                                                    EffectObject.SetActive(false);
                                                    EffectObject.name = "Effects";
                                                }
                                            }
                                        }
                                    }
                                    else if (child.name == "Biowaste")
                                    {
                                        if (Mode == 4)
                                        {
                                            Destroy(child.parent.gameObject);
                                        }
                                        if (Mode == 7)
                                        {
                                            Destroy(child.gameObject);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (Editing == false)
        {
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    gameObject.transform.localScale -= new Vector3(0.2f, 0.2f, 0);
                } else
                {
                   gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0);
                }
                gameObject.transform.localScale = new Vector3(Mathf.Clamp(gameObject.transform.localScale.x, 0.4f, 5f), Mathf.Clamp(gameObject.transform.localScale.y, 0.4f, 5f), 1);

                gameObject.transform.position = new Vector3(gameObject.transform.position.x, Mathf.Clamp(gameObject.transform.position.y + (12 * gameObject.transform.localScale.y), -12, 111) - (12 * gameObject.transform.localScale.y), transform.position.z);
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, Mathf.Clamp(gameObject.transform.position.y - (12 * gameObject.transform.localScale.y), -12, 111) + (12 * gameObject.transform.localScale.y), transform.position.z);
                gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x - (16 * gameObject.transform.localScale.x), -192, 192) + (16 * gameObject.transform.localScale.x), transform.position.y, transform.position.z);
                gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x + (16 * gameObject.transform.localScale.x), -192, 192) - (16 * gameObject.transform.localScale.x), transform.position.y, transform.position.z);
            }
            if (Input.GetKey(KeyCode.W))
            {
                    gameObject.transform.position += new Vector3(0, 30 * Time.deltaTime * gameObject.transform.localScale.y, 0);
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, Mathf.Clamp(gameObject.transform.position.y + (12 * gameObject.transform.localScale.y), -12, 111) - (12 * gameObject.transform.localScale.y), transform.position.z);
            }
            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.position -= new Vector3(0, 30 * Time.deltaTime * gameObject.transform.localScale.y, 0);
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, Mathf.Clamp(gameObject.transform.position.y - (12 * gameObject.transform.localScale.y), -12, 111) + (12 * gameObject.transform.localScale.y), transform.position.z);
            }
            if (Input.GetKey(KeyCode.A))
            {
                    gameObject.transform.position -= new Vector3(30 * Time.deltaTime * gameObject.transform.localScale.x, 0, 0);
                    gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x - (16 * gameObject.transform.localScale.x), -192, 192) + (16 * gameObject.transform.localScale.x), transform.position.y, transform.position.z);
            }
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.position += new Vector3(30 * Time.deltaTime * gameObject.transform.localScale.x, 0, 0);
                gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x + (16 * gameObject.transform.localScale.x), -192, 192) - (16 * gameObject.transform.localScale.x), transform.position.y, transform.position.z);
            }
        }
    }
}
