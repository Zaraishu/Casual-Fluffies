using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EffectScript : MonoBehaviour {

    public string Sound;
    public string[] Message;
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
    public int Action;
    public int State;
    public int Speed;
    GameObject Fluffy;

    // Use this for initialization
    void Start () {
        
        Fluffy = gameObject.transform.parent.gameObject;
        InvokeRepeating("Effect", Interval, Interval);
        Invoke("End", Duration);
    }

    private void Update()
    {
        Fluffy.GetComponent<FluffyVariables>().Health += Poison * Time.deltaTime;
    }

    // Update is called once per frame
    void Effect () {
        Fluffy.GetComponent<FluffyScript>().PlaySound(Sound, true);
        if (Poop)
        {
            Fluffy.GetComponent<FluffyScript>().Poop();
        }
        if (Bleed)
        {
            Fluffy.GetComponent<FluffyScript>().Bleed();
        }
        if (Vomit)
        {
            Fluffy.GetComponent<FluffyScript>().Vomit();
        }
        Fluffy.GetComponent<FluffyScript>().SetDirection(Random.Range(0, 2));
        Fluffy.GetComponent<FluffyScript>().Mood += MoodValue;
        Fluffy.GetComponent<FluffyScript>().FluffyEvent(State, Action, null, PoseTime, Pose, Speed, Face, false);
        Fluffy.GetComponent<FluffyScript>().Message(Message[Random.Range(0, Message.Length)], null, null, "fwuffy");
	}

    void End()
    {
        Destroy(gameObject);
    }
}
