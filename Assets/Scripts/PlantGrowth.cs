using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantGrowth : MonoBehaviour
{

    Vector2 TilePosition;

    public float Berries;
    public float Flowers;
    public float Mushrooms;
    public float Grass;

    public float Safe;
    public float Toxic;
    public float Hallucinogenic;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Grow", 0, 0.5f);
        Grass = 35;
        Flowers = 40;
        Mushrooms = 10;
        Berries = 15;

        Safe = 65;
        Toxic = 10;
        Hallucinogenic = 25;
    }

    // Update is called once per frame
    void Grow()
    {
        TilePosition = new Vector2(Random.Range(-192, 192), Random.Range(-12, 111));
        int Times = 0;
        bool FoundSpot = false;
        while (Times < 1000)
        {

            if (
           !gameObject.transform.parent.GetChild(0).GetComponent<Tilemap>().GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y + 1, 0)))
            &&
            !gameObject.transform.parent.GetChild(1).GetComponent<Tilemap>().GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y + 1, 0)))
             &&
            !gameObject.transform.parent.GetChild(4).GetComponent<Tilemap>().GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y + 1, 0)))
            &&
             !gameObject.transform.parent.GetChild(3).GetComponent<Tilemap>().GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y + 1, 0)))
            )
            {
                if (gameObject.transform.parent.GetChild(0).GetComponent<Tilemap>().GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y, 0))) == (TileBase)Resources.Load("Tiles/grass")
                ||
                gameObject.transform.parent.GetChild(1).GetComponent<Tilemap>().GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y, 0))) == (TileBase)Resources.Load("Tiles/grass"))
                {
                    if (gameObject.transform.parent.GetChild(1).GetComponent<Tilemap>().GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y, 0))) == (TileBase)Resources.Load("Tiles/grass") || !gameObject.transform.parent.GetChild(1).GetComponent<Tilemap>().GetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y, 0))))
                        FoundSpot = true;
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
            GameObject Plant = Instantiate((GameObject)Resources.Load("Plant"));
            Plant.GetComponent<FoodScript>().Uses = 1;
            Plant.GetComponent<FoodScript>().SingleUse = true;
            Name = string.Empty;
            if (Weedfucker9000Script.Active == false)
            {
                if (Level < Hallucinogenic)
                {
                    Name += "baked";
                    EffectScript effect = new EffectScript.Builder()
                        .withPoison(-0.1f)
                        .withDuration(60)
                        .withPose("Lay")
                        .withPoseTime(5)
                        .withInterval(10)
                        .withFace(0)
                        .withMoodValue(-5)
                        .withSound("happytalk")
                        .withMessages(new string[3]
                        {
                            "*munch* nummies, come back!",
                            "*wiggle wiggle* siwwy weggies! buddah weggies nu gud fow wawkies!",
                            "huu huu... <name> hab scawedies!"
                        }).build();
                    EffectScript effectScript = Plant.transform.GetChild(0).gameObject.GetComponent<EffectScript>();
                    effectScript = effect;
                }
                else if (Level < Hallucinogenic + Toxic)
                {
                    Name += "death";
                }
                else
                {
                    Name += "safe";
                    Destroy(Plant.transform.GetChild(0).gameObject);
                }
            }
            else
            {
                Name += "safe";
                Destroy(Plant.transform.GetChild(0).gameObject);
            }
            if (Type < Berries)
            {
                Plant.GetComponent<FoodScript>().Message = "bestest bewwy nummies!";
                Plant.GetComponent<FoodScript>().Hunger = 40;
                if (Name == "death")
                {
                    EffectScript effect = new EffectScript.Builder()
                        .withPoison(-0.2f)
                        .withDuration(80)
                        .withVomit()
                        .withPose("Poop")
                        .withPoseTime(5)
                        .withInterval(20)
                        .withFace(10)
                        .withMoodValue(-15)
                        .withSound("scaredtalk")
                        .withMessages(new string[3] {
                        "bad tummy feews- *HURK*",
                        "*cough cough* daddeh, <name> hab sickies...",
                        "huu huu huu! nu wan' make sickie wawas nu mowe- *HURK*"
                    }).build();
                    EffectScript effectScript = Plant.transform.GetChild(0).gameObject.GetComponent<EffectScript>();
                    effectScript = effect;
                }
                Name += "berries";
            }
            else if (Type < Berries + Mushrooms)
            {
                Plant.GetComponent<FoodScript>().Message = "dis am funny nummies!";
                Plant.GetComponent<FoodScript>().Hunger = 30;
                if (Name == "death")
                {
                    EffectScript effect = new EffectScript.Builder()
                        .withPoison(-0.4f)
                        .withDuration(40)
                        .withPoop()
                        .withPose("Poop")
                        .withPoseTime(5)
                        .withInterval(15)
                        .withFace(4)
                        .withMoodValue(-10)
                        .withSound("scree")
                        .withMessages(new string[3]{
                        "HUWTIE POOPIES! SCREEEEEE!",
                        "WHY POOPIES GIB HUWTIES? HUU HUU HUU!",
                        "WOWSTEST POOPIE HUWTIES!"
                    }).build();
                    EffectScript effectScript = Plant.transform.GetChild(0).gameObject.GetComponent<EffectScript>();
                    effectScript = effect;
                }
                Name += "mushrooms";
            }
            else if (Type < Berries + Mushrooms + Flowers)
            {
                Plant.GetComponent<FoodScript>().Message = "pwetty nummies!";
                Plant.GetComponent<FoodScript>().Hunger = 25;
                if (Name == "death")
                {
                    EffectScript effect = new EffectScript.Builder()
                        .withPoison(-0.75f)
                        .withDuration(20)
                        .withBleed()
                        .withPose("Pant")
                        .withPoseTime(5)
                        .withInterval(10)
                        .withFace(4)
                        .withMoodValue(-20)
                        .withSound("scaredtalk")
                        .withMessages(new string[3]
                        {
                            "WOWSTEST TUMMY OWWIES!",
                            "huu huu... daddeh, hewp <name>...",
                            "huu huu huu... *cough*"
                        }).build();
                    EffectScript effectScript = Plant.transform.GetChild(0).gameObject.GetComponent<EffectScript>();
                    effectScript = effect;
                }
                Name += "flowers";
            }
            else
            {
                Name = "tallgrass";
                Plant.GetComponent<FoodScript>().Message = "wan' gud nummies...";
                Plant.GetComponent<FoodScript>().Hunger = 20;
                Destroy(Plant.transform.GetChild(0).gameObject);
            }
            Plant.GetComponent<FoodScript>().CannibalMessage = "nu wike icky dummeh nummies!";
            Plant.transform.position = new Vector3(Mathf.FloorToInt(TilePosition.x) + 0.5f, Mathf.FloorToInt(TilePosition.y + 1) + 0.5f, 0);
            Plant.GetComponent<PlantScript>().TileName = Name;
            gameObject.transform.parent.GetChild(3).GetComponent<Tilemap>().SetTile(Vector3Int.FloorToInt(new Vector3(TilePosition.x, TilePosition.y + 1, 0)), (Tile)Resources.Load(Name));
        }
    }
}
