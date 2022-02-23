using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseScatter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.transform.GetChild(0).parent = null;
        Destroy(gameObject);
	}
}
