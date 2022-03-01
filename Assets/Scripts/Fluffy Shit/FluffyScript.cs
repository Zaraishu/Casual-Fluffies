using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FluffyScript : MonoBehaviour
{

    #region Variables
    public float Direction;
    public int State;
    public float Speed;
    int Action;
    public float Size;
    public GameObject Target;
    public FluffyVariables Needs;
    string TargetTag;
    public int Motivator;
    public bool FrozenState;
    public bool Falling;
    public bool Held;

    public float Mood;

    public static int ID;

    public int LimbNumber;

    //This variable will stop automatic personality assignment in Start. Use it when loading a fluffy from a pre-made file.
    public bool LoadedIn;
    #endregion


    //MOTIVATOR CHART

    //motivator 0 = eat
    //motivator 1 = talk
    //motivator 2 = play with
    //motivator 3 = fuck
    //motivator 4 = hit
    //motivator 5 = nurse from
    //motivator 6 = hit on

    //state 0 = standing/general idle
    //state 1 = walking/running
    //state 2 = giving birth
    //state 3 = approaching target
    //state 4 = fleeing from target


    //These are a bunch of values used to set fluffy genes, and I forgot why scripts that spawn fluffies don't just set the values manually, but I'm too lazy to find out.

    #region Genetics
    public void SetRace(int Value1, int Value2)
    {
        Needs.RaceGenes[0] = Value1;
        Needs.RaceGenes[1] = Value2;
    }
    public void SetAlicorn(bool Value1, bool Value2)
    {
        Needs.AlicornGenes[0] = Value1;
        Needs.AlicornGenes[1] = Value2;
    }
    public void SetBase(Color Value1, Color Value2)
    {
        Needs.BaseGenes[0] = Value1;
        Needs.BaseGenes[1] = Value2;
    }
    public void SetMane(Color Value1, Color Value2)
    {
        Needs.ManeGenes[0] = Value1;
        Needs.ManeGenes[1] = Value2;
    }
    public void SetEyes(Color Value1, Color Value2)
    {
        Needs.EyeGenes[0] = Value1;
        Needs.EyeGenes[1] = Value2;
    }
    public void SetHair(int Value1, int Value2)
    {
        Needs.HairGenes[0] = Value1;
        Needs.HairGenes[1] = Value2;
    }
    public void SetSize(float Value1, float Value2)
    {
        Needs.SizeGenes[0] = Value1;
        Needs.SizeGenes[1] = Value2;
    }
    #endregion

    //This tedious, repetitive shitheap sets the fluffy's sex, mood, health, and a bunch of shit that could have just been put in the prefab,
    //then uses its genetics to determine its appearance. Also includes support for spawning fluffies without limbs.
    void Start()
    {
        if (!LoadedIn)
        {
            Needs.CutieMark = Random.ColorHSV();
            Needs.Morality = Random.Range(1, 101);
            Needs.Decency = Random.Range(1, 101);
            Needs.Sexuality = Random.Range(1, 101);
            Needs.ID = ID;
            ID += 1;
            Needs.Sex = Random.Range(0, 2);
        }
        Mood = 100;
        float Value1;
        float Value2;
        Value1 = Needs.RaceGenes[0];
        Value2 = Needs.RaceGenes[1];
        if (Value1 < Value2)
        {
            Needs.Race = Needs.RaceGenes[0];
        }
        else
        {
            Needs.Race = Needs.RaceGenes[1];
        }
        if (Needs.AlicornGenes[0] == true && Needs.AlicornGenes[1] == true)
        {
            bool Unicorn;
            bool Pegasus;
            Unicorn = false;
            Pegasus = false;
            foreach (int gene in Needs.RaceGenes)
            {
                if (gene == 1)
                {
                    Pegasus = true;
                }
                else if (gene == 2)
                {
                    Unicorn = true;
                }
            }
            if (Unicorn == true && Pegasus == true)
            {
                Needs.Race = 3;
            }
        }
        float H1;
        float S1;
        float V1;
        float H2;
        float S2;
        float V2;
        float H;
        float S;
        float V;

        //fluff
        Color.RGBToHSV(Needs.BaseGenes[0], out H1, out S1, out V1);
        Color.RGBToHSV(Needs.BaseGenes[1], out H2, out S2, out V2);
        Value1 = H1;
        Value2 = H2;
        if (H1 > H2)
        {
            H = Value1;
        }
        else
        {
            H = Value2;
        }
        Value1 = S1;
        Value2 = S2;
        if (S1 > S2)
        {
            S = Value1;
        }
        else
        {
            S = Value2;
        }
        Value1 = V1;
        Value2 = V2;
        if (V1 > V2)
        {
            V = Value1;
        }
        else
        {
            V = Value2;
        }
        Needs.Base = Color.HSVToRGB(H, S, V);

        //mane
        Color.RGBToHSV(Needs.ManeGenes[0], out H1, out S1, out V1);
        Color.RGBToHSV(Needs.ManeGenes[1], out H2, out S2, out V2);
        Value1 = H1;
        Value2 = H2;
        if (H1 > H2)
        {
            H = Value1;
        }
        else
        {
            H = Value2;
        }
        Value1 = S1;
        Value2 = S2;
        if (S1 > S2)
        {
            S = Value1;
        }
        else
        {
            S = Value2;
        }
        Value1 = V1;
        Value2 = V2;
        if (V1 > V2)
        {
            V = Value1;
        }
        else
        {
            V = Value2;
        }
        Needs.Mane = Color.HSVToRGB(H, S, V);

        //eyes
        Color.RGBToHSV(Needs.EyeGenes[0], out H1, out S1, out V1);
        Color.RGBToHSV(Needs.EyeGenes[1], out H2, out S2, out V2);
        Value1 = H1;
        Value2 = H2;
        if (H1 > H2)
        {
            H = Value1;
        }
        else
        {
            H = Value2;
        }
        Value1 = S1;
        Value2 = S2;
        if (S1 > S2)
        {
            S = Value1;
        }
        else
        {
            S = Value2;
        }
        Value1 = V1;
        Value2 = V2;
        if (V1 > V2)
        {
            V = Value1;
        }
        else
        {
            V = Value2;
        }
        Needs.Eyes = Color.HSVToRGB(H, S, V);


        Value1 = Needs.HairGenes[0];
        Value2 = Needs.HairGenes[1];
        if (Value1 > Value2)
        {
            Needs.Hair = Needs.HairGenes[0];
        }
        else
        {
            Needs.Hair = Needs.HairGenes[1];
        }

        Value1 = Needs.SizeGenes[0] - 1;
        Value2 = Needs.SizeGenes[1] - 1;
        if (Mathf.Abs(Value1) < Mathf.Abs(Value2))
        {
            Needs.Size = Needs.SizeGenes[0];
        }
        else
        {
            Needs.Size = Needs.SizeGenes[1];
        }
        List<GameObject> Descendants = new List<GameObject>();
        GetDescendants(gameObject, Descendants);
        foreach (GameObject child in Descendants)
        {
            if (child.GetComponent<SpriteRenderer>())
            {
                child.GetComponent<SpriteRenderer>().sortingOrder = ID;
                if (child.name == "Base")
                {
                    child.GetComponent<SpriteRenderer>().color = Needs.Base;
                }
                else if (child.name == "Mane")
                {
                    child.GetComponent<SpriteRenderer>().color = Needs.Mane;
                }
                else if (child.name == "Eye")
                {
                    child.GetComponent<SpriteRenderer>().color = Needs.Eyes;
                }
                else if (child.name == "Cutie Mark")
                {
                    child.GetComponent<SpriteRenderer>().color = Needs.CutieMark;
                }
            }
        }
        if (Needs.Race == 0)
        {
            transform.GetChild(0).GetChild(0).GetChild(8).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(0).GetChild(0).GetChild(6).gameObject.SetActive(false);
        }
        else if (Needs.Race == 1)
        {
            transform.GetChild(0).GetChild(0).GetChild(0).GetChild(6).gameObject.SetActive(false);
        }
        else if (Needs.Race == 2)
        {
            transform.GetChild(0).GetChild(0).GetChild(8).gameObject.SetActive(false);
        }
        Needs.Health = 100;
        Needs.Relationships = new List<Relationship>();
        transform.GetChild(0).GetChild(0).GetChild(6).GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("torso")[Needs.Hair + 1];
        transform.GetChild(0).GetChild(0).GetChild(0).GetChild(3).GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("mane")[Needs.Hair + (3 * Needs.Sex)];
        transform.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("tail")[Needs.Hair];
        if (Needs.Age >= 600)
        {
            transform.GetChild(0).GetChild(0).GetChild(7).gameObject.SetActive(true);
        }
        Size = (0.4f + (0.6f * (Mathf.Clamp(Needs.Age / 600, 0, 1)))) * Needs.Size;
        SetDirection(Random.Range(0, 2));
        LimbNumber = 4;
        GameObject LostLimb;
        if (Needs.NoTail)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(2).gameObject;
            LostLimb.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            Destroy(LostLimb.transform.GetChild(0).GetChild(0).gameObject);
        }
        if (Needs.NoBackLegR)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(3).gameObject;
            LostLimb.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("rearstump");
            Destroy(LostLimb.transform.GetChild(0).GetChild(0).gameObject);
            LimbNumber -= 1;
        }
        if (Needs.NoBackLegL)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(4).gameObject;
            LostLimb.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("rearstump");
            Destroy(LostLimb.transform.GetChild(0).GetChild(0).gameObject);
            LimbNumber -= 1;
        }
        if (Needs.NoFrontLegR)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
            LostLimb.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("frontstump");
            Destroy(LostLimb.transform.GetChild(0).GetChild(0).gameObject);
            LimbNumber -= 1;
        }
        if (Needs.NoFrontLegL)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(5).gameObject;
            LostLimb.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("frontstump");
            Destroy(LostLimb.transform.GetChild(0).GetChild(0).gameObject);
            LimbNumber -= 1;
        }
        if (Needs.NoEarR)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
            LostLimb.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            Destroy(LostLimb.transform.GetChild(0).GetChild(0).gameObject);
        }
        if (Needs.NoEarL)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject;
            LostLimb.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            Destroy(LostLimb.transform.GetChild(0).GetChild(0).gameObject);
        }
        if (Needs.NoCutieMark)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(7).gameObject;
            Destroy(LostLimb.transform.GetChild(0).gameObject);
            LostLimb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("cutiescar");
            LostLimb.GetComponent<SpriteRenderer>().color = Needs.Base;
        }
        if (Needs.NoWings)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(8).gameObject;
            Destroy(LostLimb.transform.GetChild(0).gameObject);
            LostLimb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("wingstump");
        }
        if (Needs.NoHorn)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(6).gameObject;
            Destroy(LostLimb.transform.GetChild(0).gameObject);
            LostLimb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hornstump");
        }
        if (Needs.NoEyes)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(4).gameObject;
            Destroy(LostLimb.transform.GetChild(0).gameObject);
            LostLimb.GetComponent<SpriteRenderer>().color = Needs.Base;
            LostLimb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("missingeye");
        }
    }

    #region Technical
    //This adds to the values of a relationship between fluffies and creates that relationship if it isn't already present. 
    //Major determines whether or not special relationship flags will be affected.
    public void SetRelationship(Relationship Relationship, bool Major)
    {
        bool Found = false;
        foreach (Relationship memory in Needs.Relationships)
        {
            if (memory.FluffyID == Relationship.FluffyID)
            {
                Found = true;
                memory.TimeSince = 0;
                memory.LastSeen = transform.position;

                memory.Lust = Mathf.Clamp(memory.Lust + Relationship.Lust, 0, 100);
                memory.Protectiveness = Mathf.Clamp(memory.Protectiveness + Relationship.Protectiveness, 0, 100);
                memory.Admiration = Mathf.Clamp(memory.Admiration + Relationship.Admiration, 0, 100);
                memory.Love = Mathf.Clamp(memory.Love + Relationship.Love, 0, 100);

                memory.Fear = Mathf.Clamp(memory.Fear + Relationship.Fear, 0, 100);
                memory.Anger = Mathf.Clamp(memory.Anger + Relationship.Anger, 0, 100);
                memory.Submission = Mathf.Clamp(memory.Submission + Relationship.Submission, 0, 100);
                if (Major == true)
                {
                    memory.IsChild = Relationship.IsChild;
                    memory.IsParent = Relationship.IsParent;
                    memory.IsSpecialFriend = Relationship.IsSpecialFriend;
                    memory.IsSibling = Relationship.IsSibling;
                    memory.IsDeceased = Relationship.IsDeceased;
                }
            }
        }
        if (Found == false)
        {
            Relationship.Met = Needs.Age;
            Relationship.LastSeen = transform.position;
            Needs.Relationships.Add(Relationship);
        }
    }

    //This retrieves a relationship between the owner of the script and the fluffy with the specified ID.
    public Relationship GetRelationship(int ID)
    {
        Relationship R = new Relationship();
        foreach (Relationship memory in Needs.Relationships)
        {
            if (memory.FluffyID == ID)
            {
                R = memory;
            }
        }
        return R;
    }

    public void Seek(string Tag)
    {

        //<40 morality: rapes mares without asking
        //<25 morality: rapes talkie babbehs
        //<10 morality: rapes chirpie babbehs
        Target = null;
        GameObject[] Results = GameObject.FindGameObjectsWithTag(Tag);
        float Distance;
        if (!Needs.NoEyes)
        {
            Distance = 30;
        }
        else
        {
            Distance = 2;
        }
        List<FluffyScript> List = new List<FluffyScript>();
        foreach (GameObject hit in Results)
        {
            if (hit != gameObject)
            {
                if (!Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(hit.transform.position.x, hit.transform.position.y), LayerMask.GetMask("Map")))
                {
                    if ((hit.transform.position - transform.position).magnitude < Distance)
                    {
                        if (Tag == "Fluffy")
                        {
                            if (Motivator == 6)
                            {
                                if (hit.GetComponent<FluffyVariables>().Sex != Needs.Sex && hit.GetComponent<FluffyVariables>().Age > (Mathf.Clamp(600 * ((Needs.Morality) / 80), 0, 600)))
                                {
                                    List.Add(hit.GetComponent<FluffyScript>());
                                }
                            }
                            else if (Motivator == 5)
                            {
                                if (hit.GetComponent<FluffyVariables>().Lactating && GetRelationship(hit.GetComponent<FluffyVariables>().ID).Fear <= 30)
                                {
                                    Distance = (hit.transform.position - transform.position).magnitude;
                                    Target = hit;
                                }
                            }
                            else if (Motivator == 3)
                            {
                                if (hit.GetComponent<FluffyVariables>().Sex == 1)
                                {   {
                                        if (hit.GetComponent<FluffyVariables>().Age >= Mathf.Clamp(600 * (Needs.Morality / 80), 0, 600))
                                        {
                                            Distance = (hit.transform.position - transform.position).magnitude;
                                            Target = hit;
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }
                            }
                            else if (Motivator == 1)
                            {
                                if (GetRelationship(hit.GetComponent<FluffyVariables>().ID).Anger < 40 && GetRelationship(hit.GetComponent<FluffyVariables>().ID).Fear < 40 && hit.GetComponent<FluffyVariables>().Age > 200)
                                {
                                    List.Add(hit.GetComponent<FluffyScript>());
                                }
                            }
                            else if (Motivator == 0)
                            {
                                if (GetRelationship(hit.GetComponent<FluffyVariables>().ID).Love < (100 - (Needs.Morality)))
                                {
                                    Distance = (hit.transform.position - transform.position).magnitude;
                                    Target = hit;
                                }
                            }
                            else
                            {
                                Distance = (hit.transform.position - transform.position).magnitude;
                                Target = hit;
                            }
                        }
                        else
                        {
                            Distance = (hit.transform.position - transform.position).magnitude;
                            Target = hit;
                        }
                    }
                }
            }
        }
        if (Motivator == 1 || Motivator == 6)
        {
            if (List.Count > 0)
            {
                StartCoroutine(Converse(List[Random.Range(0, List.Count)]));
            }
            else
            {
                if (Motivator == 1)
                {
                    AffectPersonality(0, -1, 0, 0);
                    if (!Needs.NoEyes)
                    {
                        PlaySound("sadtalk", true);
                        FluffyEvent(0, 0, null, 5, "Stand", 2, 3, false);
                        Message("<name> wan' fwends...", null, null, "fwuffy");
                    }
                    else
                    {
                        PlaySound("sadtalk", true);
                        FluffyEvent(0, 0, null, 5, "Stand", 2, 3, false);
                        Message("nu can see nuffin... huu huu huu...", null, null, null);
                    }
                }
                else if (Motivator == 6)
                {
                    FluffyEvent(0, 0, null, 5, "Lay", 2, 0, false);
                    PlaySound("happytalk", true);
                    if (Needs.Sexuality >= 70)
                    {
                        Message("<name> wan' enfies an' gud feews!", null, null, "fwuffy");
                    }
                    else if (Needs.Sexuality >= 30)
                    {
                        Message("<name> wan' pway wif pwetty speshuw fwend!", null, null, "fwuffy");
                    } else
                    {
                        Message("<name> wan' hab bestest speshuw fwend an' bestest babbehs!", null, null, "fwuffy");
                    }
                }
            }
        }
        else
        {
            if (Target == null)
            {
                if (Motivator == 0)
                {
                    if (Needs.IsCannibal == true)
                    {
                        if (Tag == "Corpse")
                        {
                            Seek("Fluffy");
                            return;
                        }
                    }
                    if (Needs.Hunger > 210 * (1 - (Needs.Cannibalism * 0.01f)))
                    {
                        if (Needs.IsCannibal == false)
                        {
                            if (Tag == "Food")
                            {
                                Seek("Corpse");
                                return;
                            }
                        }
                    }
                    if (Needs.Hunger > 210 * (Needs.Cannibalism * 0.01f))
                    {
                        if (Needs.IsCannibal == true)
                        {
                            if (Tag == "Fluffy")
                            {
                                Seek("Food");
                                return;
                            }
                        }
                    }
                    if (Needs.Hunger > 210)
                    {
                        PlaySound("sadtalk", true);
                        Message("huu huu huu...", null, null, null);
                    }
                    else if (Needs.Hunger > 180)
                    {
                        if (Needs.Age > 200)
                        {
                            if (Needs.IsCannibal == true)
                            {
                                PlaySound("sadtalk", true);
                                Message("daddeh, dewe nu dummehs anywhewe!", null, null, null);
                            }
                            else
                            {
                                PlaySound("sadtalk", true);
                                Message("daddeh, pwease... su hungwy...", null, null, null);
                            }
                        }
                        else
                        {
                            PlaySound("sadtalk", true);
                            Message("....", null, null, null);
                        }
                    }
                    else if (Needs.Hunger > 120)
                    {
                        if (Needs.Age > 200)
                        {
                            if (Needs.IsCannibal == true)
                            {
                                PlaySound("happytalk", true);
                                Message("nu dummehs hewe... <name> gu somewhewe ewse!", null, null, "fwuffy");
                            }
                            else
                            {
                                PlaySound("scaredtalk", true);
                                Message("pwease gib nummies, <name> weawwy hungwy!", null, null, "fwuffy");
                            }
                        }
                        else
                        {
                            PlaySound("sadtalk", true);
                            Message("chirp... chirr...", null, null, null);
                        }
                    }
                    else if (Needs.Hunger > 60)
                    {
                        if (Needs.Age > 200)
                        {
                            if (Needs.Lactating == true)
                            {
                                PlaySound("sadtalk", true);
                                Message("daddeh, <name> nee' nummies fow make miwkies fow babbehs!", null, null, "fwuffy");
                            }
                            else
                            {
                                if (Needs.IsCannibal == true)
                                {
                                    PlaySound("happytalk", true);
                                    Message("<name> wan' find dummehs fow num! tee hee hee!", null, null, "fwuffy");
                                }
                                else
                                {
                                    PlaySound("sadtalk", true);
                                    Message("<name> hungwy, can hab nummies?", null, null, "fwuffy");
                                }
                            }
                        }
                        else
                        {
                            PlaySound("sadtalk", true);
                            Message("cheep! cheep! *shiver*", null, null, null);
                        }
                    }
                }
                else if (Motivator == 2)
                {
                    PlaySound("sadtalk", true);
                    Message("dewe nu toysies anywhewe! <name> wan' pway...", null, null, "fwuffy");
                }
                SetDirection(Random.Range(0, 2));
                if (Needs.Age > 200)
                {
                    if (!Needs.NoEyes)
                    {
                        FluffyEvent(1, 0, null, 5, "Run", 4, 0, false);
                    }
                    else
                    {
                        FluffyEvent(1, 0, null, 5, "Walk", 2, 0, false);
                    }
                }
                else
                {
                    FluffyEvent(1, 0, null, 5, "Crawl", 1, 8, false);
                }
            }
            else
            {
                if (Target.CompareTag("Fluffy") && Motivator == 3)
                {
                    Target.GetComponent<FluffyVariables>().SexDrive = 0;
                }
                Check();
                if (Target != null)
                {
                    if (Needs.Age > 200)
                    {
                        if (!Needs.NoEyes)
                        {
                            FluffyEvent(3, Motivator, Target, 5, "Run", 4, 0, false);
                        }
                        else
                        {
                            FluffyEvent(3, Motivator, Target, 5, "Walk", 2, 0, false);
                        }
                    }
                    else
                    {
                        FluffyEvent(3, Motivator, Target, 5, "Crawl", 1, 8, false);
                    }
                    if (Target.CompareTag("Fluffy"))
                    {
                        if (Motivator == 0)
                        {
                            if (Target.GetComponent<FluffyVariables>().Age > 200)
                            {
                                if (Target.GetComponent<FluffyScript>().GetRelationship(Needs.ID).Fear > 20)
                                {

                                    Target.GetComponent<FluffyScript>().FluffyEvent(4, 0, gameObject, 5, "Run", 4, 4, false);
                                    Target.GetComponent<FluffyScript>().PlaySound("scree", true);
                                    Target.GetComponent<FluffyScript>().Message("MUNSTAH FWUFFY! HEWP! SCREEEEEE!", null, null, null);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    //Check the fluffy's motivator for approaching the current Target and perform an action on it accordingly.
    public void Check()
    {
        RaycastHit2D[] Objects = Physics2D.BoxCastAll(new Vector2(transform.position.x, transform.position.y), GetComponent<CapsuleCollider2D>().size, 0, new Vector2(0, 0));
        bool Found;
        Found = false;
        foreach (RaycastHit2D hit in Objects)
        {
            if (hit.collider.gameObject == Target)
            {
                Found = true;
                //if fluffy is seeking it to eat it, eat it, or hit it without waiting if it's a fluffy
                if (Motivator == 0)
                {
                    if (hit.collider.gameObject.CompareTag("Fluffy"))
                    {
                        Message("*fucking BITE*", null, null, null);
                        HitAction(hit.collider.gameObject);
                        FluffyEvent(0, 0, null, 0, "Stand", 2, 0, false);
                    }
                    else
                    {
                        Eat(hit.collider.gameObject);
                        FluffyEvent(0, 0, null, 1, "Stand", 2, 0, false);
                    }
                }
                //else if fluffy is seeking it to play, send a message to the entire thing
                else if (Motivator == 2)
                {
                    if (hit.collider.gameObject.CompareTag("Toy"))
                    {
                        hit.collider.gameObject.SendMessage("Play", GetComponent<FluffyScript>());
                    }
                }
                //else if fluffy is seeking it to fuck it
                else if (Motivator == 3)
                {
                    if (!Needs.NoFrontLegR || !Needs.NoFrontLegL)
                    {
                        if (hit.collider.gameObject.GetComponent<FluffyScript>().GetRelationship(Needs.ID).Submission >= 50 && hit.collider.gameObject.GetComponent<FluffyScript>().GetRelationship(Needs.ID).Fear >= 40)
                        {
                            SpecialHuggies(hit.collider.gameObject, true);
                        }
                        else
                        {
                            SpecialHuggies(hit.collider.gameObject, false);
                        }
                    }
                    else
                    {
                        Message("nu can weach fow gib speshuw huggies! huu huu huu...", null, null, null);
                        FluffyEvent(0, 0, null, 1, "Stand", 2, 3, false);
                    }
                    //if fluffy is seeking it to murder it
                }
                else if (Motivator == 4)
                {
                    Message("*fucking SMACK*", null, null, null);
                    HitAction(hit.collider.gameObject);
                    FluffyEvent(0, 0, null, 1, "Stand", 2, 5, false);
                }
                else if (Motivator == 5)
                {
                    if (hit.collider.gameObject.CompareTag("Fluffy"))
                    {
                        Nurse(hit.collider.gameObject);
                    }
                }
                Target = null;
            }
        }
        if (Found == false)
        {
            if (Target != null)
            {
                if (Target.transform.position.x < transform.position.x)
                {
                    SetDirection(0);
                }
                else
                {
                    SetDirection(1);
                }
            }
        }
    }

    void Update()
    {
        //If health is less than or equal to 0, die.
        if (Needs.Health <= 0)
        {
            Die();
        }
        if (!Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y - (1.55f * transform.localScale.y)), new Vector2(3 * Size, 0.1f), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Map")))
        {
            if (Falling == false)
            {
                Falling = true;
                if (Held == false)
                {
                    PlaySound("scree", true);
                    Message("EEEEEEEE!", null, null, null);
                    FluffyEvent(0, 0, null, 5, "Fall", 2, 10, false);
                    FrozenState = true;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        //if state is set to walking, seeking, or fleeing, move
        if (State == 1 || State == 3 || State == 4)
        {
            if (Direction == 1)
            {
                GetComponent<Rigidbody2D>().MovePosition(transform.position + new Vector3(Speed * Time.deltaTime * 1.25f, 0, 0));
            }
            else
            {
                GetComponent<Rigidbody2D>().MovePosition(transform.position + new Vector3(Speed * Time.deltaTime * -1.25f, 0, 0));
            }
        }
    }

    public void SetDirection(int Dir)
    {
        Direction = Dir;
        if (Direction == 1)
        {
            transform.localScale = new Vector3(Size, Size, 1);
        }
        else
        {
            transform.localScale = new Vector3(Size * -1, Size, 1);
        }
    }

    //get all the descendants of the target object, useful for setting colors within bullshit convoluted skeleton hierarchy
    void GetDescendants(GameObject Object, List<GameObject> Array)
    {
        foreach (Transform child in Object.transform)
        {
            Array.Add(child.gameObject);
            GetDescendants(child.gameObject, Array);
        }
    }

    //If the fluffy is seeking something out, perform an action on it.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (State == 3)
        {
            if (collision.gameObject == Target)
            {
                Check();
            }
        }
    }

    //ENFIES.
    public void Mate(bool Alicorn, bool Submissive)
    {
        State = 0;
        GetComponent<FluffyAI>().ActionTurns = 6;
        Target = null;
        if (Needs.Pregnant)
        {
        int Miscarriage = Random.Range(0, 10);
        if (Miscarriage == 0)
        {
            Needs.Miscarrying = true;
        }
    }
        //Rapey submissive response overides everything else.
        if (Submissive)
        {
            Mood -= 50;
            FluffyEvent(0, 0, null, 6, "Rape", 2, 3, false);
            PlaySound("sadtalk", true);
            Message("huu huu huu...", null, null, null);
        }
        else
        {
            //if fluffy is female and sex drive is less than 60 or alicorn is mating with non-alicorn, be raped
            if (Needs.Sex == 1 && (Needs.SexDrive < 60 || (Alicorn == true && Needs.Race != 3)))
            {
                //if female fluffy being raped is younger than weanling, bleed to death
                if (Needs.Age < 200)
                {
                    FluffyEvent(0, 0, null, 6, "Rape", 2, 4, false);
                    Bleed();
                    Die();
                }
                else
                {
                    FluffyEvent(0, 0, null, 6, "Rape", 2, 4, false);
                    //if fluffy being raped is not pregnant, get it pregnant
                    if (Needs.Pregnant == false)
                    {
                        PlaySound("scree", true);
                        if (Alicorn == true && Needs.Race != 3 && !Needs.NoEyes)
                        {
                            Mood -= 60;
                            Message("NU WAN' MUNSTAH HUGGIES! SCREEEEEEEE!", null, null, null);
                        }
                        else
                        {
                            if (Needs.Pregnant)
                            {
                                if (Needs.Sexuality >= 70 && Needs.Morality <= 20)
                                {
                                    Mood -= 60;
                                    PlaySound("scree", true);
                                    Message("NU WAN'! SCREEEEEEEEE!", null, null, null);
                                } else
                                {
                                    Mood -= 70;
                                    PlaySound("scree", true);
                                    Message("SPESHUW HUGGIES BAD FOW BABBEHS! SCREEEEEEEE!", null, null, null);
                                }
                            }
                            else
                            {
                                Message("NU WAN'! SCREEEEEEEEE!", null, null, null);
                            }
                        }
                        Needs.Pregnant = true;
                        Needs.FoalNumber = Random.Range(2, 7);
                    }
                }
            }
            else
            {
                //else consensual enf enf enf
                if (Needs.Sex == 0)
                {
                    Mood += 10;
                    FluffyEvent(0, 0, null, 6, "Male Mate", 2, 10, false);
                }
                else
                {
                    //if female, be impregnated
                    //But if it's pregnant, don't.
                    Mood += 10;
                    if (Needs.Sexuality >= 70)
                    {
                        PlaySound("scree", true);
                        Message("yeah, wight dewe! REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE-", null, null, null);
                    }
                    else if (Needs.Sexuality >= 30)
                    {
                        PlaySound("happytalk", true);
                        Message("gud feews!", null, null, null);
                    } else
                    {
                        PlaySound("happytalk", true);
                        Message("<name> gon' hab bestest BABBEHS!", null, null, null);
                    }
                    SpawnParticle("Heart Particle");
                    FluffyEvent(0, 0, null, 6, "Female Mate", 2, 10, false);
                    if (!Needs.Pregnant)
                    {
                        Needs.Pregnant = true;
                        Needs.FoalNumber = Random.Range(2, 7);
                    }
                    GameObject[] Results = GameObject.FindGameObjectsWithTag("Fluffy");
                    float Distance = 30;
                    foreach (GameObject hit in Results)
                    {
                        if ((hit.transform.position - transform.position).magnitude < Distance)
                        {
                            FluffyScript OtherFluffy = hit.GetComponent<FluffyScript>();
                            if (hit != gameObject && OtherFluffy.Needs.Age > 200 && OtherFluffy.Needs.Age < 500)
                            {
                                if (!Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(hit.transform.position.x, hit.transform.position.y), LayerMask.GetMask("Map")))
                                {

                                    OtherFluffy.PlaySound("sadtalk", true);
                                    OtherFluffy.Message("eww! daddeh, what dey doin'?", null, null, null);
                                    OtherFluffy.FluffyEvent(0, 0, null, 1, "Stand", 2, 7, false);
                                }
                                else
                                {
                                    OtherFluffy.PlaySound("happytalk", true);
                                    OtherFluffy.Message("daddeh, what dat noisie?", null, null, null);
                                }
                            }
                        }
                    }
                }
            }
        }
        //decrease sex drive
        Needs.SexDrive = 0;
    }

    public void FluffyEvent(int FluffyState, int Action, GameObject Object, int Turns, string Animation, float FluffySpeed, int Face, bool Forced)
    {
        if (FrozenState == false || Forced == true)
        {
            Target = Object;
            State = FluffyState;
            Motivator = Action;
            Speed = (FluffySpeed * (0.1f + (0.9f * (LimbNumber / 4f))) - (FluffySpeed * (0.1f + (0.9f * (LimbNumber / 4f))) * 0.75f) * transform.GetChild(0).GetChild(0).GetChild(9).localScale.y) * (Needs.Health / 100);
            GetComponent<FluffyAI>().ActionTurns = Turns;
            //if the fluffy is missing two or more limbs or has low health, use crawling animation in place of walking/running
            if (Animation == "Stand" || Animation == "Flinch" || Animation == "Poop")
            {
                if (LimbNumber < 3 || Needs.Health <= 40)
                {
                    Animation = "Lay";
                }
            }
            else if (Animation == "Pant")
            {
                if (LimbNumber < 3 || Needs.Health <= 40)
                {
                    Animation = "Breathe";
                }
            }
            else if (Animation == "Walk" || Animation == "Run")
            {
                if (LimbNumber < 3 || Needs.Health <= 40)
                {
                    Animation = "Crawl";
                }
            }
            else if (Animation == "Fall")
            {
                if (Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y - (1.55f * transform.localScale.y)), new Vector2(3 * Needs.Size, 0.1f), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Map")))
                {
                    Falling = false;
                    FrozenState = false;
                    if (LimbNumber > 3 || Needs.Health <= 40)
                    {
                        Animation = "Stand";
                    }
                    else
                    {
                        Animation = "Lay";
                    }
                }
            }
            transform.GetChild(0).GetComponent<Animator>().SetTrigger(Animation);
            if (State == 3)
            {
                Check();
            }
        }
        transform.GetChild(0).GetComponent<AnimEvents>().SetFace(Face);
    }

    public void LoseLimb(int Limb)
    {
        Message("SCREEEEEEEEEEEEEEEEEEEEEEEEE!", null, null, null);
        PlaySound("scree", true);
        Needs.Health -= 7.5f;
        GameObject LostLimb = null;
        if (Limb == 0)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(2).gameObject;
            LostLimb.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            Destroy(LostLimb.transform.GetChild(0).GetChild(0).gameObject);
            Needs.NoTail = true;
        }
        else if (Limb == 1)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(3).gameObject;
            LostLimb.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("rearstump");
            Destroy(LostLimb.transform.GetChild(0).GetChild(0).gameObject);
            LimbNumber -= 1;
            Needs.NoBackLegR = true;
        }
        else if (Limb == 2)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(4).gameObject;
            LostLimb.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("rearstump");
            Destroy(LostLimb.transform.GetChild(0).GetChild(0).gameObject);
            LimbNumber -= 1;
            Needs.NoBackLegL = true;
        }
        else if (Limb == 3)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
            LostLimb.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("frontstump");
            Destroy(LostLimb.transform.GetChild(0).GetChild(0).gameObject);
            LimbNumber -= 1;
            Needs.NoFrontLegR = true;
        }
        else if (Limb == 4)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(5).gameObject;
            LostLimb.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("frontstump");
            Destroy(LostLimb.transform.GetChild(0).GetChild(0).gameObject);
            LimbNumber -= 1;
            Needs.NoFrontLegL = true;
        }
        else if (Limb == 5)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
            LostLimb.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            Destroy(LostLimb.transform.GetChild(0).GetChild(0).gameObject);
        }
        else if (Limb == 6)
        {
            Needs.NoEarR = true;
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
            LostLimb.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            Destroy(LostLimb.transform.GetChild(0).GetChild(0).gameObject);
            Needs.NoEarR = true;
        }
        else if (Limb == 7)
        {
            Needs.NoEarL = true;
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject;
            LostLimb.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            Destroy(LostLimb.transform.GetChild(0).GetChild(0).gameObject);
            Needs.NoEarL = true;
        }
        else if (Limb == 8)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(7).gameObject;
            Destroy(LostLimb.transform.GetChild(0).gameObject);
            LostLimb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("cutiescar");
            LostLimb.GetComponent<SpriteRenderer>().color = Needs.Base;
            Needs.NoCutieMark = true;
        }
        else if (Limb == 9)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(8).gameObject;
            Destroy(LostLimb.transform.GetChild(0).gameObject);
            LostLimb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("wingstump");
            Needs.NoWings = true;
        }
        else if (Limb == 10)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(6).gameObject;
            Destroy(LostLimb.transform.GetChild(0).gameObject);
            Needs.NoHorn = true;
            LostLimb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hornstump");
        }
        else if (Limb == 11)
        {
            LostLimb = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(4).gameObject;
            Destroy(LostLimb.transform.GetChild(0).gameObject);
            // The Shine sprite (child of the Fluffy GameObject at position 0,0,0,5) overlaps the "missingeye" sprite when destroyed.
            // I'm unsure if you can just destroy this like the Eye GameObject, so I'm just setting the Shine GameObject as inactive for now.
            transform.GetChild(0).GetChild(0).GetChild(0).GetChild(5).gameObject.SetActive(false);
            LostLimb.GetComponent<SpriteRenderer>().color = Needs.Base;
            LostLimb.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("missingeye");
            Needs.NoEyes = true;
        }
        GameObject LimbLost = null;
        FluffyEvent(0, 0, null, 5, "Pant", 2, 4, false);
        if (Limb < 6)
        {
            LimbLost = Instantiate(Resources.Load<GameObject>("Corpse").transform.GetChild(0).GetChild(Limb + 5).gameObject);
        }
        else if (Limb < 8)
        {
            LimbLost = Instantiate(Resources.Load<GameObject>("Corpse").transform.GetChild(0).GetChild(10).GetChild(Limb).gameObject);
        }
        if (LimbLost != null)
        {
            LimbLost.transform.position = LostLimb.transform.position;
            LimbLost.transform.localScale = transform.localScale;
            List<GameObject> Descendants = new List<GameObject>();
            GetDescendants(LimbLost, Descendants);
            Destroy(LimbLost.GetComponent<HingeJoint2D>());
            LimbLost.GetComponent<FoodScript>().Hunger = LimbLost.GetComponent<FoodScript>().Hunger * Size;
            Destroy(LimbLost.transform.Find("Dismember").gameObject);
            if (Limb == 0)
            {
                LimbLost.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("tail")[Needs.Hair];
            }
            foreach (GameObject child in Descendants)
            {
                if (child.name == "Base")
                {
                    child.GetComponent<SpriteRenderer>().color = Needs.Base;
                }
                else if (child.name == "Mane")
                {
                    child.GetComponent<SpriteRenderer>().color = Needs.Mane;
                }
                else if (child.name == "Cutie Mark")
                {
                    child.GetComponent<SpriteRenderer>().color = Needs.CutieMark;
                    if (Needs.Age < 600)
                    {
                        child.SetActive(false);
                    }
                }
            }
        }
    }

    public void AffectPersonality(float Morality, float Decency, float Cannibalism, float Sexuality)
    {
        Needs.Morality = Mathf.Clamp(Needs.Morality + Morality, 1, 100);
        Needs.Decency = Mathf.Clamp(Needs.Decency + Decency, 1, 100);
        Needs.Cannibalism = Mathf.Clamp(Needs.Cannibalism + Cannibalism, 1, 100);
        Needs.Sexuality = Mathf.Clamp(Needs.Sexuality + Sexuality, 1, 100);
    }
    #endregion

    #region Effects
    //Delete the owner of the script and spawn a corpse in its place.
    public void Die()
    {
        PlaySound("die", false);
        //spawn corpse
        GameObject Corpse = Instantiate((GameObject)Resources.Load("Corpse"));
        //set color, scale, face, and position to those of the dying fluffy
        List<GameObject> Descendants = new List<GameObject>();
        GetDescendants(Corpse, Descendants);
        foreach (GameObject child in Descendants)
        {
            if (child.GetComponent<HingeJoint2D>())
            {
                if (transform.localScale.x < 0)
                {
                    JointAngleLimits2D limits = child.GetComponent<HingeJoint2D>().limits;
                    limits.min = limits.min * -1;
                    limits.max = limits.max * -1;
                    child.GetComponent<HingeJoint2D>().limits = limits;
                }
            }
            if (child.GetComponent<FoodScript>())
            {
                child.GetComponent<FoodScript>().Hunger = child.GetComponent<FoodScript>().Hunger * Size;
            }
            if (child.name == "Base")
            {
                child.GetComponent<SpriteRenderer>().color = Needs.Base;
            }
            else if (child.name == "Mane")
            {
                child.GetComponent<SpriteRenderer>().color = Needs.Mane;
            }
            else if (child.name == "Eye")
            {
                child.GetComponent<SpriteRenderer>().color = Needs.Eyes;
            }
            else if (child.name == "Cutie Mark")
            {
                child.GetComponent<SpriteRenderer>().color = Needs.CutieMark;
                if (Needs.Age < 600)
                {
                    child.SetActive(false);
                }
            }
        }
        if (Needs.Race == 0)
        {
            Corpse.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
            Corpse.transform.GetChild(0).GetChild(10).GetChild(4).gameObject.SetActive(false);
        }
        else if (Needs.Race == 1)
        {
            Corpse.transform.GetChild(0).GetChild(10).GetChild(4).gameObject.SetActive(false);
        }
        else if (Needs.Race == 2)
        {
            Corpse.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
        }
        Corpse.transform.GetChild(0).GetChild(10).GetChild(0).GetComponent<SpriteRenderer>().sprite = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().sprite;
        Corpse.transform.GetChild(0).GetChild(10).GetChild(8).GetComponent<SpriteRenderer>().sprite = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(4).GetComponent<SpriteRenderer>().sprite;
        Corpse.transform.GetChild(0).GetChild(10).GetChild(9).GetComponent<SpriteRenderer>().sprite = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(5).GetComponent<SpriteRenderer>().sprite;
        Corpse.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = transform.GetChild(0).GetChild(0).GetChild(6).GetComponent<SpriteRenderer>().sprite;
        Corpse.transform.GetChild(0).GetChild(10).GetChild(5).GetComponent<SpriteRenderer>().sprite = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(3).GetComponent<SpriteRenderer>().sprite;
        Corpse.transform.GetChild(0).GetChild(5).GetChild(0).GetComponent<SpriteRenderer>().sprite = transform.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<SpriteRenderer>().sprite;
        Corpse.transform.position = transform.position;
        Corpse.transform.localScale = transform.localScale;
        //apply mutilations
        if (Needs.NoEyes)
        {
            Corpse.transform.GetChild(0).GetChild(10).GetChild(8).GetComponent<SpriteRenderer>().color = Needs.Base;
            //TODO: This line is an incomplete remnant by the original creator. It's probably supposed to set the eye of the fluffy corpse into place, but needs more research/testing to fix.
            //Corpse.transform.GetChild(0).GetChild(10).GetChild(8).position +=
        }
        if (Needs.NoEarL)
        {
            Destroy(Corpse.transform.GetChild(0).GetChild(10).GetChild(7).gameObject);
        }
        if (Needs.NoEarR)
        {
            Destroy(Corpse.transform.GetChild(0).GetChild(10).GetChild(6).gameObject);
        }
        if (Needs.NoFrontLegR)
        {
            Corpse.transform.GetChild(0).GetChild(8).GetChild(3).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("frontstump");
            Destroy(Corpse.transform.GetChild(0).GetChild(8).GetComponent<FoodScript>());
            Destroy(Corpse.transform.GetChild(0).GetChild(8).GetChild(0).gameObject);
            Destroy(Corpse.transform.GetChild(0).GetChild(8).GetChild(1).gameObject);
            Destroy(Corpse.transform.GetChild(0).GetChild(8).GetChild(2).gameObject);
            Destroy(Corpse.transform.GetChild(0).GetChild(8).GetComponent<CapsuleCollider2D>());
            Corpse.transform.GetChild(0).GetChild(8).tag = "Untagged";
        }
        if (Needs.NoFrontLegL)
        {
            Corpse.transform.GetChild(0).GetChild(9).GetChild(3).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("frontstump");
            Destroy(Corpse.transform.GetChild(0).GetChild(9).GetComponent<FoodScript>());
            Destroy(Corpse.transform.GetChild(0).GetChild(9).GetChild(0).gameObject);
            Destroy(Corpse.transform.GetChild(0).GetChild(9).GetChild(1).gameObject);
            Destroy(Corpse.transform.GetChild(0).GetChild(9).GetChild(2).gameObject);
            Destroy(Corpse.transform.GetChild(0).GetChild(9).GetComponent<CapsuleCollider2D>());
            Corpse.transform.GetChild(0).GetChild(9).tag = "Untagged";
        }
        if (Needs.NoBackLegR)
        {
            Corpse.transform.GetChild(0).GetChild(6).GetChild(3).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("frontstump");
            Destroy(Corpse.transform.GetChild(0).GetChild(6).GetComponent<FoodScript>());
            Destroy(Corpse.transform.GetChild(0).GetChild(6).GetChild(0).gameObject);
            Destroy(Corpse.transform.GetChild(0).GetChild(6).GetChild(1).gameObject);
            Destroy(Corpse.transform.GetChild(0).GetChild(6).GetChild(2).gameObject);
            Destroy(Corpse.transform.GetChild(0).GetChild(6).GetComponent<CapsuleCollider2D>());
            Corpse.transform.GetChild(0).GetChild(6).tag = "Untagged";
        }
        if (Needs.NoBackLegL)
        {
            Corpse.transform.GetChild(0).GetChild(7).GetChild(3).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("frontstump");
            Destroy(Corpse.transform.GetChild(0).GetChild(7).GetComponent<FoodScript>());
            Destroy(Corpse.transform.GetChild(0).GetChild(7).GetChild(0).gameObject);
            Destroy(Corpse.transform.GetChild(0).GetChild(7).GetChild(1).gameObject);
            Destroy(Corpse.transform.GetChild(0).GetChild(7).GetChild(2).gameObject);
            Destroy(Corpse.transform.GetChild(0).GetChild(7).GetComponent<CapsuleCollider2D>());
            Corpse.transform.GetChild(0).GetChild(7).tag = "Untagged";
        }
        if (Needs.NoWings)
        {
            Corpse.transform.GetChild(0).GetChild(3).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("wingstump");
        }
        if (Needs.NoHorn)
        {
            Corpse.transform.GetChild(0).GetChild(10).GetChild(4).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hornstump");
        }
        if (Needs.NoCutieMark)
        {
            Corpse.transform.GetChild(0).GetChild(4).GetComponent<SpriteRenderer>().color = Needs.Base;
            Corpse.transform.GetChild(0).GetChild(4).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("cutiescar");
        }
        if (Needs.NoTail)
        {
            Destroy(Corpse.transform.GetChild(0).GetChild(5).gameObject);
        }
        //destroy the living fluffy
        Destroy(gameObject);
    }

    public void Poop()
    {
        //spawn poop
        GameObject SpawnedPoop = Instantiate((GameObject)Resources.Load("Poop"));
        SpawnedPoop.transform.position = transform.position - new Vector3(transform.localScale.x, 0, 0);
        PlaySound("Sounds/poop", false);
        //animate
        if (Needs.Age > 200)
        {
            FluffyEvent(0, 0, null, 1, "Poop", 2, 0, false);
        }
        else
        {
            FluffyEvent(0, 0, null, 1, "Lay", 2, 8, false);
        }
        //decrease poop
        Needs.Poop -= 60;
    }

    //just fuckin bleed, exact same mechanism as poop
    public void Bleed()
    {
        GameObject SpawnedBlood = Instantiate((GameObject)Resources.Load("Blood"));
        SpawnedBlood.transform.position = transform.position;
    }

    //vomit
    public void Vomit()
    {
        GameObject SpawnedVomit = Instantiate((GameObject)Resources.Load("Vomit"));
        SpawnedVomit.transform.position = transform.position + new Vector3(transform.localScale.x, 0, 0);
        Needs.Hunger += 30;
    }

    public void SpawnParticle(string Particle)
    {
        GameObject Effect = Instantiate((GameObject)Resources.Load(Particle));
        Effect.transform.position = transform.position;
    }


    public void Message(string Text, string[] OtherName, string[] Substitute, string SelfSubstitute)
    {
        GameObject Message = Instantiate((GameObject)Resources.Load("Message"));
        Message.GetComponent<MessageScript>().Anchor = gameObject;
        Message.GetComponent<MessageScript>().RelativePosition = new Vector3(0, GetComponent<CapsuleCollider2D>().size.y / 2, 0);
        Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Text;
        if (Needs.Name != string.Empty)
        {
            Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text.Replace("<name>", Needs.Name.ToLower().Replace("r", "w").Replace("l", "w").Replace("v", "b"));
            Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text.Replace("<NAME>", Needs.Name.ToUpper().Replace("R", "W").Replace("L", "W").Replace("V", "B"));
        }
        else
        {
            Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text.Replace("<name>", SelfSubstitute);
            Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text.Replace("<NAME>", SelfSubstitute);
        }
        if (OtherName != null)
        {
            int Number = 0;
            foreach (string name in OtherName)
            {
                if (name != string.Empty)
                {
                    Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text.Replace("<name" + Number + ">", name.ToLower().Replace("r", "w").Replace("l", "w").Replace("v", "b"));
                    Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text.Replace("<NAME" + Number + ">", name.ToUpper().Replace("r", "w").Replace("l", "w").Replace("V", "B"));
                }
                else
                {
                    Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text.Replace("<name" + Number + ">", Substitute[Number].ToLower());
                    Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Message.transform.GetChild(0).GetChild(0).GetComponent<Text>().text.Replace("<NAME" + Number + ">", Substitute[Number].ToUpper());
                }
                Number += 1;
            }
        }
    }

    //Hoo boy, this one gets used a lot. When this is called, a one-shot sound effect that plays a sound and then deletes itself will be spawned at the fluffy's position. 
    //Voice determines whether the fluffy's age will affect the pitch of the sound.
    public void PlaySound(string Sound, bool Voice)
    {
        GameObject Clip = Instantiate((GameObject)Resources.Load("Audio"));
        Clip.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        if (Voice == true)
        {
            Clip.GetComponent<AudioSource>().pitch = 2 - (Mathf.Clamp01(Needs.Age / 600));
        }
        Clip.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load(Sound);
        Clip.GetComponent<AudioSource>().Play();
    }
    #endregion

    #region Affects Bystanders

    //Detect that the fluffy is no longer falling and apply fall damage while scaring the shit out of other fluffies if possible.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Falling == true)
        {
            Falling = false;
            if (Held == false)
            {
                FrozenState = false;
                if (Needs.Age > 200)
                {
                    FluffyEvent(0, 0, null, 0, "Stand", 2, 0, false);
                }
                else
                {
                    FluffyEvent(0, 0, null, 0, "Lay", 2, 8, false);
                }
            }
            if (collision.relativeVelocity.magnitude > 5)
            {
                PlaySound("hurt", false);
                if (Needs.Age >= 200)
                {
                    Needs.Health -= (collision.relativeVelocity.magnitude * 3) - 5;
                }
                else
                {
                    Needs.Health -= ((collision.relativeVelocity.magnitude * 3) - 5) * 3;
                }
                if (Needs.Health <= 0)
                {
                    Bleed();
                    GameObject[] Results = GameObject.FindGameObjectsWithTag("Fluffy");
                    float Distance = 30;
                    foreach (GameObject hit in Results)
                    {
                        if ((hit.transform.position - transform.position).magnitude < Distance)
                        {
                            if (hit != gameObject && hit.GetComponent<FluffyVariables>().Age > 200)
                            {
                                FluffyScript OtherFluffy = hit.GetComponent<FluffyScript>();

                                if (!Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(hit.transform.position.x, hit.transform.position.y), LayerMask.GetMask("Map")))
                                {
                                    if (OtherFluffy.GetRelationship(Needs.ID).Love > 20)
                                    {
                                        OtherFluffy.AffectPersonality((OtherFluffy.GetRelationship(Needs.ID).Love / 10 + 5) * -1, 0, 0, 0);
                                        if (OtherFluffy.Needs.Morality > 10)
                                        {
                                            string[] Names = new string[1];
                                            Names[0] = Needs.Name;
                                            string[] Subs = new string[1];
                                            if (OtherFluffy.GetRelationship(Needs.ID).IsChild == true)
                                            {
                                                Subs[0] = "BABBEH";
                                                OtherFluffy.Message("<NAME0>! SCREEEEEEEE!", Names, Subs, null);
                                            }
                                            else if (OtherFluffy.GetRelationship(Needs.ID).IsSpecialFriend == true)
                                            {
                                                Subs[0] = "SPESHUW FWEND";
                                                OtherFluffy.Message("<NAME0>! SCREEEEEEEE!", Names, Subs, null);
                                            }
                                            else if (OtherFluffy.GetRelationship(Needs.ID).IsParent == true)
                                            {
                                                if (Needs.Sex == 0)
                                                {
                                                    OtherFluffy.Message("DADDEH! SCREEEEEEEE!", null, null, null);
                                                }
                                                else
                                                {
                                                    OtherFluffy.Message("MUMMAH! SCREEEEEEEE!", null, null, null);
                                                }
                                            }
                                            else if (OtherFluffy.GetRelationship(Needs.ID).Love >= 80)
                                            {
                                                Subs[0] = "BESTEST FWEND";
                                                OtherFluffy.Message("<NAME0>! SCREEEEEEEE!", Names, Subs, null);
                                            }
                                            else
                                            {
                                                Subs[0] = "FWEND";
                                                OtherFluffy.Message("<NAME0>! SCREEEEEEEE!", Names, Subs, null);
                                            }
                                            OtherFluffy.PlaySound("scree", true);
                                            OtherFluffy.FluffyEvent(0, 0, null, 5, "Stand", 2, 4, false);
                                        }
                                        Relationship Bond = new Relationship
                                        {
                                            FluffyID = Needs.ID,
                                            Fluffy = gameObject,
                                            IsChild = OtherFluffy.GetRelationship(Needs.ID).IsChild,
                                            IsParent = OtherFluffy.GetRelationship(Needs.ID).IsSibling,
                                            IsDeceased = true
                                        }
                                        ;
                                        OtherFluffy.SetRelationship(Bond, true);
                                    }
                                    else
                                    {
                                        OtherFluffy.AffectPersonality(-5, 0, 0, 0);
                                        if (OtherFluffy.Needs.IsCannibal == false)
                                        {
                                            if (OtherFluffy.Needs.Morality > 20)
                                            {
                                                OtherFluffy.PlaySound("scree", true);
                                                OtherFluffy.Message("IT NU TIME FOW SWEEPIES! WHAT DADDEH DU TU FWUFFY?", null, null, null);
                                                OtherFluffy.FluffyEvent(0, 0, null, 5, "Stand", 2, 4, false);
                                                OtherFluffy.Mood = 0;
                                            }
                                        }
                                        else
                                        {
                                            OtherFluffy.PlaySound("happytalk", true);
                                            OtherFluffy.Message("nummie time!", null, null, null);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Needs.Age > 200)
                    {
                        if ((collision.relativeVelocity.magnitude * 3) > 50)
                        {
                            GameObject[] Results = GameObject.FindGameObjectsWithTag("Fluffy");
                            float Distance = 30;
                            foreach (GameObject hit in Results)
                            {
                                if ((hit.transform.position - transform.position).magnitude < Distance)
                                {
                                    if (hit != gameObject && hit.GetComponent<FluffyVariables>().Age > 200)
                                    {
                                        FluffyScript OtherFluffy = hit.GetComponent<FluffyScript>();
                                        OtherFluffy.AffectPersonality(-3, 0, 0, 0);
                                        if (!Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(hit.transform.position.x, hit.transform.position.y), LayerMask.GetMask("Map")))
                                        {
                                            if (OtherFluffy.Needs.Morality > 20)
                                            {
                                                if (OtherFluffy.GetRelationship(Needs.ID).Love > 20)
                                                {
                                                    string[] Names = new string[1];
                                                    Names[0] = Needs.Name;
                                                    string[] Subs = new string[1];
                                                    if (OtherFluffy.GetRelationship(Needs.ID).IsChild == true)
                                                    {
                                                        Subs[0] = "BABBEH";
                                                        OtherFluffy.Message("SCREEE! WHY HUWT <NAME0>?", Names, Subs, null);
                                                    }
                                                    else if (OtherFluffy.GetRelationship(Needs.ID).IsSpecialFriend == true)
                                                    {
                                                        Subs[0] = "SPESHUW FWEND";
                                                        OtherFluffy.Message("SCREEE! WHY HUWT <NAME0>?", Names, Subs, null);
                                                    }
                                                    else if (OtherFluffy.GetRelationship(Needs.ID).IsParent == true)
                                                    {
                                                        if (Needs.Sex == 0)
                                                        {
                                                            OtherFluffy.Message("SCREEE! WHY HUWT DADDEH?", null, null, null);
                                                        }
                                                        else
                                                        {
                                                            OtherFluffy.Message("SCREEE! WHY HUWT MUMMAH?", null, null, null);
                                                        }
                                                    }
                                                    else if (OtherFluffy.GetRelationship(Needs.ID).Love >= 80)
                                                    {
                                                        Subs[0] = "BESTEST FWEND";
                                                        OtherFluffy.Message("SCREEE! WHY HUWT <NAME0>?", Names, Subs, null);
                                                    }
                                                    else
                                                    {
                                                        Subs[0] = "FWEND";
                                                        OtherFluffy.Message("SCREEE! WHY HUWT <NAME0>?", Names, Subs, null);
                                                    }
                                                    OtherFluffy.PlaySound("scree", true);
                                                    OtherFluffy.FluffyEvent(0, 0, null, 5, "Stand", 2, 4, false);
                                                    OtherFluffy.Mood = 0;
                                                }
                                            }
                                            else
                                            {
                                                if (OtherFluffy.Needs.IsCannibal == true)
                                                {
                                                    if (Needs.IsCannibal == false)
                                                    {
                                                        OtherFluffy.PlaySound("happytalk", true);
                                                        OtherFluffy.Message("nummie time?", null, null, null);
                                                    }
                                                }
                                                else
                                                {
                                                    if (OtherFluffy.Needs.Morality > 30)
                                                    {
                                                        OtherFluffy.PlaySound("scaredtalk", true);
                                                        OtherFluffy.Message("eep! huu huu huu...", null, null, null);
                                                        OtherFluffy.FluffyEvent(0, 0, null, 3, "Stand", 2, 4, false);
                                                    }
                                                    OtherFluffy.Mood -= (collision.relativeVelocity.magnitude * 1) - 5;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (OtherFluffy.Needs.Age > 200)
                                            {
                                                if (!OtherFluffy.Needs.NoEarR || !OtherFluffy.Needs.NoEarL)
                                                {
                                                    OtherFluffy.Mood -= 5;
                                                    OtherFluffy.PlaySound("sadtalk", true);
                                                    OtherFluffy.FluffyEvent(0, 0, null, 1, "Stand", 2, 3, false);
                                                    OtherFluffy.Message("scawy noisie!", null, null, null);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            PlaySound("scree", true);
                            Mood -= (collision.relativeVelocity.magnitude * 3) - 5;
                            FluffyEvent(0, 0, null, 1, "Flinch", 2, 10, false);
                            Message("SCREEEEEEEE!", null, null, null);
                            Bleed();
                        }
                        else if ((collision.relativeVelocity.magnitude * 3) > 20)
                        {
                            GameObject[] Results = GameObject.FindGameObjectsWithTag("Fluffy");
                            float Distance = 30;
                            foreach (GameObject hit in Results)
                            {
                                if ((hit.transform.position - transform.position).magnitude < Distance)
                                {
                                    if (hit != gameObject && hit.GetComponent<FluffyVariables>().Age > 200)
                                    {
                                        FluffyScript OtherFluffy = hit.GetComponent<FluffyScript>();
                                        OtherFluffy.AffectPersonality(-1, 0, 0, 0);
                                        if (!Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(hit.transform.position.x, hit.transform.position.y), LayerMask.GetMask("Map")))
                                        {
                                            if (OtherFluffy.Needs.IsCannibal == false)
                                            {
                                                if (OtherFluffy.GetRelationship(Needs.ID).Love > 20)
                                                {
                                                    if (OtherFluffy.Needs.Morality > 30)
                                                    {
                                                        OtherFluffy.PlaySound("scaredtalk", true);
                                                        string[] Names = new string[1];
                                                        Names[0] = Needs.Name;
                                                        string[] Subs = new string[1];
                                                        if (OtherFluffy.GetRelationship(Needs.ID).IsChild == true)
                                                        {
                                                            Subs[0] = "babbeh";
                                                            OtherFluffy.Message("nuuu! nu huwt <name0>!", Names, Subs, null);
                                                        }
                                                        else if (OtherFluffy.GetRelationship(Needs.ID).IsSpecialFriend == true)
                                                        {
                                                            Subs[0] = "speshuw fwend";
                                                            OtherFluffy.Message("nuuu! nu huwt <name0>!", Names, Subs, null);
                                                        }
                                                        else if (OtherFluffy.GetRelationship(Needs.ID).IsParent == true)
                                                        {
                                                            if (Needs.Sex == 0)
                                                            {
                                                                OtherFluffy.Message("nuuu! nu huwt daddeh!", null, null, null);
                                                            }
                                                            else
                                                            {
                                                                OtherFluffy.Message("nuuu! nu huwt mummah!", null, null, null);
                                                            }
                                                        }
                                                        else if (OtherFluffy.GetRelationship(Needs.ID).Love >= 80)
                                                        {
                                                            Subs[0] = "bestest fwend";
                                                            OtherFluffy.Message("nuuu! nu huwt <name0>!", Names, Subs, null);
                                                        }
                                                        else
                                                        {
                                                            Subs[0] = "fwend";
                                                            OtherFluffy.Message("nuuu! nu huwt <name0>!", Names, Subs, null);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (OtherFluffy.Needs.Morality > 40)
                                                    {
                                                        OtherFluffy.PlaySound("scaredtalk", true);
                                                        OtherFluffy.Message("pwease nu huwt fwuffy...", null, null, null);
                                                        OtherFluffy.FluffyEvent(0, 0, null, 1, "Stand", 2, 3, false);
                                                    }
                                                    OtherFluffy.Mood -= (collision.relativeVelocity.magnitude) - 5;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            PlaySound("ow", true);
                            Mood -= (collision.relativeVelocity.magnitude * 2) - 5;
                            FluffyEvent(0, 0, null, 1, "Flinch", 2, 3, false);
                            Message("owwie!", null, null, null);
                        }
                        else
                        {
                            PlaySound("oof", true);
                            Message("oof!", null, null, null);
                        }
                    }
                    else
                    {
                        if (((collision.relativeVelocity.magnitude * 3) - 5) * 3 > 50)
                        {
                            GameObject[] Results = GameObject.FindGameObjectsWithTag("Fluffy");
                            float Distance = 30;
                            foreach (GameObject hit in Results)
                            {
                                if ((hit.transform.position - transform.position).magnitude < Distance)
                                {
                                    if (hit != gameObject && hit.GetComponent<FluffyVariables>().Age > 200)
                                    {
                                        FluffyScript OtherFluffy = hit.GetComponent<FluffyScript>();
                                        if (!Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(hit.transform.position.x, hit.transform.position.y), LayerMask.GetMask("Map")))
                                        {
                                            if (OtherFluffy.GetRelationship(Needs.ID).IsChild == true && OtherFluffy.GetRelationship(Needs.ID).Love >= 40)
                                            {
                                                if (OtherFluffy.Needs.Morality > 20)
                                                {
                                                    string[] Names = new string[1];
                                                    Names[0] = Needs.Name;
                                                    string[] Subs = new string[1];
                                                    if (OtherFluffy.GetRelationship(Needs.ID).Love > 20)
                                                    {
                                                        Subs[0] = "BABBEH";
                                                        OtherFluffy.Message("GIB <NAME0> BACK TU MUMMAH! SCREEEEEEE!", Names, Subs, null);
                                                    }
                                                    OtherFluffy.PlaySound("scree", true);
                                                    OtherFluffy.FluffyEvent(0, 0, null, 5, "Stand", 2, 4, false);
                                                }
                                                    OtherFluffy.Mood = 0;
                                            }
                                            else if (OtherFluffy.Needs.IsCannibal == false)
                                            {
                                                if (OtherFluffy.Needs.Morality > 30)
                                                {
                                                    OtherFluffy.PlaySound("scaredtalk", true);
                                                    OtherFluffy.Message("SCREEEEE! WHY GIB HUWTIES TO WIDDWE BABBEH?", null, null, null);
                                                    OtherFluffy.FluffyEvent(0, 0, null, 3, "Stand", 2, 4, false);
                                                }
                                                OtherFluffy.Mood -= (collision.relativeVelocity.magnitude * 3) - 5;
                                            }
                                        }
                                        else
                                        {
                                            if (OtherFluffy.Needs.Age > 200)
                                            {
                                                if (!OtherFluffy.Needs.NoEarR || !OtherFluffy.Needs.NoEarL)
                                                {
                                                    OtherFluffy.Mood -= 5;
                                                    OtherFluffy.PlaySound("sadtalk", true);
                                                    OtherFluffy.FluffyEvent(0, 0, null, 1, "Stand", 2, 3, false);
                                                    OtherFluffy.Message("scawy noisie!", null, null, null);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            PlaySound("scree", true);
                            Mood -= (collision.relativeVelocity.magnitude * 3) - 5;
                            Message("SPEEEEEEEE!", null, null, null);
                            FluffyEvent(0, 0, null, 0, "Lay", 2, 10, false);
                            Bleed();
                        }
                        else if (((collision.relativeVelocity.magnitude * 3) - 5) * 3 > 20)
                        {
                            GameObject[] Results = GameObject.FindGameObjectsWithTag("Fluffy");
                            float Distance = 30;
                            foreach (GameObject hit in Results)
                            {
                                if ((hit.transform.position - transform.position).magnitude < Distance)
                                {
                                    if (hit != gameObject && hit.GetComponent<FluffyVariables>().Age > 200)
                                    {
                                        FluffyScript OtherFluffy = hit.GetComponent<FluffyScript>();
                                        if (!Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(hit.transform.position.x, hit.transform.position.y), LayerMask.GetMask("Map")))
                                        {
                                            if (OtherFluffy.GetRelationship(Needs.ID).IsChild == true && OtherFluffy.GetRelationship(Needs.ID).Love >= 40)
                                            {
                                                if (OtherFluffy.Needs.Morality > 30)
                                                {
                                                    string[] Names = new string[1];
                                                    Names[0] = Needs.Name;
                                                    string[] Subs = new string[1];
                                                    if (OtherFluffy.GetRelationship(Needs.ID).Love > 20)
                                                    {
                                                        Subs[0] = "babbeh";
                                                        OtherFluffy.Message("nuuu! nu gib bad upsies! <name0> tu widdwe!", Names, Subs, null);
                                                    }
                                                    OtherFluffy.PlaySound("scree", true);
                                                    OtherFluffy.FluffyEvent(0, 0, null, 5, "Stand", 2, 4, false);
                                                }
                                                OtherFluffy.Mood -= 20;
                                            }
                                            else
                                            {
                                                if (OtherFluffy.Needs.IsCannibal == false)
                                                {
                                                    if (OtherFluffy.Needs.Morality > 40)
                                                    {
                                                        OtherFluffy.PlaySound("scaredtalk", true);
                                                        string[] Names = new string[1];
                                                        Names[0] = Needs.Name;
                                                        string[] Subs = new string[1];
                                                        Subs[0] = "babbeh";
                                                        OtherFluffy.Message("nu! <name0> tu widdwe fow upsies!", Names, Subs, null);
                                                        OtherFluffy.FluffyEvent(0, 0, null, 1, "Stand", 2, 3, false);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            Mood -= (collision.relativeVelocity.magnitude * 2) - 5;
                            PlaySound("ow", true);
                            FluffyEvent(0, 0, null, 0, "Lay", 2, 9, false);
                            Message("CHIRP!", null, null, null);
                        }
                        else
                        {
                            PlaySound("oof", true);
                            Message("cheep!", null, null, null);
                        }
                    }
                    Mood = Mathf.Clamp(Mood, 0, 100);
                }
            }
        }
    }

    //The owner of the script impregnates the specified fluffy. See Mate for the actual enfing.
    void SpecialHuggies(GameObject Fluffy, bool Submissive)
    {
        FluffyVariables OtherNeeds = Fluffy.GetComponent<FluffyVariables>();
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        Fluffy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        transform.position = new Vector3(Fluffy.transform.position.x - 1, transform.position.y, 0);
        if (OtherNeeds.Pregnant == false)
        {
            FluffyVariables Genes = Fluffy.AddComponent<FluffyVariables>();
            Genes.RaceGenes = Needs.RaceGenes;
            Genes.AlicornGenes = Needs.AlicornGenes;
            Genes.BaseGenes = Needs.BaseGenes;
            Genes.ManeGenes = Needs.ManeGenes;
            Genes.EyeGenes = Needs.EyeGenes;
            Genes.HairGenes = Needs.HairGenes;
            Genes.SizeGenes = Needs.SizeGenes;
            Genes.transform.parent = OtherNeeds.transform.parent;
            OtherNeeds.FatherGenes = Genes;
        }
        Relationship Bond;
        Bond = new Relationship
        {
            FluffyID = Fluffy.GetComponent<FluffyVariables>().ID,
            Fluffy = Fluffy,
            Lust = 10,
        };
        Fluffy.GetComponent<FluffyScript>().SetRelationship(Bond, false);
        //if a fluffy was just raped, call attention to the rapist
        if (OtherNeeds.Age < 200)
        {
            GameObject[] Results = GameObject.FindGameObjectsWithTag("Fluffy");
            float Distance = 10;
            foreach (GameObject hit in Results)
            {
                if ((hit.transform.position - transform.position).magnitude < Distance)
                {
                    FluffyScript OtherFluffy = hit.GetComponent<FluffyScript>();
                    OtherFluffy.AffectPersonality(-3, 0, 0, -2);
                    if (!Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(hit.transform.position.x, hit.transform.position.y), LayerMask.GetMask("Map")))
                    {
                        if (hit != gameObject && hit != Fluffy && OtherFluffy.Needs.Age > 200)
                        {
                            OtherFluffy.Mood -= 40;

                            if (OtherFluffy.Needs.Age > 500)
                            {
                                if (OtherFluffy.Needs.Morality >= 30)
                                {
                                    OtherFluffy.PlaySound("angrytalk", true);
                                    OtherFluffy.Message("YU GIB FOWEBA SWEEPIES TU WIDDWE BABBEH! SCREEEEEE!", null, null, null);
                                    OtherFluffy.FluffyEvent(3, 4, gameObject, 5, "Run", 4, 6, false);
                                    Bond = new Relationship
                                    {
                                        FluffyID = Needs.ID,
                                        Fluffy = gameObject,
                                        Love = -75,
                                        Lust = -75,
                                        Anger = 75,
                                        Fear = 20,
                                        Protectiveness = -75,
                                        Admiration = -75
                                    };
                                    OtherFluffy.SetRelationship(Bond, false);
                                }
                            }
                            else
                            {
                                OtherFluffy.PlaySound("scaredtalk", true);
                                OtherFluffy.Message("<name> nu wike dis! MUMMAH!", null, null, "fwuffy");
                                OtherFluffy.FluffyEvent(4, 0, gameObject, 5, "Run", 4, 4, false);
                                Bond = new Relationship
                                {
                                    FluffyID = Needs.ID,
                                    Fluffy = gameObject,
                                    Love = -50,
                                    Anger = 20,
                                    Fear = 75,
                                    Protectiveness = -50,
                                    Admiration = -50
                                };
                                OtherFluffy.SetRelationship(Bond, false);
                            }
                            Bond = new Relationship
                            {
                                FluffyID = Fluffy.GetComponent<FluffyVariables>().ID,
                                Fluffy = Fluffy,
                                IsDeceased = true
                            };
                            OtherFluffy.SetRelationship(Bond, true);
                        }
                    }
                    else
                    {
                        if (OtherFluffy.Needs.Age > 200)
                        {
                            if (!OtherFluffy.Needs.NoEarR || !OtherFluffy.Needs.NoEarL)
                            {
                                OtherFluffy.Mood -= 5;
                                OtherFluffy.PlaySound("sadtalk", true);
                                OtherFluffy.FluffyEvent(0, 0, null, 1, "Stand", 2, 3, false);
                                OtherFluffy.Message("scawy noisie!", null, null, null);
                            }
                        }
                    }
                }
            }
        }
        else if (OtherNeeds.SexDrive < 60)
        {
            Bond = new Relationship
            {
                FluffyID = Needs.ID,
                Fluffy = gameObject,
                Love = -60,
                Lust = -100,
                Anger = 40,
                Fear = 100,
                Protectiveness = -60,
                Admiration = -60
            };
            Fluffy.GetComponent<FluffyScript>().SetRelationship(Bond, false);
            GameObject[] Results = GameObject.FindGameObjectsWithTag("Fluffy");
            float Distance = 30;
            foreach (GameObject hit in Results)
            {
                if ((hit.transform.position - transform.position).magnitude < Distance)
                {
                    FluffyScript OtherFluffy = hit.GetComponent<FluffyScript>();
                    OtherFluffy.AffectPersonality(-2, 0, 0, 2);
                    if (!Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(hit.transform.position.x, hit.transform.position.y), LayerMask.GetMask("Map")))
                    {
                        if (hit != gameObject && hit != Fluffy && OtherFluffy.Needs.Age > 200)
                        {
                            if (OtherFluffy.Needs.Age > 500)
                            {
                                OtherFluffy.Mood -= 30;
                                if (OtherFluffy.Needs.Morality >= 60)
                                {
                                    OtherFluffy.PlaySound("angrytalk", true);
                                    string[] Names = new string[1];
                                    Names[0] = Needs.Name;
                                    string[] Subs = new string[1];
                                    Subs[0] = "YU";
                                    OtherFluffy.Message("<NAME0> BAD FWUFFY! NU GIB BAD SPESHUW HUGGIES!", Names, Subs, null);
                                    OtherFluffy.FluffyEvent(3, 4, gameObject, 5, "Run", 4, 6, false);
                                    Bond = new Relationship
                                    {
                                        FluffyID = Needs.ID,
                                        Fluffy = gameObject,
                                        Love = -60,
                                        Lust = -60,
                                        Anger = 60,
                                        Fear = 10,
                                        Protectiveness = -60,
                                        Admiration = -60
                                    };
                                    OtherFluffy.SetRelationship(Bond, false);
                                }
                            }
                            else
                            {
                                OtherFluffy.PlaySound("scaredtalk", true);
                                OtherFluffy.Message("<name> nu wike dis! MUMMAH!", null, null, "fwuffy");
                                Bond = new Relationship
                                {
                                    FluffyID = Needs.ID,
                                    Fluffy = gameObject,
                                    Love = -45,
                                    Anger = 15,
                                    Fear = 70,
                                    Protectiveness = -45,
                                    Admiration = -45
                                };
                                OtherFluffy.SetRelationship(Bond, false);
                                OtherFluffy.FluffyEvent(4, 0, gameObject, 5, "Run", 4, 4, false);
                            }
                        }
                    }
                    else
                    {
                        if (OtherFluffy.Needs.Age > 200)
                        {
                            if (!OtherFluffy.Needs.NoEarR || !OtherFluffy.Needs.NoEarL)
                            {
                                OtherFluffy.Mood -= 5;
                                OtherFluffy.PlaySound("sadtalk", true);
                                OtherFluffy.FluffyEvent(0, 0, null, 1, "Stand", 2, 3, false);
                                OtherFluffy.Message("scawy noisie!", null, null, null);
                            }
                        }
                    }
                }
            }
        }
        else
        {
            Bond = new Relationship
            {
                FluffyID = Needs.ID,
                Fluffy = gameObject,
                Love = 10,
                Lust = 10,
                Anger = -20,
                Fear = -30,
                Admiration = 20
            };
            Fluffy.GetComponent<FluffyScript>().SetRelationship(Bond, false);
        }
        if (Needs.Race == 3 && !Needs.NoHorn && !Needs.NoWings)
        {
            Fluffy.GetComponent<FluffyScript>().Mate(true, Submissive);
        }
        else
        {
            Fluffy.GetComponent<FluffyScript>().Mate(false, Submissive);
        }
        Mate(false, false);
    }

    #endregion

    #region Doesn't Affect Bystanders
    public void Eat(GameObject Food)
    {
        Food.GetComponent<FoodScript>().Eat(gameObject);
        if (Food.CompareTag("Corpse"))
        {
            Needs.Cannibalism += 10 - (8 * (Needs.Morality * 0.01f));
            Needs.Cannibalism = Mathf.Clamp(Needs.Cannibalism, 0, 100);
            if (Needs.Cannibalism == 100)
            {
                Needs.IsCannibal = true;
            }
        }
        else
        {
            Needs.Cannibalism -= 2 + (8 * (Needs.Morality * 0.01f));
            Needs.Cannibalism = Mathf.Clamp(Needs.Cannibalism, 0, 100);
            if (Needs.Cannibalism == 0)
            {
                Needs.IsCannibal = false;
            }
        }
    }

    public void HitAction(GameObject Fluffy)
    {
        if (!Needs.NoFrontLegR || !Needs.NoFrontLegL)
        {
            Fluffy.GetComponent<FluffyScript>().PlaySound("hurt", false);
            if (Fluffy.GetComponent<FluffyVariables>().Age > 200)
            {
                Fluffy.GetComponent<FluffyScript>().FluffyEvent(4, 0, gameObject, 5, "Run", 4, 3, false);
                Fluffy.GetComponent<FluffyScript>().Message("eeeee!", null, null, null);
                Fluffy.GetComponent<FluffyScript>().PlaySound("ow", true);
                Fluffy.GetComponent<FluffyScript>().Mood -= 10;
                Fluffy.GetComponent<FluffyVariables>().Health -= 10;
                Fluffy.GetComponent<FluffyScript>().AffectPersonality(2, 0, 0, 0);
            }
            else
            {
                Fluffy.GetComponent<FluffyScript>().FluffyEvent(4, 0, gameObject, 5, "Crawl", 1, 10, false);
                Fluffy.GetComponent<FluffyScript>().Message("SPEEEEEE!", null, null, null);
                Fluffy.GetComponent<FluffyScript>().PlaySound("scree", true);
                Fluffy.GetComponent<FluffyScript>().Mood -= 30;
                Fluffy.GetComponent<FluffyVariables>().Health -= 30;
            }
            Fluffy.GetComponent<FluffyScript>().Bleed();
            Relationship Bond = new Relationship
            {
                FluffyID = Needs.ID,
                Fluffy = gameObject,
                Love = -10,
                Fear = 15,
            };
            Fluffy.GetComponent<FluffyScript>().SetRelationship(Bond, false);
        }
    }

    //The owner of the script tries to nurse from the specified fluffy.
    void Nurse(GameObject Fluffy)
    {
        Relationship Bond;
        if (Fluffy.GetComponent<FluffyVariables>().Sexuality >= 70 && Fluffy.GetComponent<FluffyVariables>().Morality <= 20)
        {
            Fluffy.GetComponent<FluffyScript>().PlaySound("scree", true);
            Fluffy.GetComponent<FluffyScript>().Message("NUUUU! GU 'WAY! <NAME> NU GON' BE MUMMAH!", null, null, "FWUFFY");
            if (Fluffy.GetComponent<FluffyVariables>().NoFrontLegR && Fluffy.GetComponent<FluffyVariables>().NoFrontLegL)
            {
                Suckle(Fluffy);
            } else
            {
                Fluffy.GetComponent<FluffyScript>().HitAction(gameObject);
            }
            } else {
            if (Needs.Race == 3 && Fluffy.GetComponent<FluffyVariables>().Race != 3 && !Fluffy.GetComponent<FluffyVariables>().NoEyes && !Needs.NoHorn && !Needs.NoWings)
            {
                Fluffy.GetComponent<FluffyScript>().PlaySound("scree", true);
                Fluffy.GetComponent<FluffyScript>().Message("MUNSTAH BABBEH! SCREEEEEEE!", null, null, null);
                if (!Fluffy.GetComponent<FluffyVariables>().NoFrontLegR || !Fluffy.GetComponent<FluffyVariables>().NoFrontLegL)
                {
                    Fluffy.GetComponent<FluffyScript>().HitAction(gameObject);
                }
                else
                {
                    Suckle(Fluffy);
                    AffectPersonality(-5, 0, 0, 0);
                }
            }
            else
            {
                if (Fluffy.GetComponent<FluffyScript>().GetRelationship(Needs.ID).IsChild == true || Needs.NoEyes)
                {
                    if (Fluffy.GetComponent<FluffyVariables>().Milk > 20)
                    {
                        Fluffy.GetComponent<FluffyScript>().PlaySound("sing", true);
                        Fluffy.GetComponent<FluffyScript>().Message("babbeh dwink miwkies, gwow up big an' stwong...", null, null, null);
                        Suckle(Fluffy);
                    }
                    else
                    {
                        Fluffy.GetComponent<FluffyScript>().PlaySound("sadtalk", true);
                        Fluffy.GetComponent<FluffyScript>().Message("<name> nu hab miwkies fow widdwe babbeh... huu huu huu...", null, null, "mummah");
                    }

                    Suckle(Fluffy);
                    Bond = new Relationship
                    {
                        FluffyID = Needs.ID,
                        Fluffy = gameObject,
                        Protectiveness = 20,
                        Love = 20,
                    };
                    Fluffy.GetComponent<FluffyScript>().SetRelationship(Bond, false);
                    #region Big Fucking Pile of Nothing
                    int Morality = 0;
                    int Decency = 0;
                    int Cannibalism = 0;
                    int Sexuality = 0;

                    if (Fluffy.GetComponent<FluffyScript>().Needs.Morality > Needs.Morality)
                    {
                        Morality = 3;
                    }
                    else if (Fluffy.GetComponent<FluffyScript>().Needs.Morality < Needs.Morality)
                    {
                        Morality = -3;
                    }

                    if (Fluffy.GetComponent<FluffyScript>().Needs.Decency > Needs.Decency)
                    {
                        Decency = 3;
                    }
                    else if (Fluffy.GetComponent<FluffyScript>().Needs.Decency < Needs.Decency)
                    {
                        Decency = -3;
                    }

                    if (Fluffy.GetComponent<FluffyScript>().Needs.Cannibalism > Needs.Cannibalism)
                    {
                        Cannibalism = 3;
                    }
                    else if (Fluffy.GetComponent<FluffyScript>().Needs.Cannibalism < Needs.Cannibalism)
                    {
                        Cannibalism = -3;
                    }

                    if (Needs.Sexuality > Fluffy.GetComponent<FluffyScript>().Needs.Sexuality)
                    {
                        Sexuality = 3;
                    }
                    else if (Needs.Sexuality < Fluffy.GetComponent<FluffyScript>().Needs.Sexuality)
                    {
                        Sexuality = -3;
                    }

                    AffectPersonality(Morality, Decency, Cannibalism, Sexuality);
                    #endregion

                }
                else
                {
                    if (GetRelationship(Fluffy.GetComponent<FluffyVariables>().ID).Fear >= 50)
                    {
                        PlaySound("scaredtalk", true);
                        Message("chirp! chirp! *shiver*", null, null, null);
                    }
                    else
                    {
                        if (Fluffy.GetComponent<FluffyVariables>().Morality > 40)
                        {
                            Fluffy.GetComponent<FluffyScript>().PlaySound("sadtalk", true);
                            if (Fluffy.GetComponent<FluffyVariables>().Milk > 20)
                            {
                                Fluffy.GetComponent<FluffyScript>().Message("yu wost, widdwe babbeh? <name> hab miwkies fow yu...", null, null, "fwuffy");
                                Suckle(Fluffy);
                            }
                            else
                            {
                                Fluffy.GetComponent<FluffyScript>().Message("yu wost, widdwe babbeh? <name> can keep yu wawmies...", null, null, "fwuffy");
                            }
                            Bond = new Relationship
                            {
                                FluffyID = Needs.ID,
                                Fluffy = gameObject,
                                Protectiveness = 20,
                                Love = 20
                            };
                            if (Fluffy.GetComponent<FluffyScript>().GetRelationship(Needs.ID).Love >= 20)
                            {
                                Bond.IsChild = true;
                            }
                            Fluffy.GetComponent<FluffyScript>().SetRelationship(Bond, true);
                        }
                        else
                        {
                            if (Fluffy.GetComponent<FluffyVariables>().NoFrontLegR && Fluffy.GetComponent<FluffyVariables>().NoFrontLegL)
                            {
                                Suckle(Fluffy);
                                Fluffy.GetComponent<FluffyScript>().PlaySound("scree", true);
                                Fluffy.GetComponent<FluffyScript>().Message("NUUUUU! GU 'WAY! SCREEEEEEE!", null, null, null);
                                Bond = new Relationship
                                {
                                    FluffyID = Needs.ID,
                                    Fluffy = gameObject,
                                    Love = -20,
                                    Anger = 20,
                                    Fear = 5
                                };
                                Fluffy.GetComponent<FluffyScript>().SetRelationship(Bond, false);
                                AffectPersonality(-5, 0, 0, 0);
                            }
                            else
                            {
                                Fluffy.GetComponent<FluffyScript>().PlaySound("angrytalk", true);
                                if (Fluffy.GetComponent<FluffyScript>().GetRelationship(Needs.ID).Anger >= 20)
                                {
                                    Fluffy.GetComponent<FluffyScript>().Message("<name> said GU 'WAY!", null, null, "fwuffy");
                                    Fluffy.GetComponent<FluffyScript>().HitAction(gameObject);
                                }
                                else
                                {
                                    if (Fluffy.GetComponent<FluffyVariables>().Lactating == true)
                                    {
                                        Fluffy.GetComponent<FluffyScript>().Message("gu 'way, dummeh babbeh! miwkies am fow <name>'s babbehs!", null, null, "fwuffy");
                                    }
                                    else
                                    {
                                        Fluffy.GetComponent<FluffyScript>().Message("gu 'way, dummeh babbeh! nu hab miwkies fow yu!", null, null, null);
                                    }
                                    Bond = new Relationship
                                    {
                                        FluffyID = Fluffy.GetComponent<FluffyVariables>().ID,
                                        Fluffy = Fluffy,
                                        Love = -10,
                                        Fear = 15,
                                    };
                                    SetRelationship(Bond, false);
                                }
                                Bond = new Relationship
                                {
                                    FluffyID = Needs.ID,
                                    Fluffy = gameObject,
                                    Love = -20,
                                    Anger = 20,
                                };
                                Fluffy.GetComponent<FluffyScript>().SetRelationship(Bond, false);
                            }
                        }
                    }
                }
            }
        }

    }

    //This is where the fluffy actually drinks milk. Successful Nurse attempts lead here.
    void Suckle(GameObject Fluffy)
    {
        if (Fluffy.GetComponent<FluffyVariables>().Milk >= 20)
        {
            FluffyEvent(0, 0, null, 1, "Lay", 2, 8, false);
            Fluffy.GetComponent<FluffyVariables>().Milk -= 20;
            Needs.Hunger -= 60;
            Relationship Bond = new Relationship
            {
                FluffyID = Fluffy.GetComponent<FluffyVariables>().ID,
                Fluffy = Fluffy,
                Love = 25,
                Admiration = 25,
                Fear = -25,
                Anger = -10,
                LastSeen = Fluffy.transform.position,
                IsParent = true
            };
            SetRelationship(Bond, true);
            if (Fluffy.GetComponent<FluffyVariables>().IsCannibal == true)
            {
                Needs.Cannibalism += 50 * (Fluffy.GetComponent<FluffyVariables>().Cannibalism / 100);
            }
            else
            {
                Needs.Cannibalism -= 50 - (50 * (Fluffy.GetComponent<FluffyVariables>().Cannibalism / 100));
            }
            Needs.Cannibalism = Mathf.Clamp(Needs.Cannibalism, 0, 100);
            if (Needs.Cannibalism == 100)
            {
                Needs.IsCannibal = true;
            }
        }
        else
        {
            FluffyEvent(0, 0, null, 1, "Lay", 2, 9, false);
        }
    }

    //The owner of the script has a short conversation with the specified fluffy.
    public IEnumerator Converse(FluffyScript Fluffy)
    {
        string[] Names = new string[1];
        string[] Subs = new string[1];
        Names[0] = Fluffy.Needs.Name;
        if (Needs.Race == 3 && Fluffy.Needs.Race != 3 && !Fluffy.Needs.NoEyes && !Needs.NoHorn && !Needs.NoWings)
        {
            Fluffy.FluffyEvent(4, 0, gameObject, 5, "Run", 4, 4, false);
            Fluffy.Mood -= 20;
            Fluffy.PlaySound("scree", true);
            Fluffy.Message("MUNSTAH FWUFFY! SCREEEEE!", null, null, null);
        }
        else if (Needs.Race != 3 && Fluffy.Needs.Race == 3 && !Needs.NoEyes && !Fluffy.Needs.NoHorn && !Fluffy.Needs.NoWings)
        {
            FluffyEvent(4, 0, Fluffy.gameObject, 5, "Run", 4, 4, false);
            Mood -= 20;
            PlaySound("scree", true);
            Message("MUNSTAH FWUFFY! SCREEEEE!", null, null, null);
        }
        else
        {
            Fluffy.FluffyEvent(0, 0, null, 5, "Stand", 2, 0, false);
            Relationship Bond;
            int Type;
            if (GetRelationship(Fluffy.Needs.ID).FluffyID == -1)
            {
                PlaySound("happytalk", true);
                Message("nyu fwend?", null, null, null);
                Type = 3;
            }
            else
            {
                //type 0 = greeting
                //type 1 = proposal
                //type 2 = breakup
                //type 3 = first meeting
                //type 4 = soliciting
                if (Needs.Sex == 0 && !GetRelationship(Fluffy.Needs.ID).IsSpecialFriend && GetRelationship(Fluffy.Needs.ID).Lust > 50 && GetRelationship(Fluffy.Needs.ID).Love > 50)
                {
                    Type = 1;
                    PlaySound("happytalk", true);
                    Message("<name> wan' be yu speshuw fwend!", null, null, "fwuffy");
                }
                else if (GetRelationship(Fluffy.Needs.ID).IsSpecialFriend && (GetRelationship(Fluffy.Needs.ID).Lust < 50 || GetRelationship(Fluffy.Needs.ID).Love < 50))
                {
                    Type = 2;
                    PlaySound("sadtalk", true);
                    Message("nu wan' be yu speshuw fwend nu mowe!", null, null, null);
                }
                else if (Needs.Sex == 0 && Fluffy.Needs.Sex == 1 && (GetRelationship(Fluffy.Needs.ID).IsSpecialFriend || Needs.Decency < 30) && Needs.SexDrive > 60)
                {
                    Type = 4;
                    PlaySound("happytalk", true);
                    Message("<name> wan' speshuw huggies wif yu!", null, null, "fwuffy");
                }
                else
                {
                    Type = 0;
                    PlaySound("happytalk", true);
                    if (Needs.Decency < 50)
                    {
                        Message("hi!", null, null, null);
                    }
                    else
                    {
                        if (GetRelationship(Fluffy.Needs.ID).IsSpecialFriend)
                        {
                            Subs[0] = "speshuw fwend";
                            Message("hi, <name0>!", Names, Subs, null);
                        }
                        else if (GetRelationship(Fluffy.Needs.ID).Lust > 50 && GetRelationship(Fluffy.Needs.ID).Love < 50)
                        {
                            Subs[0] = "enfie fwend";
                            Message("hi, <name0>!", Names, Subs, null);
                        }
                        else if (GetRelationship(Fluffy.Needs.ID).IsChild)
                        {
                            Subs[0] = "babbeh";
                            Message("hi, <name0>!", Names, Subs, null);
                        }
                        else if (GetRelationship(Fluffy.Needs.ID).IsParent)
                        {
                            if (Fluffy.Needs.Sex == 0)
                            {
                                Message("hi, daddeh!", null, null, null);
                            }
                            else
                            {
                                Message("hi, mummah!", null, null, null);
                            }
                        }
                        else if (GetRelationship(Fluffy.Needs.ID).Love >= 80)
                        {
                            Subs[0] = "bestest fwend";
                            Message("hi, <name0>!", Names, Subs, null);
                        }
                        else
                        {
                            Subs[0] = "fwend";
                            Message("hi, <name0>!", Names, Subs, null);
                        }
                    }
                }
            }
            yield return new WaitForSeconds(1);
            if (!Fluffy.Needs.NoEarR || !Fluffy.Needs.NoEarL)
            {
                Names[0] = Needs.Name;
                if (Type == 4)
                {
                    //Rapey submissive response.
                    if (Fluffy.GetRelationship(Needs.ID).Submission > 50 && Fluffy.GetRelationship(Needs.ID).Fear > 40)
                    {
                        Fluffy.PlaySound("sadtalk", true);
                        Fluffy.Message("o-otay...", null, null, null);
                        Fluffy.FluffyEvent(0, 0, null, 5, "Lay", 2, 3, false);
                        FluffyEvent(3, 3, Fluffy.gameObject, 5, "Run", 4, 0, false);
                    }
                    else
                    {
                        bool Rejected = false;
                        if (Fluffy.GetRelationship(Needs.ID).Love < 30 && Fluffy.Needs.Decency > 50)
                        {
                            Fluffy.PlaySound("sadtalk", true);
                            Fluffy.Message("eww! <name> nu knu yu!", null, null, "fwuffy");
                            Rejected = true;
                        }
                        else if (!Fluffy.GetRelationship(Needs.ID).IsSpecialFriend && Fluffy.Needs.Decency > 30)
                        {
                            Fluffy.PlaySound("sadtalk", true);
                            Fluffy.Message("yu nu am speshuw-fwend...", null, null, null);
                            Rejected = true;
                        }
                        else if (Fluffy.Needs.SexDrive < 60)
                        {
                            Fluffy.PlaySound("sadtalk", true);
                            Fluffy.Message("nu wite nao, maybe watew...", null, null, null);
                            Rejected = true;
                        }
                        else
                        {
                            Fluffy.PlaySound("happytalk", true);
                            Fluffy.Message("otay!", null, null, null);
                            FluffyEvent(3, 3, Fluffy.gameObject, 5, "Run", 4, 0, false);
                        }
                        if (Rejected)
                        {
                            yield return new WaitForSeconds(1);
                            if (Needs.Morality > 30)
                            {
                                PlaySound("happytalk", true);
                                Message("otay, <name> unnastand!", null, null, "fwuffy");
                            }
                            else
                            {
                                Needs.SexDrive = 60;
                                Fluffy.Needs.SexDrive = 0;
                                PlaySound("angrytalk", true);
                                Subs[0] = "ENFIE MAWE";
                                Message("<NAME> NU SAY DUMMEH <NAME0> CAN SAY NU!", Names, Subs, "FWUFFY");
                                FluffyEvent(3, 3, Fluffy.gameObject, 5, "Run", 4, 6, false);
                                Fluffy.FluffyEvent(4, 0, gameObject, 5, "Run", 4, 4, false);
                                Fluffy.PlaySound("scree", true);
                                Fluffy.Message("EEEEEEE!", null, null, null);
                                Bond = new Relationship
                                {
                                    FluffyID = Needs.ID,
                                    Submission = 10
                                };
                                Fluffy.SetRelationship(Bond, true);
                            }
                        }
                    }
                }
                else if (Type == 1)
                {
                    if (Fluffy.GetRelationship(Needs.ID).Lust > 50 && Fluffy.GetRelationship(Needs.ID).Love > 50)
                    {
                        Fluffy.PlaySound("happytalk", true);
                        Fluffy.Message("yaaaay!", null, null, null);
                        Fluffy.SpawnParticle("Heart Particle");
                        Needs.SexDrive = 60;
                        Fluffy.Needs.SexDrive = 60;
                        FluffyEvent(3, 3, Fluffy.gameObject, 5, "Run", 4, 2, false);
                        Bond = new Relationship
                        {
                            FluffyID = Needs.ID,
                            Fluffy = gameObject,
                            IsSpecialFriend = true
                        };
                        Fluffy.SetRelationship(Bond, true);
                        Bond = new Relationship
                        {
                            FluffyID = Fluffy.Needs.ID,
                            Fluffy = Fluffy.gameObject,
                            IsSpecialFriend = true
                        };
                        SetRelationship(Bond, true);
                    }
                    else
                    {
                        Fluffy.PlaySound("sadtalk", true);
                        Fluffy.Message("nu, sowwy...", null, null, null);
                        Fluffy.FluffyEvent(0, 0, null, 5, "Stand", 2, 3, false);
                        if (Needs.Morality > 40)
                        {
                            Bond = new Relationship
                            {
                                FluffyID = Fluffy.Needs.ID,
                                Fluffy = Fluffy.gameObject,
                                Lust = -30
                            };
                            SetRelationship(Bond, false);
                        }
                        else
                        {
                            Needs.SexDrive = 60;
                            Fluffy.Needs.SexDrive = 0;
                            PlaySound("angrytalk", true);
                            Subs[0] = "ENFIE MAWE";
                            Message("DUMMEH <NAME0> AM SPESHUW ENFIE FWEND!", Names, Subs, "FWUFFY");
                            FluffyEvent(3, 3, Fluffy.gameObject, 5, "Run", 4, 6, false);
                            Bond = new Relationship
                            {
                                FluffyID = Needs.ID,
                                Fluffy = gameObject,
                                IsSpecialFriend = true,
                                Submission = 10
                            };
                            Fluffy.SetRelationship(Bond, true);
                            Bond = new Relationship
                            {
                                FluffyID = Fluffy.Needs.ID,
                                Fluffy = Fluffy.gameObject,
                                IsSpecialFriend = true
                            };
                            SetRelationship(Bond, true);
                            Fluffy.FluffyEvent(4, 0, gameObject, 5, "Run", 4, 4, false);
                            Fluffy.PlaySound("scree", true);
                            Fluffy.Message("EEEEEEE!", null, null, null);
                        }
                    }
                }
                else if (Type == 2)
                {
                    if (Fluffy.GetRelationship(Fluffy.Needs.ID).IsSpecialFriend && (Fluffy.GetRelationship(Fluffy.Needs.ID).Lust < 50 || Fluffy.GetRelationship(Fluffy.Needs.ID).Love < 50))
                    {
                        Fluffy.PlaySound("happytalk", true);
                        Fluffy.Message("can stiww be not-speshuw fwend?", null, null, null);
                        Fluffy.FluffyEvent(0, 0, null, 5, "Stand", 2, 0, false);
                        Bond = new Relationship
                        {
                            FluffyID = Needs.ID,
                            Fluffy = gameObject,
                            Lust = -50,
                            IsSpecialFriend = false
                        };
                        Fluffy.SetRelationship(Bond, true);
                        Bond = new Relationship
                        {
                            FluffyID = Fluffy.Needs.ID,
                            Fluffy = Fluffy.gameObject,
                            Lust = -50,
                            IsSpecialFriend = false
                        };
                        SetRelationship(Bond, true);
                    }
                    else
                    {
                        if (Fluffy.Needs.Morality >= 40 || Fluffy.Needs.Sex == 1)
                        {
                            Fluffy.PlaySound("scree", true);
                            Fluffy.Message("NUUUU! HUU HUU HUU!", null, null, null);
                            Bond = new Relationship
                            {
                                FluffyID = Needs.ID,
                                Fluffy = gameObject,
                                Lust = -50,
                                IsSpecialFriend = false
                            };
                            Fluffy.SetRelationship(Bond, true);
                            Bond = new Relationship
                            {
                                FluffyID = Fluffy.Needs.ID,
                                Fluffy = Fluffy.gameObject,
                                Lust = -50,
                                IsSpecialFriend = false
                            };
                            SetRelationship(Bond, true);
                        }
                        else if (Fluffy.Needs.Sex == 0)
                        {
                            Needs.SexDrive = 0;
                            Fluffy.Needs.SexDrive = 60;
                            Fluffy.PlaySound("angrytalk", true);
                            Subs[0] = "DUMMEH MAWE";
                            Fluffy.Message("<NAME0> AM SPESHUW ENFIE FWEND AN' NU CAN SAY NU!", Names, Subs, null);
                            Fluffy.FluffyEvent(3, 3, Fluffy.gameObject, 5, "Run", 4, 6, false);
                            FluffyEvent(4, 0, Fluffy.gameObject, 5, "Run", 4, 4, false);
                            PlaySound("scree", true);
                            Message("EEEEEEE!", null, null, null);
                            Bond = new Relationship
                            {
                                FluffyID = Fluffy.Needs.ID,
                                Submission = 10
                            };
                            SetRelationship(Bond, true);
                        }
                    }
                }
                else if (Type == 3)
                {
                    Fluffy.PlaySound("happytalk", true);
                    Fluffy.Message("yay!", null, null, null);
                    Fluffy.SpawnParticle("Heart Particle");
                    if (Needs.Sex != Fluffy.Needs.Sex && Needs.Age >= 600 && Fluffy.Needs.Age >= 600)
                    {
                        Bond = new Relationship
                        {
                            FluffyID = Needs.ID,
                            Fluffy = gameObject,
                            Love = 10,
                            Lust = 5
                        };
                        Fluffy.SetRelationship(Bond, false);
                        Bond = new Relationship
                        {
                            FluffyID = Fluffy.Needs.ID,
                            Fluffy = Fluffy.gameObject,
                            Love = 10,
                            Lust = 5
                        };
                        SetRelationship(Bond, false);
                    }
                    else
                    {
                        Bond = new Relationship
                        {
                            FluffyID = Needs.ID,
                            Fluffy = gameObject,
                            Love = 10
                        };
                        Fluffy.SetRelationship(Bond, false);
                        Bond = new Relationship
                        {
                            FluffyID = Fluffy.Needs.ID,
                            Fluffy = Fluffy.gameObject,
                            Love = 10,
                        };
                        SetRelationship(Bond, false);
                    }
                }
                else if (Type == 0)
                {

                    #region Big Fucking Pile of Nothing
                    int Morality = 0;
                    int Decency = 0;
                    int Cannibalism = 0;
                    int Sexuality = 0;

                    if (Fluffy.Needs.Morality > Needs.Morality)
                    {
                        Morality = 1;
                    }
                    else if (Fluffy.Needs.Morality < Needs.Morality)
                    {
                        Morality = -1;
                    }

                    if (Fluffy.Needs.Decency > Needs.Decency)
                    {
                        Decency = 1;
                    }
                    else if (Fluffy.Needs.Decency < Needs.Decency)
                    {
                        Decency = -1;
                    }

                    if (Fluffy.Needs.Cannibalism > Needs.Cannibalism)
                    {
                        Cannibalism = 1;
                    }
                    else if (Fluffy.Needs.Cannibalism < Needs.Cannibalism)
                    {
                        Cannibalism = -1;
                    }

                    if (Needs.Sexuality > Fluffy.Needs.Sexuality)
                    {
                        Sexuality = 1;
                    }
                    else if (Needs.Sexuality < Fluffy.Needs.Sexuality)
                    {
                        Sexuality = -1;
                    }

                    AffectPersonality(Morality, Decency, Cannibalism, Sexuality);

                    Morality = 0;
                    Decency = 0;
                    Cannibalism = 0;
                    Sexuality = 0;

                    if (Needs.Morality > Fluffy.Needs.Morality)
                    {
                        Morality = 1;
                    }
                    else if (Needs.Morality < Fluffy.Needs.Morality)
                    {
                        Morality = -1;
                    }

                    if (Needs.Decency > Fluffy.Needs.Decency)
                    {
                        Decency = 1;
                    }
                    else if (Needs.Decency < Fluffy.Needs.Decency)
                    {
                        Decency = -1;
                    }

                    if (Needs.Cannibalism > Fluffy.Needs.Cannibalism)
                    {
                        Cannibalism = 1;
                    }
                    else if (Needs.Cannibalism < Fluffy.Needs.Cannibalism)
                    {
                        Cannibalism = -1;
                    }

                    if (Needs.Sexuality > Fluffy.Needs.Sexuality)
                    {
                        Sexuality = 1;
                    }
                    else if (Needs.Sexuality < Fluffy.Needs.Sexuality)
                    {
                        Sexuality = -1;
                    }

                    Fluffy.AffectPersonality(Morality, Decency, Cannibalism, Sexuality);
                    #endregion

                    //Rapey submissive response.
                    if (Fluffy.GetRelationship(Needs.ID).Submission > 30 && Fluffy.GetRelationship(Needs.ID).Fear > 20)
                    {
                        Fluffy.PlaySound("sadtalk", true);
                        Fluffy.Message("h-hi...", null, null, null);
                        Fluffy.FluffyEvent(0, 0, null, 5, "Stand", 2, 3, false);
                    }
                    else
                    {
                        if (Fluffy.GetRelationship(Needs.ID).Fear > 40)
                        {
                            Fluffy.PlaySound("scree", true);
                            Fluffy.Message("NUUUUU! SCREEEEEEEE!", null, null, null);
                            Fluffy.FluffyEvent(4, 0, gameObject, 5, "Run", 4, 4, false);
                            yield return new WaitForSeconds(1);
                            if (Needs.Morality < 50)
                            {
                                FluffyEvent(3, 4, Fluffy.gameObject, 5, "Run", 5, 4, false);
                                PlaySound("angrytalk", true);
                                Message("HEY! GET BACK HEWE!", null, null, null);
                                Bond = new Relationship
                                {
                                    FluffyID = Needs.ID,
                                    Fluffy = gameObject,
                                    Submission = 10
                                };
                                Fluffy.SetRelationship(Bond, true);
                            }
                            else
                            {
                                FluffyEvent(0, 0, null, 5, "Stand", 2, 3, false);
                                PlaySound("sadtalk", true);
                                Message("nuuu, <name> sowwy!", null, null, "fwuffy");
                                Bond = new Relationship
                                {
                                    FluffyID = Needs.ID,
                                    Fluffy = gameObject,
                                    Fear = -5
                                };
                                Fluffy.SetRelationship(Bond, true);
                            }
                        }
                        else if (Fluffy.GetRelationship(Needs.ID).Anger > 40)
                        {
                            Fluffy.PlaySound("angrytalk", true);
                            Fluffy.Message("gu 'way, dummeh! nu wike yu!", null, null, null);
                            Fluffy.FluffyEvent(3, 4, gameObject, 5, "Run", 4, 6, false);
                            Bond = new Relationship
                            {
                                FluffyID = Fluffy.Needs.ID,
                                Fluffy = Fluffy.gameObject,
                                Love = -10,
                                Fear = 10
                            };
                            SetRelationship(Bond, false);
                        }
                        else
                        {
                            Fluffy.FluffyEvent(0, 0, null, 5, "Stand", 2, 0, false);
                            Fluffy.PlaySound("happytalk", true);
                            Fluffy.SpawnParticle("Heart Particle");
                            if (Fluffy.Needs.Decency < 50)
                            {
                                Fluffy.Message("hi!", null, null, null);
                            }
                            else
                            {
                                if (Fluffy.GetRelationship(Needs.ID).IsSpecialFriend)
                                {
                                    Subs[0] = "speshuw fwend";
                                    Fluffy.Message("hi, <name0>!", Names, Subs, null);
                                }
                                else if (Fluffy.GetRelationship(Needs.ID).Lust > 50 && Fluffy.GetRelationship(Needs.ID).Love < 50)
                                {
                                    Subs[0] = "enfie fwend";
                                    Fluffy.Message("hi, <name0>!", Names, Subs, null);
                                }
                                else if (Fluffy.GetRelationship(Needs.ID).IsChild)
                                {
                                    Subs[0] = "babbeh";
                                    Fluffy.Message("hi, <name0>!", Names, Subs, null);
                                }
                                else if (Fluffy.GetRelationship(Needs.ID).IsParent)
                                {
                                    if (Needs.Sex == 0)
                                    {
                                        Fluffy.Message("hi, daddeh!", null, null, null);
                                    }
                                    else
                                    {
                                        Fluffy.Message("hi, mummah!", null, null, null);
                                    }
                                }
                                else if (Fluffy.GetRelationship(Needs.ID).Love >= 80)
                                {
                                    Subs[0] = "bestest fwend";
                                    Message("hi, <name0>!", Names, Subs, null);
                                }
                                else
                                {
                                    Subs[0] = "fwend";
                                    Fluffy.Message("hi, <name0>!", Names, Subs, null);
                                }
                            }
                            if (Needs.Sex != Fluffy.Needs.Sex && Needs.Age >= 600 && Fluffy.Needs.Age >= 600)
                            {
                                Bond = new Relationship
                                {
                                    FluffyID = Needs.ID,
                                    Fluffy = gameObject,
                                    Love = 10,
                                    Lust = 5
                                };
                                Fluffy.SetRelationship(Bond, false);
                                Bond = new Relationship
                                {
                                    FluffyID = Fluffy.Needs.ID,
                                    Fluffy = Fluffy.gameObject,
                                    Love = 10,
                                    Lust = 5
                                };
                                SetRelationship(Bond, false);
                            }
                            else
                            {
                                Bond = new Relationship
                                {
                                    FluffyID = Needs.ID,
                                    Fluffy = gameObject,
                                    Love = 10,
                                };
                                Fluffy.SetRelationship(Bond, false);
                                Bond = new Relationship
                                {
                                    FluffyID = Fluffy.Needs.ID,
                                    Fluffy = Fluffy.gameObject,
                                    Love = 10,
                                };
                                SetRelationship(Bond, false);
                            }
                        }
                    }
                }
                else
                {
                    Fluffy.PlaySound("sadtalk", true);
                    Fluffy.FluffyEvent(0, 0, null, 5, "Stand", 2, 3, false);
                    Fluffy.Message("<name> sowwy, nu can heaw yu! huu huu huu...", null, null, "fwuffy");
                }
            }
        }
    }
    #endregion
}