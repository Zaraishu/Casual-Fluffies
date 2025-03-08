public class Winter : ASeason
{
    private readonly new string Music = "the snowy fluffy song";
    public new string Name => "Winter";

    public override PlantGrowthChances GetPlantGrowthChances()
    {
        return new PlantGrowthChances.Builder()
                        .WithBerriesGrowthChance(15)
                        .WithFlowersGrowthChance(10)
                        .WithMushroomsGrowthChance(10)
                        .WithGrassGrowthChance(70)
                        .WithSafePlantGrowthChance(80)
                        .WithToxicPlantGrowthChance(15)
                        .WithHallucinogenicPlantGrowthChance(5)
                        .Build();
    }

    public override ASeason NextSeason()
    {
        return new Spring();
    }
}
