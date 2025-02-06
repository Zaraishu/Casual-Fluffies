using System.Collections;
using UnityEngine;

// Formerly AnimEvents. Was probably used to animate different events, but only the birth was finished.
public class BirthEvent : MonoBehaviour {

    GameObject head;
    GameObject eye;
    GameObject shine;
    GameObject eyebrow;
    Sprite[] faceSprites;
    Sprite[] eyeSprites;
    Sprite[] shineSprites;
    Sprite[] eyebrowSprites;
    GameObject fluffyPrefab;
    GameObject newFoal;
    FluffyScript motherScript;
    FluffyVariables motherNeeds;

    private void Start()
    {
        motherScript = gameObject.transform.parent.GetComponent<FluffyScript>();
        motherNeeds = motherScript.Needs;
        faceSprites = Resources.LoadAll<Sprite>("face");
        eyeSprites = Resources.LoadAll<Sprite>("eye");
        shineSprites = Resources.LoadAll<Sprite>("shine");
        eyebrowSprites = Resources.LoadAll<Sprite>("eyebrows");
        head = motherScript.GetHead();
        eye = motherScript.GetEye();
        shine = motherScript.GetShine();
        eyebrow = motherScript.GetEyebrow();
        fluffyPrefab = (GameObject)Resources.Load("Fluffy");
    }

    public void SetFace(int Face)
    {
        head.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = (Sprite)faceSprites[Face];
        shine.GetComponent<SpriteRenderer>().sprite = (Sprite)shineSprites[Face];
        eyebrow.GetComponent<SpriteRenderer>().sprite = (Sprite)eyebrowSprites[Face];
        if (!motherNeeds.NoEyes)
        {
            eye.GetComponent<SpriteRenderer>().sprite = (Sprite)eyeSprites[Face];
        }
    }

