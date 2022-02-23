using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodButton : MonoBehaviour
{

    public string Description;
    public string Sprite;
    public int Number;
    public FoodPreset Food;

    // Update is called once per frame
    public void SetSprite()
    {
        GameObject.Find("Main Camera").GetComponent<PlayerControls>().Food = Food;
        gameObject.transform.parent.parent.parent.parent.GetChild(1).GetChild(1).GetComponent<Image>().sprite = Resources.LoadAll<Sprite>(Sprite)[Number];
        gameObject.transform.parent.parent.parent.parent.GetChild(0).GetChild(0).GetComponent<Text>().text = Description;
    }
}
