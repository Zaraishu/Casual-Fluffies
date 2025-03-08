using UnityEngine;
using UnityEngine.UI;

public class DayCycle : MonoBehaviour
{
    public float SunPosition = -18f;
    public float DayTime = 0;

    public bool Day = true;

    public int Days;
    [SerializeReference]
    public ASeason Season;
    public int Years;

    private float DayLength = 240;

    private float Sunrise = 30;
    private float Daylight = 60;
    private float Sunset = 270;
    private float Night = 300;

    public float SunHeight;

    /**
     * <summary>
     * The length of a season, in days.
     * </summary>
     */
    private readonly int SeasonLength = 3;

    bool Rain;

    GameObject Weather;
    private MusicHandler musicHandler;
    PlantGrowth PlantGrowth;

    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite sunSprite;
    [SerializeField]
    private Sprite moonSprite;

    void Start()
    {
        SunHeight = 7;
        Season = new Spring();
        Weather = gameObject.transform.parent.GetChild(4).gameObject;
        musicHandler = GameObject.Find("Main Camera").GetComponent<MusicHandler>();
        PlantGrowth = GameObject.Find("Plants").GetComponent<PlantGrowth>();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        sunSprite = Resources.LoadAll<Sprite>("sun")[0];
        moonSprite = Resources.LoadAll<Sprite>("sun")[1];
        spriteRenderer.sprite = sunSprite;
    }

    // Update is called once per frame
    void Update()
    {
        //progression and sun movement
        DayTime += 3 * Time.deltaTime;

        float lerp = !Day ? ((DayTime - 300) / 300) : (DayTime / 300);

        if (!Day)
        {
            SunPosition = Mathf.Lerp(-18, 18, lerp);
        }
        else
        {
            SunPosition = Mathf.Lerp(-18, 18, lerp);
        }
        gameObject.transform.localPosition = new Vector3(SunPosition, (Mathf.Pow(SunPosition, 2) * (-0.04f * (SunHeight / 7))) + SunHeight, 10);
        if (SunPosition >= 18f)
        {
            SunPosition = -18f;
            if (Day)
            {
                spriteRenderer.sprite = moonSprite;
                Day = false;
            }
            else
            {
                spriteRenderer.sprite = sunSprite;
                Day = true;
            }
        }
        if (DayTime >= 600)
        {
            DayTime = 0;
            SunPosition = -18f;
            Day = true;
            spriteRenderer.sprite = sunSprite;
            Days += 1;

            if (Days > SeasonLength)
            {
                BeginNextSeason();
            }
            if (Season.GetType() == typeof(Winter) )
            {
                Weather.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("snow");
                Weather.transform.GetChild(0).gameObject.SetActive(true);
                Weather.transform.GetChild(0).GetComponent<WeatherEffects>().Begin(-1.5f);
            }
            else
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
        }
        //sky
        if (DayTime < Sunrise)
        {
            float Alpha = DayTime / Sunrise;
            gameObject.transform.parent.Find("sunset").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Alpha - 0.2f);
            gameObject.transform.parent.Find("night").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f - (Alpha * 0.6f));
            gameObject.transform.parent.Find("shader").GetComponent<SpriteRenderer>().color = new Color(Alpha, Alpha / 2, 1 - Alpha, 0.1f);
        }
        else if (DayTime < Daylight)
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
        }
        else if (DayTime < 600)
        {
            gameObject.transform.parent.Find("sunset").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            gameObject.transform.parent.Find("night").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f);
            gameObject.transform.parent.Find("shader").GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 0.1f);
        }
    }

    private void BeginNextSeason()
    {
        Season = Season.NextSeason();

        Debug.Log("It is now " + Season.Name);

        Days = 0;
        GameObject.Find("Plants").GetComponent<PlantGrowth>().CancelInvoke("Grow");

        if (Season is Winter)
        {
            Season = new Spring();
            Years += 1;
        }
        if (Season is Spring)
        {
            SunHeight = 7;

            Sunrise = 30;
            Daylight = 60;
            DayLength = 240;
            Sunset = 270;
            Night = 300;

            GameObject.Find("Plants").GetComponent<PlantGrowth>().InvokeRepeating("Grow", 0, 0.5f);
        }
        else if (Season is Summer)
        {
            SunHeight = 9;

            Sunrise = 30;
            Daylight = 60;
            DayLength = 300;
            Sunset = 330;
            Night = 360;

            GameObject.Find("Plants").GetComponent<PlantGrowth>().InvokeRepeating("Grow", 0, 1);
        }
        else if (Season is Fall)
        {
            SunHeight = 7;

            Sunrise = 30;
            Daylight = 60;
            DayLength = 240;
            Sunset = 270;
            Night = 300;

            GameObject.Find("Plants").GetComponent<PlantGrowth>().InvokeRepeating("Grow", 0, 1f);
        }
        else if (Season is Winter)
        {

            SunHeight = 5;

            Sunrise = 30;
            Daylight = 60;
            DayLength = 180;
            Sunset = 210;
            Night = 240;

            GameObject.Find("Plants").GetComponent<PlantGrowth>().InvokeRepeating("Grow", 0, 2f);
        }
    }
}
