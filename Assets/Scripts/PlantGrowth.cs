using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantGrowth : MonoBehaviour
{
    public PlantGrowthChances growthChances { get; set; }

    /**
    * <summary>
    * Keeps the plant game objects tidy.
    * </summary>
    */
    private GameObject plantHolder;
    private Grid grid;
    private Tilemap baseTilemap;
    private Tilemap secondTilemap;
    private Tilemap splattersTilemap;
    private Tilemap plantsTilemap;
    private Tilemap machinesTilemap;

    // Use this for initialization
    void Start()
    {
        grid = transform.parent.GetComponent<Grid>();
        baseTilemap = grid.transform.GetChild(0).GetComponent<Tilemap>();
        secondTilemap = grid.transform.GetChild(1).GetComponent<Tilemap>();
        plantsTilemap = grid.transform.GetChild(3).GetComponent<Tilemap>();
        machinesTilemap = grid.transform.GetChild(4).GetComponent<Tilemap>();

        plantHolder = GameObject.Find("PlantHolder");

        growthChances = new PlantGrowthChances.Builder()
            .WithBerriesGrowthChance(15)
            .WithFlowersGrowthChance(40)
            .WithMushroomsGrowthChance(10)
            .WithGrassGrowthChance(35)
            .WithSafePlantGrowthChance(65)
            .WithToxicPlantGrowthChance(10)
            .WithHallucinogenicPlantGrowthChance(25)
            .Build();

        InvokeRepeating(nameof(Grow), 0, 0.5f);
    }

    // Update is called once per frame
    void Grow()
    {
        Vector2 TilePosition = new Vector2(Random.Range(-192, 192), Random.Range(-12, 111));
        int Times = 0;
        bool FoundSpot = false;
        while (Times < 1000)
        {
            if (
           !baseTilemap.GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y + 1, 0)))
            &&
            !secondTilemap.GetComponent<Tilemap>().GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y + 1, 0)))
             &&
             !plantsTilemap.GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y + 1, 0)))
             &&
            !machinesTilemap.GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y + 1, 0)))
            )
            {
                if (baseTilemap.GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y, 0))) == (TileBase)Resources.Load("Tiles/grass")
                ||
                secondTilemap.GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y, 0))) == (TileBase)Resources.Load("Tiles/grass"))
                {
                    if (secondTilemap.GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y, 0))) == (TileBase)Resources.Load("Tiles/grass")
                        || !secondTilemap.GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y, 0))))
                    {
                        FoundSpot = true;
                    }
                    break;
                }
            }
            TilePosition = new Vector2(Random.Range(-192, 192), Random.Range(-12, 111));
            Times += 1;
        }
        if (FoundSpot)
        {
            int Type = Random.Range(1, 101);
            int Level = Random.Range(1, 101);
            string Name;
            GameObject Plant = Instantiate((GameObject)Resources.Load("Plant"), plantHolder.transform);
            Plant.GetComponent<Food>().uses = 1;
            Plant.GetComponent<Food>().SingleUse = true;
            Name = string.Empty;
            if (!Weedfucker9000Script.Active)
            {
                if (Level < growthChances.Hallucinogenic)
                {
                    Name += "baked";
                    Plant.GetComponent<PlantScript>().Effect = new HallucinogenicEffect();
                }
                else if (Level < growthChances.Hallucinogenic + growthChances.Toxic)
                {
                    Name += "death";
                }
                else
                {
                    Name += "safe";
                }
            }
            else
            {
                Name += "safe";
                Destroy(Plant.transform.GetChild(0).gameObject);
            }
            if (Type < growthChances.Berries)
            {
                Plant.GetComponent<Food>().message = "bestest bewwy nummies!";
                Plant.GetComponent<Food>().hunger = 40;
                if (Name == "death")
                {
                    PoisonEffect effect = new PoisonEffect.Builder()
                        .WithPoison(-0.2f)
                        .WithVomit()
                        .WithDuration(80)
                        .WithPose("Poop")
                        .WithPoseTime(5)
                        .WithInterval(20)
                        .WithFace(10)
                        .WithMoodValue(-15)
                        .WithSound("scaredtalk")
                        .WithMessages(new string[3] {
                        "bad tummy feews- *HURK*",
                        "*cough cough* daddeh, <name> hab sickies...",
                        "huu huu huu! nu wan' make sickie wawas nu mowe- *HURK*"
                    }).Build();
                    Plant.GetComponent<PlantScript>().Effect = effect;
                }
                Name += "berries";
            }
            else if (Type < growthChances.Berries + growthChances.Mushrooms)
            {
                Plant.GetComponent<Food>().message = "dis am funny nummies!";
                Plant.GetComponent<Food>().hunger = 30;
                if (Name == "death")
                {
                    PoisonEffect effect = new PoisonEffect.Builder()
                        .WithPoison(-0.4f)
                        .WithPoop()
                        .WithDuration(40)
                        .WithPose("Poop")
                        .WithPoseTime(5)
                        .WithInterval(15)
                        .WithFace(4)
                        .WithMoodValue(-10)
                        .WithSound("scree")
                        .WithMessages(new string[3]{
                        "HUWTIE POOPIES! SCREEEEEE!",
                        "WHY POOPIES GIB HUWTIES? HUU HUU HUU!",
                        "WOWSTEST POOPIE HUWTIES!"
                    }).Build();
                    Plant.GetComponent<PlantScript>().Effect = effect;
                }
                Name += "mushrooms";
            }
            else if (Type < growthChances.Berries + growthChances.Mushrooms + growthChances.Flowers)
            {
                Plant.GetComponent<Food>().message = "pwetty nummies!";
                Plant.GetComponent<Food>().hunger = 25;
                if (Name == "death")
                {
                    PoisonEffect effect = new PoisonEffect.Builder()
                      .WithPoison(-0.75f)
                      .WithBleed()
                      .WithDuration(20f)
                      .WithPose("Pant")
                      .WithPoseTime(5)
                      .WithInterval(10)
                      .WithFace(4)
                      .WithMoodValue(-20)
                      .WithSound("scaredtalk")
                      .WithMessages(new string[3]{
                        "WOWSTEST TUMMY OWWIES!",
                            "huu huu... daddeh, hewp <name>...",
                            "huu huu huu... *cough*"
                  }).Build();
                    Plant.GetComponent<PlantScript>().Effect = effect;
                }
                Name += "flowers";
            }
            else
            {
                Name = "tallgrass";
                Plant.GetComponent<Food>().message = "wan' gud nummies...";
                Plant.GetComponent<Food>().hunger = 20;
            }
            Plant.GetComponent<Food>().cannibalMessage = "nu wike icky dummeh nummies!";
            Plant.transform.position = new Vector3(Mathf.FloorToInt(TilePosition.x) + 0.5f, Mathf.FloorToInt(TilePosition.y + 1) + 0.5f, 0);
            Plant.GetComponent<PlantScript>().TileName = Name;
            plantsTilemap.SetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y + 1, 0)), (Tile)Resources.Load(Name));
        }
    }
}
