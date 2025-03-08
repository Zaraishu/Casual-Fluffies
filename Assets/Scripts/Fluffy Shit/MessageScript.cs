using UnityEngine;

/**
 * Script for displaying fluffy messages.
 */
public class MessageScript : MonoBehaviour {

    public Vector3 RelativePosition;
    public GameObject Anchor;
    public static int Number;
    // Time until the message gets destroyed.
    public static float messageTime = 5;

	void Start () {
        // Should be a CoRoutine instead, which also allows passing arguments into it, like the message.
        Invoke("DestroyObject", messageTime);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = Number;
        gameObject.transform.GetChild(0).GetComponent<Canvas>().sortingOrder = Number;
        // The number is essential for the sorting order of the game object, but never decreases.
        // Might be interesting to see if it can be lowered again by decrementing it in the OnDestroy method 
        Number ++;
	}
	
	void Update () {
        if (Anchor != null)
        {
            // Somewhere, this is instantiated and set to be destroyed.
            // We could actually get rid of this logic by adding this as a child to the fluffy game object.
            gameObject.transform.position = Anchor.transform.position + RelativePosition;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
	}
    
    void DestroyObject()
    {
        Number --;
        Destroy(gameObject);
    }
}
