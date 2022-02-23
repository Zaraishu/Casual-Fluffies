using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Relationship {

    public int FluffyID = -1;
    public float TimeSince;
    public float Met;
    public GameObject Fluffy;
    public Vector2 LastSeen;

    public float Lust;
    public float Protectiveness;
    public float Admiration;
    public float Submission;

    public float Love;

    public float Fear;
    public float Anger;
    public bool IsChild;
    public bool IsParent;
    public bool IsSpecialFriend;
    public bool IsSibling;

    public bool IsDeceased;
}
