using System.IO;
using UnityEngine;

[System.Serializable]
public class EffectScript : MonoBehaviour
{

    public string sound;
    public string[] message;
    public bool bleed;
    public bool poop;
    public string pose;
    public int face;
    public float poison;
    public float duration;
    public int poseTime;
    public float interval;
    public float moodValue;
    public bool vomit;
    public int action;
    public int state;
    public int speed;
    GameObject fluffy;

    private static Builder builder;

    void Start()
    {
        fluffy = gameObject.transform.parent.gameObject;
        InvokeRepeating("Effect", interval, interval);
        Invoke("End", duration);
    }

    private void Update()
    {
        fluffy.GetComponent<FluffyVariables>().Health += poison * Time.deltaTime;
    }

    void Effect()
    {
        fluffy.GetComponent<FluffyScript>().PlaySound(sound, true);
        if (poop)
        {
            fluffy.GetComponent<FluffyScript>().Poop();
        }
        if (bleed)
        {
            fluffy.GetComponent<FluffyScript>().Bleed();
        }
        if (vomit)
        {
            fluffy.GetComponent<FluffyScript>().Vomit();
        }
        fluffy.GetComponent<FluffyScript>().SetDirection(Random.Range(0, 2));
        fluffy.GetComponent<FluffyScript>().Mood += moodValue;
        fluffy.GetComponent<FluffyScript>().FluffyEvent(state, action, null, poseTime, pose, speed, face, false);
        fluffy.GetComponent<FluffyScript>().Message(message[Random.Range(0, message.Length)], null, null, "fwuffy");
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
            effectScript.sound = sound;
            return this;
        }

        public Builder withMessages(string[] messages)
        {
            effectScript.message = messages;
            return this;
        }

        public Builder withBleed()
        {
            effectScript.bleed = true;
            return this;
        }

        public Builder withPoop()
        {
            effectScript.poop = true;
            return this;
        }

        public Builder withPose(string pose)
        {
            effectScript.pose = pose;
            return this;
        }

        public Builder withFace(int face)
        {
            effectScript.face = face;
            return this;
        }

        public Builder withPoison(float poison)
        {
            effectScript.poison = poison;
            return this;
        }

        public Builder withDuration(float duration)
        {
            effectScript.duration = duration;
            return this;
        }

        public Builder withPoseTime(int poseTime)
        {
            effectScript.poseTime = poseTime;
            return this;
        }

        public Builder withInterval(float interval)
        {
            effectScript.interval = interval;
            return this;
        }

        public Builder withMoodValue(float moodValue)
        {
            effectScript.moodValue = moodValue;
            return this;
        }

        public Builder withVomit()
        {
            effectScript.vomit = true;
            return this;
        }

        public Builder withAction(int action)
        {
            effectScript.action = action;
            return this;
        }

        public Builder withState(int state)
        {
            effectScript.state = state;
            return this;
        }


        public Builder withSpeed(int speed)
        {
            effectScript.speed = speed;
            return this;
        }
        public Builder withFluffy(GameObject fluffy)
        {
            effectScript.fluffy = fluffy;
            return this;
        }

        // TODO: This will NOT reset the current effectScript object, so be careful using the same Builder!
        public EffectScript build()
        {
            return effectScript;
        }
    }
}
