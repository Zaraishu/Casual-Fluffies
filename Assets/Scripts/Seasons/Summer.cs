public class Summer : ASeason
{
    public readonly new string Music = "the everyday fluffy song";
    public new string Name => "Summer";
  
    public override PlantGrowthChances GetPlantGrowthChances()
    {
        return new PlantGrowthChances.Builder()
                        .WithBerriesGrowthChance(40)
                        .WithFlowersGrowthChance(10)
                        .WithMushroomsGrowthChance(15)
                        .WithGrassGrowthChance(35)
                        .WithSafePlantGrowthChance(80)
                        .WithToxicPlantGrowthChance(15)
                        .WithHallucinogenicPlantGrowthChance(5)
                        .Build();
    }

    public override ASeason NextSeason()
    {
        return new Fall();
    }
}
