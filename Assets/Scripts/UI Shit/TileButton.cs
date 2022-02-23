using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileButton : MonoBehaviour {

    public string Description;
    public string Sprite;
    public int Number;
    public string Tile;
    public string Layer;
    public string Prefab;

    // Update is called once per frame
    public void SetSprite()
    {
        GameObject.Find("Main Camera").GetComponent<PlayerControls>().BuildTile = Tile;
        GameObject.Find("Main Camera").GetComponent<PlayerControls>().BuildSprite = Sprite;
        GameObject.Find("Main Camera").GetComponent<PlayerControls>().Layer = Layer;
        GameObject.Find("Main Camera").GetComponent<PlayerControls>().Prefab = Prefab;
        gameObject.transform.parent.parent.parent.parent.GetChild(1).GetChild(0).GetComponent<Image>().sprite = Resources.LoadAll<Sprite>(Sprite)[Number];
        gameObject.transform.parent.parent.parent.parent.GetChild(1).GetChild(0).GetComponent<Image>().SetNativeSize();
        gameObject.transform.parent.parent.parent.parent.GetChild(0).GetChild(0).GetComponent<Text>().text = Description;
    }
}
