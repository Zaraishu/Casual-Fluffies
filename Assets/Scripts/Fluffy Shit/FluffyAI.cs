using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluffyAI : MonoBehaviour
{

    FluffyScript Fluffy;
    FluffyVariables Needs;
    public int ActionTurns;
    int Action;


    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Decision", 1, 1);
        Fluffy = GetComponent<FluffyScript>();
        Needs = GetComponent<FluffyVariables>();
    }

    //make a decision
    void Decision()
    {
        #region A Bunch of Shit That Used to Be In the Update Loop
        //Grow.
        Needs.Age += 1;
        //Accumulate feces.
        Needs.Poop += 1;
        //Get hungry.
        //Younger, pregnant, and/or nursing fluffies need more food.
        Needs.Hunger += 1 + ((Needs.Gestation / 210) / 2) + (7 - (7 * (Mathf.Clamp(Needs.Age, 0, 600) / 600)));
        //Lactating fluffies produce milk.
        if (Needs.Lactating == true)
        {
            Needs.Milk += 10;
            Needs.Hunger += 2;
            Needs.LactationTime -= 1;
            if (Needs.LactationTime <= 0)
            {
                Needs.Lactating = false;
            }
        }
        else
        {
            Needs.Milk -= 1;
        }
        Needs.Milk = Mathf.Clamp(Needs.Milk, 0, 100);
        //Starve.
        //Younger fluffies lose more health when starving.
        if (Needs.Hunger >= 210)
        {
            Fluffy.Mood -= 5;
            Needs.Health -= 1 + (Mathf.Clamp(6 - (Needs.Age / 100), 0, 6));
            //Other fluffies will notice when one dies of starvation.
            if (Needs.Health <= 0)
            {
                GameObject[] Results = GameObject.FindGameObjectsWithTag("Fluffy");
                float Distance = 30;
                foreach (GameObject hit in Results)
                {
                    if ((hit.transform.position - transform.position).magnitude < Distance)
                    {
                        if (hit != gameObject && hit.GetComponent<FluffyVariables>().Age > 200)
                        {
                            if (!Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(hit.transform.position.x, hit.transform.position.y), LayerMask.GetMask("Map")))
                            {
                                FluffyScript OtherFluffy = hit.GetComponent<FluffyScript>();
                                if (OtherFluffy.Needs.IsCannibal == false)
                                {
                                    OtherFluffy.PlaySound("scaredtalk", true);
                                    string[] Names = new string[1];
                                    Names[0] = OtherFluffy.Needs.Name;
                                    string[] Subs = new string[1];
                                    Subs[0] = "fwend";
                                    OtherFluffy.Message("<name0>, nu! nu am sweepie time wite nao! huu huu...", Names, Subs, null);
                                    hit.transform.GetChild(0).GetComponent<AnimEvents>().SetFace(4);
                                    OtherFluffy.Mood = 0;
                                    //Make them remember that it's dead.
                                    Relationship Bond = new Relationship
                                    {
                                        FluffyID = Needs.ID,
                                        Fluffy = gameObject,
                                        IsDeceased = true
                                    };
                                    OtherFluffy.SetRelationship(Bond, true);
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (Needs.Hunger >= 120)
        {
            Fluffy.Mood -= 2;
        }
        else if (Needs.Hunger < 60)
        {
            Fluffy.Mood += 1;
            if (Needs.Health < 100)
            {
                Needs.Health += 1
;
            }
        }
        //If the fluffy is fully grown, do sex stuff.
        if (Needs.Age >= 600)
        {
            //If it's pregnant or nursing, only increase sex drive by a quarter.
            if (Needs.Lactating == false && Needs.Pregnant == false)
            {
                Needs.SexDrive += Needs.Sexuality / 30;
            } else
            {
                //But if it's a degenerate whore we're talking about, double sex drive instead.
                if (Needs.Sexuality <= 70 && Needs.Morality >= 20)
                {
                    Needs.SexDrive += (Needs.Sexuality / 30) / 4;
                }
                else
                {
                    Needs.SexDrive += (Needs.Sexuality / 30) * 2;
                }
            }
        }
        //If the fluffy is pregnant, let the pregnancy progress.
        if (Needs.Pregnant == true)
        {
            Needs.Gestation += 1;
        }
        //Set the fluffy's size.
        Fluffy.Size = (0.4f + (0.6f * (Mathf.Clamp(Needs.Age / 600, 0, 1)))) * Needs.Size;
        Fluffy.Mood = Mathf.Clamp(Fluffy.Mood, 0, 100);
        Needs.Health = Mathf.Clamp(Needs.Health, 0, 100);
        #endregion
        //If there are turns left, do some general action maintenance stuff.
        if (ActionTurns > 0)
        {
            ActionTurns -= 1;
            //If it's falling, make sure it's still in a situation where it would reasonably be falling.
            if (Fluffy.Falling)
            {
                if (Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y - (1.55f * transform.localScale.y)), new Vector2(3 * Fluffy.Size, 0.1f), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Map")))
                {
                    Fluffy.FluffyEvent(0, 0, null, 0, "Stand", 2, 0, true);
                }
            }
            //If it's approaching an object, run towards it.
            if (Fluffy.State == 3)
            {
                if (Fluffy.Target != null)
                {
                    if (Fluffy.Target.transform.position.x < transform.position.x)
                    {
                        Fluffy.SetDirection(0);
                    }
                    else
                    {
                        Fluffy.SetDirection(1);
                    }
                }
                else
                {
                    if (Needs.Age > 200)
                    {
                        Fluffy.FluffyEvent(0, 0, null, 1, "Stand", 2, 0, false);
                    }
                    else
                    {
                        Fluffy.FluffyEvent(0, 0, null, 1, "Lay", 2, 9, false);
                    }
                }
            }
            //If it's fleeing from an object, run away from it.
            if (Fluffy.State == 4)
            {
                if (Fluffy.Target != null)
                {
                    if (Fluffy.Target.transform.position.x < transform.position.x)
                    {
                        Fluffy.SetDirection(1);
                    }
                    else
                    {
                        Fluffy.SetDirection(0);
                    }
                }
                else
                {
                    if (Needs.Age > 200)
                    {
                        Fluffy.FluffyEvent(0, 0, null, 1, "Stand", 2, 3, false);
                    }
                    else
                    {
                        Fluffy.FluffyEvent(0, 0, null, 1, "Lay", 2, 9, false);
                    }
                }
            }
            //If it has no eyes and is running, give it a chance of tripping.
            if (Needs.NoEyes)
            {
                if (transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Run"))
                {
                    if (Random.Range(0, 3) == 0)
                    {
                        Fluffy.PlaySound("ow", true);
                        Fluffy.Message("eep!", null, null, null);
                        Fluffy.FluffyEvent(0, 0, null, 3, "Trip", 2, 10, false);
                    }
                }
            }
        }
        //Else pick a new action.
        else
        {
            //Set a default face.
            if (Needs.Age > 200)
            {
                transform.GetChild(0).GetComponent<AnimEvents>().SetFace(0);
            }
            else
            {
                transform.GetChild(0).GetComponent<AnimEvents>().SetFace(8);
            }
            //If it's falling or being held, don't actually do anything.
            if (Fluffy.Falling == true || Fluffy.Held == true)
            {
                //If it's not being held, do falling stuff.
                if (Fluffy.Held == false)
                {
                    Fluffy.PlaySound("scree", true);
                    Fluffy.Message("EEEEEEEE!", null, null, null);
                    Fluffy.FluffyEvent(0, 0, null, 5, "Fall", 2, 10, true);
                }
            }
            else
            {
                //If the fluffy's pregnancy has come to term and it is not already in labor, go into labor.
                if (Needs.Gestation >= 210 && Fluffy.State != 2)
                {
                    Fluffy.PlaySound("scaredtalk", true);
                    Fluffy.Message("TUMMY OWWIES!", null, null, null);
                    Fluffy.FrozenState = true;
                    Fluffy.FluffyEvent(2, 0, null, 6, "Breathe", 2, 4, true);
                    Needs.Lactating = true;
                    Needs.LactationTime = 210;
                }
                else
                {
                    //If it's in labor...
                    if (Fluffy.State == 2)
                    {
                        //If there are no more foals to give birth to, stand up.
                        if (Needs.FoalNumber == 0)
                        {
                            Needs.Pregnant = false;
                            Needs.Gestation = 0;
                            Fluffy.FrozenState = false;
                            Fluffy.FluffyEvent(0, 0, null, 5, "Stand", 2, 11, true);
                        }
                        //Else give birth to a foal.
                        else
                        {
                            Fluffy.PlaySound("scree", true);
                            Fluffy.Message("BIGGEST POOPIES! SCREEEEEE!", null, null, null);
                            Fluffy.FluffyEvent(2, 0, null, 5, "Give Birth", 2, 10, true);
                            Needs.Miscarrying = false;
                        }
                    }
                    else
                    {
                        //If it's miscarrying, do that.
                        if (Needs.Miscarrying == true)
                        {
                            if (Needs.Morality <= 20 && Needs.Sexuality >= 70)
                            {
                                Fluffy.PlaySound("sadtalk", true);
                                Fluffy.Message("<name> hab tummy owwies...", null, null, "fwuffy");
                                Fluffy.FluffyEvent(0, 0, null, 5, "Lay", 2, 11, false);
                                Fluffy.Mood -= 50;
                            }
                            else
                            {
                                Fluffy.PlaySound("scree", true);
                                Fluffy.Message("BABBEHS STAY IN MUMMAH! SCREEEEEEE!", null, null, null);
                                Fluffy.FluffyEvent(0, 0, null, 5, "Pant", 2, 4, false);
                                Fluffy.Mood -= 50;
                            }
                            Fluffy.Bleed();
                            Needs.FoalNumber = 0;
                            Needs.Miscarrying = false;
                            Needs.Gestation = 0;
                            Needs.Pregnant = false;
                        }
                        else
                        {
                            //If its poop buildup is at the threshold, shit all over the player's pristine metal blocks.
                            if (Needs.Poop >= 60)
                            {
                                Fluffy.Poop();
                            }
                            else
                            {
                                //Else if hunger is at the threshold, look for food.
                                if (Needs.Hunger >= 60)
                                {
                                    //If it's not a chirpy, look for food.
                                    if (Needs.Age > 200)
                                    {
                                        Fluffy.Motivator = 0;
                                        if (Needs.IsCannibal == true)
                                        {
                                            Fluffy.Seek("Corpse");
                                        }
                                        else
                                        {
                                            Fluffy.Seek("Food");
                                        }
                                    }
                                    //Else look for crotch tiddies.
                                    else
                                    {
                                        Fluffy.Motivator = 5;
                                        Fluffy.Seek("Fluffy");
                                    }
                                }
                                else
                                {
                                    //If it's a horny male, look for a mate.
                                    if (Needs.SexDrive > 60 && Needs.Sex == 0 && Needs.Morality < 40 && Needs.Decency < 30 && Fluffy.Target == null)
                                    {
                                        if (!Needs.NoFrontLegR || !Needs.NoFrontLegL)
                                        {
                                            GameObject[] Results = GameObject.FindGameObjectsWithTag("Fluffy");
                                            List<FluffyScript> Fluffies = new List<FluffyScript>();
                                            float Distance;
                                            if (!Needs.NoEyes)
                                            {
                                                Distance = 15;
                                            }
                                            else
                                            {
                                                Distance = 2;
                                            }
                                            foreach (GameObject hit in Results)
                                            {
                                                if (hit != gameObject)
                                                {
                                                    if (!Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(hit.transform.position.x, hit.transform.position.y), LayerMask.GetMask("Map")))
                                                    {
                                                        if ((hit.transform.position - transform.position).magnitude < Distance)
                                                        {
                                                            Fluffies.Add(hit.GetComponent<FluffyScript>());
                                                        }
                                                    }
                                                }
                                            }
                                            List<FluffyScript> Rejects = new List<FluffyScript>();
                                            foreach (FluffyScript Fluff in Fluffies)
                                            {
                                                if (Fluff.Needs.Sex == 0 || Fluff.Needs.Age < (600 - (300 - (Needs.Morality * 3)) - (300 - (Needs.Decency * 3))))
                                                {
                                                    Rejects.Add(Fluff);
                                                }
                                            }
                                            foreach (FluffyScript Reject in Rejects)
                                            {
                                                Fluffies.Remove(Reject);
                                            }
                                            if (Fluffies.Count > 0)
                                            {
                                                FluffyScript Victim = Fluffies[Random.Range(0, Fluffies.Count)];
                                                Fluffy.FluffyEvent(3, 3, Victim.gameObject, 5, "Run", 4, 6, false);
                                                Fluffy.Check();
                                                Fluffy.PlaySound("angrytalk", true);
                                                string[] Names = new string[1];
                                                string[] Subs = new string[1];
                                                Names[0] = Victim.Needs.Name;
                                                if (Victim.Needs.Age >= 300)
                                                {
                                                    Subs[0] = "DUMMEH MAWE";
                                                }
                                                else
                                                {
                                                    Subs[0] = "DUMMEH BABBEH";
                                                }
                                                Fluffy.Message("<NAME> WAN' SPESHUW HUGGIES WIF <NAME0>!", Names, Subs, "FWUFFY");
                                                if (Victim.Needs.Decency > 40)
                                                {
                                                    // TODO: The SexDrive variable is set to 0 by the FluffyScript.Mate() method.
                                                    // Is the code obsolete?
                                                    Victim.Needs.SexDrive = 0;
                                                    Victim.FluffyEvent(4, 0, Fluffy.gameObject, 5, "Run", 4, 4, false);
                                                    Victim.PlaySound("scree", true);
                                                    Victim.Message("NUUUU!", null, null, null);
                                                }
                                                else
                                                {
                                                    Victim.FluffyEvent(0, 0, null, 5, "Stand", 2, 3, false);
                                                    Victim.PlaySound("happytalk", true);
                                                    Victim.Message("huh?", null, null, null);
                                                }
                                            }
                                            else
                                            {
                                                Fluffy.PlaySound("angrytalk", true);
                                                Fluffy.FluffyEvent(1, 0, null, 5, "Run", 4, 6, false);
                                                Fluffy.Message("DUMMEH MAWES COME OUT! <NAME> WAN' SPESHUW HUGGIES WITE NAO!", null, null, "FWUFFY");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //if nursing and not near children, go home
                                        if (Needs.Lactating)
                                        {
                                            GameObject[] Results = GameObject.FindGameObjectsWithTag("Fluffy");
                                            float Distance = 15;
                                            GameObject Child = null;
                                            foreach (GameObject hit in Results)
                                            {
                                                if (hit != gameObject)
                                                {
                                                    if (!Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(hit.transform.position.x, hit.transform.position.y), LayerMask.GetMask("Map")))
                                                    {
                                                        if ((hit.transform.position - transform.position).magnitude < Distance)
                                                        {
                                                            if (Fluffy.GetRelationship(hit.GetComponent<FluffyVariables>().ID).IsChild && hit.GetComponent<FluffyVariables>().Age < 200)
                                                            {
                                                                Child = hit;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (Child == null)
                                            {
                                                bool HasChild = false;
                                                Vector3 Coordinates = new Vector3();
                                                foreach (Relationship memory in Needs.Relationships)
                                                {
                                                    if (memory.Met >= Needs.Age - 210 && memory.IsChild && memory.IsDeceased == false)
                                                    {
                                                        HasChild = true;
                                                        Coordinates = memory.LastSeen;
                                                        break;
                                                    }
                                                }
                                                if (HasChild == false)
                                                {
                                                    Fluffy.PlaySound("sadtalk", true);
                                                    Fluffy.Message("nu hab nu mowe babbehs fow gib miwkies... am wowstest mummah...", null, null, null);
                                                    Fluffy.FluffyEvent(0, 0, null, 3, "Lay", 4, 3, false);
                                                }
                                                else
                                                {
                                                    Fluffy.PlaySound("sadtalk", true);
                                                    Fluffy.Message("<name> nee' gu back tu babbehs! whewe babbehs?", null, null, "fwuffy");
                                                    if (!Needs.NoEyes)
                                                    {
                                                        Fluffy.FluffyEvent(1, 0, null, 3, "Run", 4, 1, false);
                                                    }
                                                    else
                                                    {
                                                        Fluffy.FluffyEvent(1, 0, null, 3, "Walk", 2, 1, false);
                                                    }
                                                    if (Coordinates.x < transform.position.x)
                                                    {
                                                        Fluffy.SetDirection(0);
                                                    }
                                                    else
                                                    {
                                                        Fluffy.SetDirection(1);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Wander();
                                            }
                                        }
                                        else
                                        {
                                            Wander();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //set size
        if (Fluffy.Direction == 1)
        {
            transform.localScale = new Vector3(Fluffy.Size, Fluffy.Size, 1);
        }
        else
        {
            transform.localScale = new Vector3(Fluffy.Size * -1, Fluffy.Size, 1);
        }
        transform.GetChild(0).GetChild(0).GetChild(9).localScale = new Vector3(1, (0.7f + ((0.05f * Needs.FoalNumber) / 2)) * Mathf.Clamp((Needs.Gestation / 120), 0, 1), 1);
        transform.GetChild(0).GetChild(0).GetChild(10).localScale = new Vector3(1, Needs.Milk / 100, 1);
        //set cutie mark
        if (Needs.Age >= 600)
        {
            transform.GetChild(0).GetChild(0).GetChild(7).gameObject.SetActive(true);
        }
        //forget relationships
        foreach (Relationship memory in Needs.Relationships)
        {
            memory.TimeSince += 1;
            memory.Lust = Mathf.Clamp(memory.Lust - 0.2f, 0, 100);
            memory.Love = Mathf.Clamp(memory.Love - 0.2f, 0, 100);
            memory.Submission = Mathf.Clamp(memory.Submission - 0.2f, 0, 100);
            memory.Fear = Mathf.Clamp(memory.Fear - 0.2f, 0, 100);
            memory.Anger = Mathf.Clamp(memory.Anger - 0.2f, 0, 100);
        }
    }

    void Wander()
    {
        //Pick an action.
        Action = Random.Range(0, 4);
        //if nothing interesting is happening, wander
        if (Action == 0)
        {
            Fluffy.SetDirection(Random.Range(0, 2));
            if (Needs.Age > 200)
            {
                Fluffy.FluffyEvent(1, 0, null, 3, "Walk", 2, 0, false);
            }
            else
            {
                Fluffy.FluffyEvent(1, 0, null, 3, "Crawl", 0.5f, 8, false);
            }
        }
        else if (Action == 1)
        {
            if (Needs.Age > 200)
            {
                Fluffy.Motivator = 1;
                Fluffy.Seek("Fluffy");
            }
            else
            {
                Fluffy.FluffyEvent(0, 0, null, 5, "Lay", 2, 8, false);
                Fluffy.PlaySound("happytalk", true);
                Fluffy.Message("peep peep!", null, null, null);
            }
        }
        else if (Action == 2)
        {
            if (Needs.Age > 200)
            {
                if (Fluffy.LimbNumber < 3)
                {
                    Fluffy.PlaySound("sadtalk", true);
                    Fluffy.FluffyEvent(0, 0, null, 5, "Lay", 2, 3, false);
                    Fluffy.Message("nu can make gud wawkies an' wunnies... huu huu huu...", null, null, "fwuffy");
                }
                else if (Fluffy.Needs.Health < 50)
                {
                    Fluffy.PlaySound("sadtalk", true);
                    Fluffy.FluffyEvent(0, 0, null, 5, "Lay", 2, 3, false);
                    Fluffy.Message("<name> hab wowstest huwties... huu huu huu...", null, null, "fwuffy");
                }
                else
                {
                    if (!Needs.NoEyes)
                    {
                        Fluffy.Motivator = 2;
                        Fluffy.Seek("Toy");
                    }
                    else
                    {
                        Fluffy.FluffyEvent(1, 0, null, 3, "Walk", 2, 3, false);
                        Fluffy.PlaySound("sadtalk", true);
                        Fluffy.Message("gotta gu swow, nu wan' faww down...", null, null, "fwuffy");
                    }
                }
            }
            else
            {
                Fluffy.SetDirection(Random.Range(0, 2));
                Fluffy.FluffyEvent(1, 0, null, 3, "Crawl", 1f, 8, false);
            }
        }
        else if (Action == 3)
        {
            if (Needs.Age > 200)
            {
                if (Needs.Pregnant == true)
                {
                    if (Needs.Sexuality <= 70)
                    {
                        Fluffy.PlaySound("sing", true);
                        Fluffy.Message("mummah wub babbehs, babbehs wub mummah...", null, null, null);
                        Fluffy.FluffyEvent(0, 0, null, 5, "Lay", 2, 0, false);
                    } else if (Needs.Morality <= 20)
                        {
                            Fluffy.PlaySound("sadtalk", true);
                            Fluffy.Message("nu wan' hab stupid dummeh babbehs...", null, null, null);
                            Fluffy.FluffyEvent(0, 0, null, 5, "Lay", 2, 5, false);

                        }
                    }
                else if (Needs.SexDrive >= 60)
                {
                    Fluffy.Motivator = 6;
                    Fluffy.Seek("Fluffy");
                }
                else
                {
                    Fluffy.FluffyEvent(0, 0, null, 5, "Lay", 2, 0, false);
                }
            }
            else
            {
                Fluffy.FluffyEvent(0, 0, null, 5, "Lay", 2, 8, false);
            }
        }
    }
}