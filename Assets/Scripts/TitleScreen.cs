using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

    public string[] Prefix;
    public string[] Middle;
    public string[] Suffix;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(Prefix[Random.Range(0, Prefix.Length)] + " " + Middle[Random.Range(0, Middle.Length)] + " " + Suffix[Random.Range(0, Suffix.Length)].Replace("  ", " "));
	}
}
