using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FluffyButtonScript : MonoBehaviour {

    GameObject Menu;
    FluffyVariables Fluffy;

	// Use this for initialization
	void Start () {
        Menu = GameObject.Find("Fluffy Business Menu");
        Fluffy = GetComponent<FluffyVariables>();
        GetComponent<Image>().color = Fluffy.Base;
        transform.GetChild(0).GetComponent<Image>().color = Fluffy.Mane;
        transform.GetChild(1).GetComponent<Image>().color = Fluffy.Eyes;
    }

    // Update is called once per frame
    public void Click () {
        GameObject TextBox = Menu.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject;
        GameObject ImageBox = Menu.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        #region Giant Blob of Code to Construct the Fucking Description
        TextBox.GetComponent<Text>().text = "Name: ";
        if (Fluffy.Name != string.Empty)
        {
            TextBox.GetComponent<Text>().text += Fluffy.Name;
        } else
        {
            TextBox.GetComponent<Text>().text += "<Unnamed>";
        }
        TextBox.GetComponent<Text>().text += "\n \n" + "Sex: ";
        if (Fluffy.Sex == 0)
        {
            TextBox.GetComponent<Text>().text += "Male";
        } else
        {
            TextBox.GetComponent<Text>().text += "Female";
        }
        TextBox.GetComponent<Text>().text += "\n \n" + "Age: " + Fluffy.Age.ToString() + "\n \n";
        if (Fluffy.Description != string.Empty)
        {
            TextBox.GetComponent<Text>().text += Fluffy.Description;
        } else
        {
            TextBox.GetComponent<Text>().text += "No description provided.";
        }
        #endregion
        ImageBox.transform.GetChild(0).gameObject.SetActive(true);
        ImageBox.transform.GetChild(0).GetComponent<Image>().color = Fluffy.Base;
        ImageBox.transform.GetChild(1).gameObject.SetActive(true);
        ImageBox.transform.GetChild(1).GetComponent<Image>().color = Fluffy.Mane;
        ImageBox.transform.GetChild(2).gameObject.SetActive(true);
        ImageBox.transform.GetChild(2).GetComponent<Image>().color = Fluffy.Eyes;
        Menu.GetComponent<FluffyBusinessScript>().SelectedFluffy = gameObject;
    }
}
