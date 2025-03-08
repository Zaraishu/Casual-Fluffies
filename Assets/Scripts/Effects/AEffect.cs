using System.Collections;
using UnityEngine;

[System.Serializable]
public abstract class AEffect
{
    [SerializeField]
    public string Sound { get; set; }
    [SerializeField]
    public string[] Messages { get; set; }
    [SerializeField]
    public string Pose { get; set; }
    [SerializeField]
    public int Face { get; set; }
    [SerializeField]
    public float Duration { get; set; }
    [SerializeField]
    public int PoseTime { get; set; }
    [SerializeField]
    public float Interval { get; set; }
    [SerializeField]
    public float MoodValue { get; set; }
    [SerializeField]
    public int Action { get; set; }
    [SerializeField]
    public int State { get; set; }
    [SerializeField]
    public int Speed { get; set; }
    [SerializeField]
    public FluffyScript fluffy { protected get; set; }

    [SerializeField]
    private float timeActive;


    public IEnumerator StartEffect()
    {
        if (timeActive <= Duration)
        {
            ApplyEffect();
            ApplyBaseEffect();

            yield return new WaitForSeconds(Interval);
        }
        fluffy.EndEffect(this);
    }

    protected abstract void ApplyEffect();

    private void ApplyBaseEffect()
    {
        if(Sound != null)
        {
            fluffy.PlaySound(Sound, true);
        }

        fluffy.SetDirection(Random.Range(0, 2));
        fluffy.Mood += MoodValue;
        fluffy.FluffyEvent(State, Action, null, PoseTime, Pose, Speed, Face, false);
        fluffy.Say(Messages[Random.Range(0, Messages.Length)], null, null, "fwuffy");
        timeActive += Interval;
    }

    public abstract class Builder<T, U> where T : AEffect, new() where U : Builder <T, U>, new()
    {
        protected T effect;

        public Builder()
        {
            effect = new T();
        }

        public Builder<T, U> WithSound(string sound)
        {
            effect.Sound = sound;
            return this;
        }

        public Builder<T, U> WithMessages(string[] messages)
        {
            effect.Messages = messages;
            return this;
        }

        public Builder<T, U> WithPose(string pose)
        {
            effect.Pose = pose;
            return this;
        }

        public Builder<T, U> WithFace(int face)
        {
            effect.Face = face;
            return this;
        }

        public Builder<T, U> WithDuration(float duration)
        {
            effect.Duration = duration;
            return this;
        }

        public Builder<T, U> WithPoseTime(int poseTime)
        {
            effect.PoseTime = poseTime;
            return this;
        }

        public Builder<T, U> WithInterval(float interval)
        {
            effect.Interval = interval;
            return this;
        }

        public Builder<T, U> WithMoodValue(float moodValue)
        {
            effect.MoodValue = moodValue;
            return this;
        }

        public Builder<T, U> WithAction(int action)
        {
            effect.Action = action;
            return this;
        }

        public Builder<T, U> WithState(int state)
        {
            effect.State = state;
            return this;
        }

        public Builder<T, U> WithSpeed(int speed)
        {
            effect.Speed = speed;
            return this;
        }

        // TODO: This will NOT reset the current effect object, so be careful using the same Builder!
        public virtual T Build()
        {
            return effect;
        }
    }
}
