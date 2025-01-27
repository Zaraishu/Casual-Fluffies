using System.Collections.Generic;
using UnityEngine;

public class FluffyGeneticsLegacy : MonoBehaviour
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

    //get all the descendants of the target object, useful for setting colors within bullshit convoluted skeleton hierarchy
    void GetDescendants(GameObject Object, List<GameObject> Array)
    {
        foreach (Transform child in Object.transform)
        {
            Array.Add(child.gameObject);
            GetDescendants(child.gameObject, Array);
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
}
