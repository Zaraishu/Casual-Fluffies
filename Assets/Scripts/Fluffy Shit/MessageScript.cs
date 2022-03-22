using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageScript : MonoBehaviour {

    public Vector3 RelativePosition;
    public GameObject Anchor;
    public static int Number;

	void Start () {
        Invoke("DestroyObject", 5);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = Number;
        gameObject.transform.GetChild(0).GetComponent<Canvas>().sortingOrder = Number;
        // The number is essential for the sorting order of the game object, but never decreases.
        // Might be interesting to see if it can be lowered again by decrementing it in the OnDestroy method 
        Number += 1;
	}
	
	void Update () {
        if (Anchor != null)
        {
            gameObject.transform.position = Anchor.transform.position + RelativePosition;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
	}

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
