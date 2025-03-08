public class HallucinogenicEffect : AEffect
{
    public float Poison { get; set; } = -0.1f;
    public new float Duration { get; set; } = 60;
    public new string Pose { get; set; } = "Lay";
    public new int PoseTime { get; set; } = 5;
    public new int Interval { get; set; } = 10;
    public new int MoodValue { get; set; } = -5;
    public new string Sound { get; set; } = "happytalk";
    public new string[] Messages { get; set; } =
    {
        "*munch* nummies, come back!",
        "*wiggle wiggle* siwwy weggies! buddah weggies nu gud fow wawkies!",
        "huu huu... <name> hab scawedies!"
    };

    protected override void ApplyEffect()
    {
        fluffy.Needs.Health += Poison;
    }
}
