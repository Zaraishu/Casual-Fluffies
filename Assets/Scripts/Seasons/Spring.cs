public class Spring : ASeason
{
    public readonly new string Music = "the alternate fluffy song";
    public new string Name => "Spring";

    public override PlantGrowthChances GetPlantGrowthChances()
    {
        return new PlantGrowthChances.Builder()
                        .WithFlowersGrowthChance(40)
                        .WithMushroomsGrowthChance(10)
                        .WithBerriesGrowthChance(15)
                        .WithGrassGrowthChance(35)
                        .WithSafePlantGrowthChance(65)
                        .WithToxicPlantGrowthChance(10)
                        .WithHallucinogenicPlantGrowthChance(25)
                        .Build();
    }

    public override ASeason NextSeason()
    {
        return new Summer();
    }
}
