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

    // Should be tracked differently, since there is no way a fluffy can both be the parent AND the child of another fluffy...
    // (Also, siblings cannot be special friends. Except when using an incest feature...)
    public bool IsChild;
    public bool IsParent;
    public bool IsSpecialFriend;
    public bool IsSibling;

    public bool IsDeceased;
}
