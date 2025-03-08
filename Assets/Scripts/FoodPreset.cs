using UnityEngine;


[CreateAssetMenu]
public class FoodItem : ScriptableObject {

    public float Hunger;

    public string Message;
    public string CannibalMessage;

    public string Sprite;
    public string Tag;

    public bool HasEffect;
    public string Sound;
    public string[] EffectMessage;
    public bool Bleed;
    public bool Poop;
    public string Pose;
    public int Face;
    public float Poison;
    public float Duration;
    public int PoseTime;
    public float Interval;
    public float MoodValue;
    public bool Vomit;
    public EffectScript Effect;
}
