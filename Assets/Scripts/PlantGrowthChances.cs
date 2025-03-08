public class PlantGrowthChances
{
    public float Berries { get; private set; }
    public float Flowers { get; private set; }
    public float Mushrooms { get; private set; }
    public float Grass { get; private set; }

    public float Safe { get; private set; }
    public float Toxic { get; private set; }
    public float Hallucinogenic { get; private set; }

    public class Builder
    {
        private PlantGrowthChances plantGrowthChances;

        public Builder()
        {
            plantGrowthChances = new PlantGrowthChances();
        }

        public Builder WithBerriesGrowthChance(float berriesGrowthChance)
        {
            plantGrowthChances.Berries = berriesGrowthChance;
            return this;
        }

        public Builder WithFlowersGrowthChance(float flowersGrowthChance)
        {
            plantGrowthChances.Flowers = flowersGrowthChance;
            return this;
        }

        public Builder WithMushroomsGrowthChance(float mushroomsGrowthChance)
        {
            plantGrowthChances.Mushrooms = mushroomsGrowthChance;
            return this;
        }

        public Builder WithGrassGrowthChance(float grassGrowthChance)
        {
            plantGrowthChances.Grass = grassGrowthChance;
            return this;
        }

        public Builder WithSafePlantGrowthChance(float safePlantGrowthChance)
        {
            plantGrowthChances.Safe = safePlantGrowthChance;
            return this;
        }

        public Builder WithToxicPlantGrowthChance(float toxicPlantGrowthChance)
        {
            plantGrowthChances.Toxic = toxicPlantGrowthChance;
            return this;
        }

        public Builder WithHallucinogenicPlantGrowthChance(float hallucinogenicPlantGrowthChance)
        {
            plantGrowthChances.Hallucinogenic = hallucinogenicPlantGrowthChance;
            return this;
        }

        public PlantGrowthChances Build()
        {
            return plantGrowthChances;
        }
    }
}
