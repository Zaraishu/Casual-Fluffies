public class PoisonEffect : AEffect
{
    public float Poison { get; private set; }

    public bool Poop { get; private set; }

    public bool Bleed { get; private set; }

    public bool Vomit { get; private set; }

    protected override void ApplyEffect()
    {
        fluffy.Needs.Health += Poison;

        if (Poop)
        {
            fluffy.Poop();
        }
        if (Bleed)
        {
            fluffy.Bleed();
        }
        if (Vomit)
        {
            fluffy.Vomit();
        }
    }

    public class Builder : Builder<PoisonEffect, Builder>
    { 
        public Builder WithPoison(float poison)
        {
            effect.Poison = poison;
            return this;
        }

        public Builder WithPoop()
        {
            effect.Poop = true;
            return this;
        }

        public Builder WithBleed()
        {
            effect.Bleed = true;
            return this;
        }

        public Builder WithVomit()
        {
            effect.Vomit = true;
            return this;
        }
    }
}
