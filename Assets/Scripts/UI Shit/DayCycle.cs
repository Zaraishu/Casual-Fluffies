using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCycle : MonoBehaviour {

    public float SunPosition;
    public float DayTime;

    public bool Day;

    public int Days;
    public int Season;
    public int Years;

    float Sunrise;
    float Daylight;
    float DayLength;
    float Sunset;
    float Night;

    public float SunHeight;

    bool Rain;

    GameObject Weather;
    MusicHandler Music;

    //30 - sunrise
    //60 - day
    //270 - sunset
    //300 - night

	// Use this for initialization
	void Start () {
        DayTime = 0;
        SunPosition = -18f;
        Day = true;
        Sunrise = 30;
        Daylight = 60;
        DayLength = 240;
        Sunset = 270;
        Night = 300;

        SunHeight = 7;

        Weather = gameObject.transform.parent.GetChild(4).gameObject;
        Music = GameObject.Find("Main Camera").GetComponent<MusicHandler>();
    }
	
	// Update is called once per frame
	void Update () {
        //progression and sun movement
        DayTime += 3 * Time.deltaTime;
        if (Day == false)
        {
            SunPosition = Mathf.Lerp(-18, 18, (DayTime - 300) / 300);
        } else
        {
            SunPosition = Mathf.Lerp(-18, 18, DayTime / 300);
        }
        gameObject.transform.localPosition = new Vector3(SunPosition, (Mathf.Pow(SunPosition, 2) * (-0.04f * (SunHeight / 7))) + SunHeight, 10);
        if (SunPosition >= 18f)
        {
            SunPosition = -18f;
            if (Day == true)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("sun")[1];
                Day = false;
            } else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("sun")[0];
                Day = true;
            }
        }
        if (DayTime >= 600)
        {
            DayTime = 0;
            SunPosition = -18f;
            Day = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("sun")[0];
            Days += 1;
                if (Days >= 3) {
                Days = 0;
                Season += 1;
                GameObject.Find("Plants").GetComponent<PlantGrowth>().CancelInvoke("Grow");
                if (Season == 4)
                {
                    Season = 0;
                    Years += 1;
                }
                if (Season == 0)
                {
                    Music.StartCoroutine(Music.Transition("the alternate fluffy song"));

                    SunHeight = 7;

                    Sunrise = 30;
                    Daylight = 60;
                    DayLength = 240;
                    Sunset = 270;
                    Night = 300;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().InvokeRepeating("Grow", 0, 0.5f);

                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Grass = 35;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Flowers = 40;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Mushrooms = 10;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Berries = 15;

                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Safe = 65;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Toxic = 10;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Hallucinogenic = 25;
                }
                else if (Season == 1)
                {
                    Music.StartCoroutine(Music.Transition("the everyday fluffy song"));

                    SunHeight = 9;

                    Sunrise = 30;
                    Daylight = 60;
                    DayLength = 300;
                    Sunset = 330;
                    Night = 360;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().InvokeRepeating("Grow", 0, 1);

                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Grass = 35;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Flowers = 10;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Mushrooms = 15;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Berries = 40;

                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Safe = 80;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Toxic = 15;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Hallucinogenic = 5;
                }
                else if (Season == 2)
                {
                    Music.StartCoroutine(Music.Transition("the flying fluffy song"));

                    SunHeight = 7;

                    Sunrise = 30;
                    Daylight = 60;
                    DayLength = 240;
                    Sunset = 270;
                    Night = 300;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().InvokeRepeating("Grow", 0, 1f);

                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Grass = 25;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Flowers = 10;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Mushrooms = 40;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Berries = 15;

                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Safe = 50;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Toxic = 35;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Hallucinogenic = 15;
                }
                else if (Season == 3)
                {
                    Music.StartCoroutine(Music.Transition("the snowy fluffy song"));

                    SunHeight = 5;

                    Sunrise = 30;
                    Daylight = 60;
                    DayLength = 180;
                    Sunset = 210;
                    Night = 240;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().InvokeRepeating("Grow", 0, 2f);

                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Grass = 70;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Flowers = 10;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Mushrooms = 10;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Berries = 10;

                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Safe = 80;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Toxic = 15;
                    GameObject.Find("Plants").GetComponent<PlantGrowth>().Hallucinogenic = 5;
                }
            }
            if (Season != 3)
            {
                if (Random.Range(0, 3) == 0)
                {

                    Weather.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("rain");
                    Weather.transform.GetChild(0).gameObject.SetActive(true);
                    Weather.transform.GetChild(1).gameObject.SetActive(true);
                    Weather.transform.GetChild(0).GetComponent<WeatherEffects>().Begin(-36);
                }
                else
                {
                    Weather.transform.GetChild(0).GetComponent<WeatherEffects>().Continuous = false;
                    Weather.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
            else
            {
                Weather.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("snow");
                Weather.transform.GetChild(0).gameObject.SetActive(true);
                Weather.transform.GetChild(0).GetComponent<WeatherEffects>().Begin(-1.5f);
            }
        }
        //sky
        if (DayTime < Sunrise)
        {
            float Alpha = DayTime / Sunrise;
            gameObject.transform.parent.Find("sunset").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Alpha - 0.2f);
            gameObject.transform.parent.Find("night").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f - (Alpha * 0.6f));
            gameObject.transform.parent.Find("shader").GetComponent<SpriteRenderer>().color = new Color(Alpha, Alpha / 2, 1 - Alpha, 0.1f);
        } else if (DayTime < Daylight)
        {
            float Alpha = (DayTime - Sunrise) / (Daylight - Sunrise);
            gameObject.transform.parent.Find("sunset").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f - (Alpha * 0.8f));
            gameObject.transform.parent.Find("night").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f - (Alpha * 0.2f));
            gameObject.transform.parent.Find("shader").GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0, 0.1f - (Alpha * 0.1f));
        }
        else if (DayTime < DayLength)
        {
            gameObject.transform.parent.Find("sunset").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            gameObject.transform.parent.Find("night").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            gameObject.transform.parent.Find("shader").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        else if (DayTime < Sunset)
        {
            float Alpha = (DayTime - DayLength) / (Sunset - DayLength);
            gameObject.transform.parent.Find("sunset").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Alpha * 0.8f);
            gameObject.transform.parent.Find("night").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Alpha * 0.2f);
            gameObject.transform.parent.Find("shader").GetComponent<SpriteRenderer>().color = new Color(Alpha, Alpha / 2, 1 - Alpha, Alpha * 0.1f);
        }
        else if (DayTime < Night)
        {
            Weather.transform.GetChild(0).GetComponent<WeatherEffects>().Continuous = false;
            float Alpha = (DayTime - Sunset) / (Night - Sunset);
            gameObject.transform.parent.Find("sunset").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f - (Alpha * 0.8f));
            gameObject.transform.parent.Find("night").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f + (Alpha * 0.6f));
            gameObject.transform.parent.Find("shader").GetComponent<SpriteRenderer>().color = new Color(1 - Alpha, 0.5f - (Alpha * 0.5f), Alpha, 0.1f);
        } else if (DayTime < 600)
        {
            gameObject.transform.parent.Find("sunset").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            gameObject.transform.parent.Find("night").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f);
            gameObject.transform.parent.Find("shader").GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 0.1f);
        }

    }
}
