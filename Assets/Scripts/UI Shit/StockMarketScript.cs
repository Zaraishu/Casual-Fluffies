using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockMarketScript : MonoBehaviour {

    #region Stock Market Bullshit Variables
    public float Red;
    public float Orange;
    public float Yellow;
    public float Lime;
    public float Green;
    public float Mint;
    public float Cyan;
    public float Azure;
    public float Blue;
    public float Purple;
    public float Magenta;
    public float Pink;

    public float Earthie;
    public float Pegasus;
    public float Unicorn;
    public float Alicorn;

    public float Age;

    public float Saturation;
    public float Brightness;

    public float Ticks;
    public float Seed;
    #endregion

    // Use this for initialization
    void Start()
    {
        Seed = Random.Range(0.0000001f, 0.9999999f);
        InvokeRepeating("StockMarketBullshit", 0, 10);
    }

    void StockMarketBullshit()
    {
        Ticks += 0.1f;
        Red = Mathf.Lerp(10, 80, Mathf.PerlinNoise(Ticks, Seed));
        Orange = Mathf.Lerp(10, 80, Mathf.PerlinNoise(Ticks, Seed + 1));
        Yellow = Mathf.Lerp(10, 80, Mathf.PerlinNoise(Ticks, Seed + 2));
        Lime = Mathf.Lerp(10, 80, Mathf.PerlinNoise(Ticks, Seed + 3));
        Green = Mathf.Lerp(10, 80, Mathf.PerlinNoise(Ticks, Seed + 4));
        Mint = Mathf.Lerp(10, 80, Mathf.PerlinNoise(Ticks, Seed + 5));
        Cyan = Mathf.Lerp(10, 80, Mathf.PerlinNoise(Ticks, Seed + 6));
        Azure = Mathf.Lerp(10, 80, Mathf.PerlinNoise(Ticks, Seed + 7));
        Blue = Mathf.Lerp(10, 80, Mathf.PerlinNoise(Ticks, Seed + 8));
        Purple = Mathf.Lerp(10, 80, Mathf.PerlinNoise(Ticks, Seed + 9));
        Magenta = Mathf.Lerp(10, 80, Mathf.PerlinNoise(Ticks, Seed + 10));
        Pink = Mathf.Lerp(10, 80, Mathf.PerlinNoise(Ticks, Seed + 11));

        Earthie = Mathf.Lerp(0.5f, 1, Mathf.PerlinNoise(Ticks, Seed + 12));
        Pegasus = Mathf.Lerp(0.8f, 1.3f, Mathf.PerlinNoise(Ticks, Seed + 13));
        Unicorn = Mathf.Lerp(1.1f, 1.6f, Mathf.PerlinNoise(Ticks, Seed + 14));
        Alicorn = Mathf.Lerp(15, 25, Mathf.PerlinNoise(Ticks, Seed + 15));
    }
}
