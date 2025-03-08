public class Fall : ASeason
{
    public readonly new string Music = "the flying fluffy song";
    public new string Name => "Fall";

    public override PlantGrowthChances GetPlantGrowthChances()
    {
        return new PlantGrowthChances.Builder()
                        .WithBerriesGrowthChance(15)
                        .WithFlowersGrowthChance(10)
                        .WithMushroomsGrowthChance(40)
                        .WithGrassGrowthChance(25)
                        .WithSafePlantGrowthChance(50)
                        .WithToxicPlantGrowthChance(35)
                        .WithHallucinogenicPlantGrowthChance(15)
                        .Build();
    }

    public override ASeason NextSeason()
    {
        return new Winter();
    }
}
