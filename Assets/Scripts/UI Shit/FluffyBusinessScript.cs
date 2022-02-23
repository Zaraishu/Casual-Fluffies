using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FluffyBusinessScript : MonoBehaviour
{

    public GameObject SelectedFluffy;
    PlayerControls Player;
    StockMarketScript Market;

    // Update is called once per frame
    public void SpawnFluffy(Vector2 Position)
    {
        Player = GetComponent<PlayerControls>();
        Market = GetComponent<StockMarketScript>();
        FluffyVariables Fluffy = SelectedFluffy.GetComponent<FluffyVariables>();
        GameObject Spawned = Instantiate((GameObject)Resources.Load("Fluffy"));
        Spawned.GetComponent<FluffyScript>().LoadedIn = true;
        Spawned.transform.position = Position;
        System.Type type = Fluffy.GetType();
        FluffyVariables copy = Spawned.GetComponent<FluffyVariables>();
        // Copied fields can be restricted with BindingFlags
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(Fluffy));
        }
        Destroy(SelectedFluffy);
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);

        transform.parent.gameObject.GetComponent<PlayerControls>().Spawning = false;
        transform.parent.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = "Select a fluffy and click the Spawn button to place it in the world.";
        transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
    }

    //Red: Hue 0 OR 360
    //Orange: Hue 30
    //Yellow: Hue 60
    //Lime: Hue 90
    //Green: Hue 120
    //Mint: Hue 150
    //Cyan: Hue 180
    //Azure: Hue 210
    //Blue: Hue 240
    //Purple: Hue 270
    //Magenta: Hue 300
    //Pink: Hue 330
    public void SellFluffy(FluffyVariables Fluffy)
    {
        float Money;
        float H;
        float S;
        float V;
        bool EndRed = false;
        Color.RGBToHSV(Fluffy.Base, out H, out S, out V);
        H *= 360;
        if (H >= 345)
        {
            EndRed = true;
        }
        Money = 0;
        #region Colors
            Money += Mathf.Lerp(Market.Orange, 0, Mathf.Abs(H - 30) / 30);
            Money += Mathf.Lerp(Market.Yellow, 0, Mathf.Abs(H - 60) / 30);
            Money += Mathf.Lerp(Market.Lime, 0, Mathf.Abs(H - 90) / 30);
            Money += Mathf.Lerp(Market.Green, 0, Mathf.Abs(H - 120) / 30);
            Money += Mathf.Lerp(Market.Mint, 0, Mathf.Abs(H - 150) / 30);
            Money += Mathf.Lerp(Market.Cyan, 0, Mathf.Abs(H - 180) / 30);
            Money += Mathf.Lerp(Market.Azure, 0, Mathf.Abs(H - 210) / 30);
            Money += Mathf.Lerp(Market.Blue, 0, Mathf.Abs(H - 240) / 30);
            Money += Mathf.Lerp(Market.Purple, 0, Mathf.Abs(H - 270) / 30);
            Money += Mathf.Lerp(Market.Magenta, 0, Mathf.Abs(H - 300) / 30);
            Money += Mathf.Lerp(Market.Pink, 0, Mathf.Abs(H - 330) / 30);
            if (EndRed)
            {
                Money += Mathf.Lerp(Market.Red, 0, Mathf.Abs(H) / 30);
            } else
            {
                Money += Mathf.Lerp(Market.Red, 0, Mathf.Abs(H) / 30);
            }
            #endregion
        #region Race
        if (Fluffy.Race == 0)
        {
            Money *= Market.Earthie;
        }
        else if (Fluffy.Race == 1)
        {
            Money *= Market.Pegasus;
        } else if (Fluffy.Race == 2)
        {
            Money *= Market.Unicorn;
        } else if (Fluffy.Race == 3)
        {
            Money *= Market.Alicorn;
        }
        #endregion

        Player.Money += Money;
        print(Money);
        Destroy(Fluffy.gameObject);
    }

    //This function is here to prevent the selected fluffy from spawning inside the ground on the same frame that the Spawn button is clicked, 
    //because I have to buttfuck the expectations of anyone who thinks this is going to be organized or coherent if I want to get anything done.
    public IEnumerator SetSpawning(GameObject Menu)
    {
        Menu.transform.GetChild(10).GetChild(0).gameObject.SetActive(false);
        Menu.transform.GetChild(10).GetChild(1).gameObject.SetActive(true);
        Menu.transform.GetChild(10).GetChild(2).gameObject.SetActive(false);
        Menu.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        Menu.GetComponent<PlayerControls>().Spawning = true;
    }
}