using System.IO;
using UnityEngine;

[System.Serializable]
public class EffectScript : MonoBehaviour
{

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

    private static Builder builder;

    void Start()
    {
        Fluffy = gameObject.transform.parent.gameObject;
        InvokeRepeating("Effect", Interval, Interval);
        Invoke("End", Duration);
    }

    private void Update()
    {
        Fluffy.GetComponent<FluffyVariables>().Health += Poison * Time.deltaTime;
    }

    void Effect()
    {
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
        Fluffy.GetComponent<FluffyScript>().Say(Message[Random.Range(0, Message.Length)], null, null, "fwuffy");
    }

    void End()
    {
        Destroy(gameObject);
    }

    public class Builder
    {
        private EffectScript effectScript = new EffectScript();

        public Builder withSound(string sound)
        {
            effectScript.Sound = sound;
            return this;
        }

        public Builder withMessages(string[] messages)
        {
            effectScript.Message = messages;
            return this;
        }

        public Builder withBleed()
        {
            effectScript.Bleed = true;
            return this;
        }

        public Builder withPoop()
        {
            effectScript.Poop = true;
            return this;
        }

        public Builder withPose(string pose)
        {
            effectScript.Pose = pose;
            return this;
        }

        public Builder withFace(int face)
        {
            effectScript.Face = face;
            return this;
        }

        public Builder withPoison(float poison)
        {
            effectScript.Poison = poison;
            return this;
        }

        public Builder withDuration(float duration)
        {
            effectScript.Duration = duration;
            return this;
        }

        public Builder withPoseTime(int poseTime)
        {
            effectScript.PoseTime = poseTime;
            return this;
        }

        public Builder withInterval(float interval)
        {
            effectScript.Interval = interval;
            return this;
        }

        public Builder withMoodValue(float moodValue)
        {
            effectScript.MoodValue = moodValue;
            return this;
        }

        public Builder withVomit()
        {
            effectScript.Vomit = true;
            return this;
        }

        public Builder withAction(int action)
        {
            effectScript.Action = action;
            return this;
        }

        public Builder withState(int state)
        {
            effectScript.State = state;
            return this;
        }


        public Builder withSpeed(int speed)
        {
            effectScript.Speed = speed;
            return this;
        }
        public Builder withFluffy(GameObject fluffy)
        {
            effectScript.Fluffy = fluffy;
            return this;
        }

        // TODO: This will NOT reset the current effectScript object, so be careful using the same Builder!
        public EffectScript build()
        {
            return effectScript;
        }
    }
}
