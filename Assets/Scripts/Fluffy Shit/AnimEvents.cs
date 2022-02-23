using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour {

    GameObject Head;
    GameObject Eye;
    GameObject Shine;
    GameObject Eyebrow;
    Sprite[] Faces;
    Sprite[] Eyes;
    Sprite[] Shines;
    Sprite[] Eyebrows;
    GameObject FluffyPrefab;
    GameObject Fluffy;
    FluffyVariables Needs;

    private void Start()
    {
        Needs = gameObject.transform.parent.GetComponent<FluffyVariables>();
        Faces = Resources.LoadAll<Sprite>("face");
        Eyes = Resources.LoadAll<Sprite>("eye");
        Shines = Resources.LoadAll<Sprite>("shine");
        Eyebrows = Resources.LoadAll<Sprite>("eyebrows");
        Head = gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject;
        Eye = gameObject.transform.GetChild(0).GetChild(0).GetChild(4).gameObject;
        Shine = gameObject.transform.GetChild(0).GetChild(0).GetChild(5).gameObject;
        Eyebrow = gameObject.transform.GetChild(0).GetChild(0).GetChild(7).gameObject;
        FluffyPrefab = (GameObject)Resources.Load("Fluffy");
    }

    public void SetFace(int Face)
    {
        Head.GetComponent<SpriteRenderer>().sprite = (Sprite)Faces[Face];
        Shine.GetComponent<SpriteRenderer>().sprite = (Sprite)Shines[Face];
        Eyebrow.GetComponent<SpriteRenderer>().sprite = (Sprite)Eyebrows[Face];
        if (!gameObject.transform.parent.GetComponent<FluffyVariables>().NoEyes)
        {
            Eye.GetComponent<SpriteRenderer>().sprite = (Sprite)Eyes[Face];
        }
    }

    public IEnumerator GiveBirth()
    {
            Fluffy = Instantiate(FluffyPrefab);
        FluffyVariables FluffyNeeds = Fluffy.GetComponent<FluffyVariables>();

        int Race1;
        int Race2;
        //race
        if (Random.Range(0, 2) == 0)
        {
            Race1 = Needs.RaceGenes[0];
        }
        else
        {
            Race1 = Needs.RaceGenes[1];
        }
        if (Random.Range(0, 2) == 0)
        {
            Race2 = Needs.FatherGenes.RaceGenes[0];
        }
        else
        {
            Race2 = Needs.FatherGenes.RaceGenes[1];
        }
        FluffyNeeds.gameObject.GetComponent<FluffyScript>().SetRace(Race1, Race2);

        bool Alicorn1;
        bool Alicorn2;
        //alicorn
        if (Random.Range(0, 2) == 0)
        {
            Alicorn1 = Needs.AlicornGenes[0];
        }
        else
        {
            Alicorn1 = Needs.AlicornGenes[1];
        }
        if (Random.Range(0, 2) == 0)
        {
            Alicorn2 = Needs.FatherGenes.AlicornGenes[0];
        }
        else
        {
            Alicorn2 = Needs.FatherGenes.AlicornGenes[1];
        }
        FluffyNeeds.gameObject.GetComponent<FluffyScript>().SetAlicorn(Alicorn1, Alicorn2);

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
        Color.RGBToHSV(Needs.BaseGenes[0], out H1, out S1, out V1);
        Color.RGBToHSV(Needs.BaseGenes[1], out H2, out S2, out V2);
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

        Color.RGBToHSV(Needs.FatherGenes.BaseGenes[0], out H1, out S1, out V1);
        Color.RGBToHSV(Needs.FatherGenes.BaseGenes[1], out H2, out S2, out V2);
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
        FluffyNeeds.gameObject.GetComponent<FluffyScript>().SetBase(Color1, Color2);

        //mane
        Color.RGBToHSV(Needs.ManeGenes[0], out H1, out S1, out V1);
        Color.RGBToHSV(Needs.ManeGenes[1], out H2, out S2, out V2);
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

        Color.RGBToHSV(Needs.FatherGenes.ManeGenes[0], out H1, out S1, out V1);
        Color.RGBToHSV(Needs.FatherGenes.ManeGenes[1], out H2, out S2, out V2);
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
        FluffyNeeds.gameObject.GetComponent<FluffyScript>().SetMane(Color1, Color2);

        //eyes
        Color.RGBToHSV(Needs.EyeGenes[0], out H1, out S1, out V1);
        Color.RGBToHSV(Needs.EyeGenes[1], out H2, out S2, out V2);
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

        Color.RGBToHSV(Needs.FatherGenes.EyeGenes[0], out H1, out S1, out V1);
        Color.RGBToHSV(Needs.FatherGenes.EyeGenes[1], out H2, out S2, out V2);
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
        FluffyNeeds.gameObject.GetComponent<FluffyScript>().SetEyes(Color1, Color2);

        int Hair1;
        int Hair2;
        //hair
        if (Random.Range(0, 2) == 0)
        {
            Hair1 = Needs.HairGenes[0];
        }
        else
        {
            Hair1 = Needs.HairGenes[1];
        }
        if (Random.Range(0, 2) == 0)
        {
            Hair2 = Needs.FatherGenes.HairGenes[0];
        }
        else
        {
            Hair2 = Needs.FatherGenes.HairGenes[1];
        }
        FluffyNeeds.gameObject.GetComponent<FluffyScript>().SetHair(Hair1, Hair2);

        float Size1;
        float Size2;
        //size
        if (Random.Range(0, 2) == 0)
        {
            Size1 = Needs.SizeGenes[0];
        }
        else
        {
            Size1 = Needs.SizeGenes[1];
        }
        if (Random.Range(0, 2) == 0)
        {
            Size2 = Needs.FatherGenes.SizeGenes[0];
        }
        else
        {
            Size2 = Needs.FatherGenes.SizeGenes[1];
        }
        FluffyNeeds.gameObject.GetComponent<FluffyScript>().SetSize(Size1, Size2);


        Fluffy.transform.position = gameObject.transform.parent.position;
        int Identifier = 0;
        bool HasPegasus = false;
        bool HasUnicorn = false;
        bool Alicorn = false;
        if (Fluffy.GetComponent<FluffyVariables>().AlicornGenes[0] == true && Fluffy.GetComponent<FluffyVariables>().AlicornGenes[1] == true)
        {
            Alicorn = true;
            if (Fluffy.GetComponent<FluffyVariables>().RaceGenes[0] == 1 || Fluffy.GetComponent<FluffyVariables>().RaceGenes[1] == 1)
            {
                HasPegasus = true;
            }
            if (Fluffy.GetComponent<FluffyVariables>().RaceGenes[0] == 2 || Fluffy.GetComponent<FluffyVariables>().RaceGenes[1] == 2)
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
                Identifier = FluffyNeeds.ID;
                Fluffy.GetComponent<FluffyScript>().Die();
                transform.parent.GetComponent<FluffyVariables>().Health -= 25;
                transform.parent.GetComponent<FluffyScript>().PlaySound("scree", true);
                transform.parent.GetComponent<FluffyScript>().Message("SCREEEEEEEEEEEE!", null, null, "fwuffy");
                transform.parent.GetComponent<FluffyScript>().Bleed();
            }
        }
        if (Fluffy != null)
        {
            Bond = new Relationship
            {
                FluffyID = FluffyNeeds.ID,
                Fluffy = FluffyNeeds.gameObject,
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
        Needs.FoalNumber -= 1;
    }
}