    public IEnumerator GiveBirth()
    {
        newFoal = Instantiate(fluffyPrefab);
        FluffyScript foalScript = newFoal.GetComponent<FluffyScript>();

        int Race1;
        int Race2;
        //race
        if (Random.Range(0, 2) == 0)
        {
            Race1 = motherNeeds.RaceGenes[0];
        }
        else
        {
            Race1 = motherNeeds.RaceGenes[1];
        }
        if (Random.Range(0, 2) == 0)
        {
            Race2 = motherNeeds.FatherGenes.RaceGenes[0];
        }
        else
        {
            Race2 = motherNeeds.FatherGenes.RaceGenes[1];
        }
        foalScript.SetRace(Race1, Race2);

        bool Alicorn1;
        bool Alicorn2;
        //alicorn
        if (Random.Range(0, 2) == 0)
        {
            Alicorn1 = motherNeeds.AlicornGenes[0];
        }
        else
        {
            Alicorn1 = motherNeeds.AlicornGenes[1];
        }
        if (Random.Range(0, 2) == 0)
        {
            Alicorn2 = motherNeeds.FatherGenes.AlicornGenes[0];
        }
        else
        {
            Alicorn2 = motherNeeds.FatherGenes.AlicornGenes[1];
        }
        foalScript.SetAlicorn(Alicorn1, Alicorn2);

        float H1;
        float S1;
        float V1;
        float H2;
        float S2;
        float V2;
        float H;
        float S;
        float V;

        Color Color1;
        Color Color2;
        //base
        Color.RGBToHSV(motherNeeds.BaseGenes[0], out H1, out S1, out V1);
        Color.RGBToHSV(motherNeeds.BaseGenes[1], out H2, out S2, out V2);
        if (Random.Range(0, 2) == 0)
        {
            H = H1;
        }
        else
        {
            H = H2;
        }
        if (Random.Range(0, 2) == 0)
        {
            S = S1;
        }
        else
        {
            S = S2;
        }
        if (Random.Range(0, 2) == 0)
        {
            V = V1;
        }
        else
        {
            V = V2;
        }
        Color1 = Color.HSVToRGB(H, S, V);

        Color.RGBToHSV(motherNeeds.FatherGenes.BaseGenes[0], out H1, out S1, out V1);
        Color.RGBToHSV(motherNeeds.FatherGenes.BaseGenes[1], out H2, out S2, out V2);
        if (Random.Range(0, 2) == 0)
        {
            H = H1;
        }
        else
        {
            H = H2;
        }
        if (Random.Range(0, 2) == 0)
        {
            S = S1;
        }
        else
        {
            S = S2;
        }
        if (Random.Range(0, 2) == 0)
        {
            V = V1;
        }
        else
        {
            V = V2;
        }
        Color2 = Color.HSVToRGB(H, S, V);
        foalScript.SetBase(Color1, Color2);

        //mane
        Color.RGBToHSV(motherNeeds.ManeGenes[0], out H1, out S1, out V1);
        Color.RGBToHSV(motherNeeds.ManeGenes[1], out H2, out S2, out V2);
        if (Random.Range(0, 2) == 0)
        {
            H = H1;
        }
        else
        {
            H = H2;
        }
        if (Random.Range(0, 2) == 0)
        {
            S = S1;
        }
        else
        {
            S = S2;
        }
        if (Random.Range(0, 2) == 0)
        {
            V = V1;
        }
        else
        {
            V = V2;
        }
        Color1 = Color.HSVToRGB(H, S, V);

        Color.RGBToHSV(motherNeeds.FatherGenes.ManeGenes[0], out H1, out S1, out V1);
        Color.RGBToHSV(motherNeeds.FatherGenes.ManeGenes[1], out H2, out S2, out V2);
        if (Random.Range(0, 2) == 0)
        {
            H = H1;
        }
        else
        {
            H = H2;
        }
        if (Random.Range(0, 2) == 0)
        {
            S = S1;
        }
        else
        {
            S = S2;
        }
        if (Random.Range(0, 2) == 0)
        {
            V = V1;
        }
        else
        {
            V = V2;
        }
        Color2 = Color.HSVToRGB(H, S, V);
        foalScript.SetMane(Color1, Color2);

        //eyes
        Color.RGBToHSV(motherNeeds.EyeGenes[0], out H1, out S1, out V1);
        Color.RGBToHSV(motherNeeds.EyeGenes[1], out H2, out S2, out V2);
        if (Random.Range(0, 2) == 0)
        {
            H = H1;
        }
        else
        {
            H = H2;
        }
        if (Random.Range(0, 2) == 0)
        {
            S = S1;
        }
        else
        {
            S = S2;
        }
        if (Random.Range(0, 2) == 0)
        {
            V = V1;
        }
        else
        {
            V = V2;
        }
        Color1 = Color.HSVToRGB(H, S, V);

        Color.RGBToHSV(motherNeeds.FatherGenes.EyeGenes[0], out H1, out S1, out V1);
        Color.RGBToHSV(motherNeeds.FatherGenes.EyeGenes[1], out H2, out S2, out V2);
        if (Random.Range(0, 2) == 0)
        {
            H = H1;
        }
        else
        {
            H = H2;
        }
        if (Random.Range(0, 2) == 0)
        {
            S = S1;
        }
        else
        {
            S = S2;
        }
        if (Random.Range(0, 2) == 0)
        {
            V = V1;
        }
        else
        {
            V = V2;
        }
        Color2 = Color.HSVToRGB(H, S, V);
        foalScript.SetEyes(Color1, Color2);

        int Hair1;
        int Hair2;
        //hair
        if (Random.Range(0, 2) == 0)
        {
            Hair1 = motherNeeds.HairGenes[0];
        }
        else
        {
            Hair1 = motherNeeds.HairGenes[1];
        }
        if (Random.Range(0, 2) == 0)
        {
            Hair2 = motherNeeds.FatherGenes.HairGenes[0];
        }
        else
        {
            Hair2 = motherNeeds.FatherGenes.HairGenes[1];
        }
        foalScript.SetHair(Hair1, Hair2);

        float Size1;
        float Size2;
        //size
        if (Random.Range(0, 2) == 0)
        {
            Size1 = motherNeeds.SizeGenes[0];
        }
        else
        {
            Size1 = motherNeeds.SizeGenes[1];
        }
        if (Random.Range(0, 2) == 0)
        {
            Size2 = motherNeeds.FatherGenes.SizeGenes[0];
        }
        else
        {
            Size2 = motherNeeds.FatherGenes.SizeGenes[1];
        }
        foalScript.SetSize(Size1, Size2);


        newFoal.transform.position = gameObject.transform.parent.position;
        int Identifier = 0;
        bool HasPegasus = false;
        bool HasUnicorn = false;
        bool Alicorn = false;
        if (newFoal.GetComponent<FluffyVariables>().AlicornGenes[0] == true && newFoal.GetComponent<FluffyVariables>().AlicornGenes[1] == true)
        {
            Alicorn = true;
            if (newFoal.GetComponent<FluffyVariables>().RaceGenes[0] == 1 || newFoal.GetComponent<FluffyVariables>().RaceGenes[1] == 1)
            {
                HasPegasus = true;
            }
            if (newFoal.GetComponent<FluffyVariables>().RaceGenes[0] == 2 || newFoal.GetComponent<FluffyVariables>().RaceGenes[1] == 2)
            {
                HasUnicorn = true;
            }
        }
        yield return 0;
        Relationship Bond = null;
        if (Alicorn)
        {
            if (HasPegasus == false || HasUnicorn == false)
            {
                Identifier = foalScript.Needs.ID;
                newFoal.GetComponent<FluffyScript>().Die();
                transform.parent.GetComponent<FluffyVariables>().Health -= 25;
                transform.parent.GetComponent<FluffyScript>().PlaySound("scree", true);
                transform.parent.GetComponent<FluffyScript>().Message("SCREEEEEEEEEEEE!", null, null, "fwuffy");
                transform.parent.GetComponent<FluffyScript>().Bleed();
            }
        }
        if (newFoal != null)
        {
            Bond = new Relationship
            {
                FluffyID = foalScript.Needs.ID,
                Fluffy = newFoal,
                Love = 25,
                Protectiveness = 25,
                IsChild = true
            };
        } else
        {
            Bond = new Relationship
            {
                FluffyID = Identifier,
                Love = 25,
                Protectiveness = 25,
                IsDeceased = true
            };
        }
        gameObject.transform.parent.GetComponent<FluffyScript>().SetRelationship(Bond, true);
        motherNeeds.FoalNumber -= 1;
    }
}
