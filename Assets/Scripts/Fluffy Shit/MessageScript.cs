using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageScript : MonoBehaviour {

    public Vector3 RelativePosition;
    public GameObject Anchor;
    public static int Number;


	// Use this for initialization
	void Start () {
        Invoke("DestroyObject", 5);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = Number;
        gameObject.transform.GetChild(0).GetComponent<Canvas>().sortingOrder = Number;
        Number += 1;
	}
	
	// Update is called once per frame
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
