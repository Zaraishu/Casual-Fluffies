using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluffyVariables : MonoBehaviour {

    // Can the whole class be implemented as a ScriptObject?
    // Should be set to private and use getter/setter methods instead
    public float Morality;
    public float Decency;
    public float Cannibalism;
    public float Sexuality;
    public bool IsCannibal;

    public float Hunger;
    public float Thirst;
    public float Poop;
    public float Health;
    // What's the difference between Sexuality and SexDrive?
    public float SexDrive;

    public float Milk;
    public bool Lactating;
    public float LactationTime;

    public float Gestation;
    public bool Pregnant;
    public int FoalNumber;
    public bool Miscarrying;

    public int Sex;
    // Is a float variable actually necessary, or does an integer do the job?
    public float Age;
    public string Name;
    public int ID;
    public string Description;

    // Should be an enum instead
    public int Race;

    public FluffyVariables FatherGenes;

    // This is confusing: of course these are variables are of type Color, but this can get lead to errors!
    public Color Base;
    public Color Mane;
    public Color Eyes;
    public Color CutieMark;
    public int Hair;
    public float Size;

    public List<Relationship> Relationships;

    // Missing limbs are tracked by using bool variables...is there another way to keep track of missing limbs instead?
    public bool NoEyes;

    public bool NoEarR;
    public bool NoEarL;

    public bool NoFrontLegR;
    public bool NoFrontLegL;
    public bool NoBackLegR;
    public bool NoBackLegL;

    public bool NoTail;

    public bool NoHorn;
    public bool NoWings;
    public bool NoCutieMark;

    //genetics, motherfucker
    public int[] RaceGenes;
    public bool[] AlicornGenes;
    public Color[] BaseGenes;
    public Color[] ManeGenes;
    public Color[] EyeGenes;
    public int[] HairGenes;
    public float[] SizeGenes;

}
