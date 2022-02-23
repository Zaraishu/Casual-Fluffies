using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherEffects : MonoBehaviour
{

    public float Speed;

    public bool Continuous;

    // Use this for initialization
    public void Begin(float Rate)
    {
        if (!Continuous)
        {
            Continuous = true;
            Speed = Rate;
            transform.localPosition = new Vector3(0, 36, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<RectTransform>().localPosition += new Vector3(0, Speed * Time.deltaTime, 0);
        if (Continuous == true)
        {
            if (gameObject.GetComponent<RectTransform>().localPosition.y <= -12)
            {
                gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 12, 0);
            }
        }
        else
        {
            if (gameObject.GetComponent<RectTransform>().localPosition.y <= -36)
            {
                gameObject.transform.parent.GetChild(1).gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}