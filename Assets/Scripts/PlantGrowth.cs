using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantGrowth : MonoBehaviour {

    Vector2 TilePosition;

    public float Berries;
    public float Flowers;
    public float Mushrooms;
    public float Grass;

    public float Safe;
    public float Toxic;
    public float Hallucinogenic;

	// Use this for initialization
	void Start () {
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
    void Grow() {
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
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Poison = -0.1f;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Duration = 60;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Pose = "Lay";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().PoseTime = 5;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Interval = 10;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Face = 0;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().MoodValue = -5;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Sound = "happytalk";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message = new string[3];
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message[0] = "*munch* nummies, come back!";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message[1] = "*wiggle wiggle* siwwy weggies! buddah weggies nu gud fow wawkies!";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message[2] = "huu huu... <name> hab scawedies!";
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
            } else
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
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Poison = -0.2f;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Duration = 80;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Vomit = true;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Pose = "Poop";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().PoseTime = 5;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Interval = 20;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Face = 10;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().MoodValue = -15;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Sound = "scaredtalk";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message = new string[3];
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message[0] = "bad tummy feews- *HURK*";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message[1] = "*cough cough* daddeh, <name> hab sickies...";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message[2] = "huu huu huu! nu wan' make sickie wawas nu mowe- *HURK*";
                }
                Name += "berries";
            }
            else if (Type < Berries + Mushrooms)
            {
                Plant.GetComponent<FoodScript>().Message = "dis am funny nummies!";
                Plant.GetComponent<FoodScript>().Hunger = 30;
                if (Name == "death")
                {
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Poison = -0.4f;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Duration = 40;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Poop = true;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Pose = "Poop";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().PoseTime = 5;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Interval = 15;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Face = 4;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().MoodValue = -10;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Sound = "scree";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message = new string[3];
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message[0] = "HUWTIE POOPIES! SCREEEEEE!";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message[1] = "WHY POOPIES GIB HUWTIES? HUU HUU HUU!";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message[2] = "WOWSTEST POOPIE HUWTIES!";
                }
                Name += "mushrooms";
            } else if (Type < Berries + Mushrooms + Flowers)
            {
                Plant.GetComponent<FoodScript>().Message = "pwetty nummies!";
                Plant.GetComponent<FoodScript>().Hunger = 25;
                if (Name == "death")
                {
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Poison = -0.75f;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Duration = 20;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Bleed = true;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Pose = "Pant";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().PoseTime = 5;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Interval = 10;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Face = 4;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().MoodValue = -20;
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Sound = "scaredtalk";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message = new string[3];
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message[0] = "WOWSTEST TUMMY OWWIES!";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message[1] = "huu huu... daddeh, hewp <name>...";
                    Plant.transform.GetChild(0).GetComponent<EffectScript>().Message[2] = "huu huu huu... *cough*";
                }
                Name += "flowers";
            } else
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
