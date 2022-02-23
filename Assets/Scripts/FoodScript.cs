using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{

    public float Hunger;

    public string Message;
    public string CannibalMessage;

    public int Uses;
    public int MaxUses;

    public bool SingleUse;

    public void Fill(float H, float T, string M, Sprite Image, string Tag)
    {
        Hunger = H;
        Message = M;
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = Image;
        gameObject.tag = Tag;
        Uses = MaxUses;
    }

    public void Eat(GameObject Fluffy)
    {
        if (Uses > 0)
        {
            if (Fluffy.GetComponent<FluffyVariables>().IsCannibal == true && !string.IsNullOrEmpty(CannibalMessage))
            {
                Fluffy.GetComponent<FluffyScript>().Message(CannibalMessage, null, null, "fwuffy");
            }
            else
            {
                Fluffy.GetComponent<FluffyScript>().Message(Message, null, null, "fwuffy");
            }
            Fluffy.GetComponent<FluffyVariables>().Hunger -= Hunger;
            Uses -= 1;
            if (gameObject.transform.Find("Effects"))
            {
                GameObject Effects = Instantiate(gameObject.transform.Find("Effects").gameObject);
                Effects.SetActive(true);
                Effects.transform.parent = Fluffy.transform;
            }
            if (Uses == 0)
            {
                foreach (Transform child in gameObject.transform)
                {
                    if (child.name == "Effects")
                    {
                        Destroy(child.gameObject);
                    }
                }
                if (SingleUse == false)
                {
                    gameObject.tag = "Untagged";
                    foreach (Transform food in gameObject.transform)
                    {
                        if (food.name == "Food")
                        {
                            food.gameObject.SetActive(false);
                        }
                    }
                }
                else
                {
                    if (gameObject.CompareTag("Corpse"))
                    {
                        GameObject SpawnedBlood = Instantiate((GameObject)Resources.Load("Blood"));
                        SpawnedBlood.transform.position = gameObject.transform.position;
                        List<GameObject> Children = new List<GameObject>();
                        foreach (Transform child in gameObject.transform)
                        {
                            if (child.gameObject.GetComponent<FoodScript>())
                            {
                                Children.Add(child.gameObject);
                            }
                        }
                        foreach (GameObject child in Children)
                        {
                            Destroy(child.gameObject.GetComponent<HingeJoint2D>());
                            child.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
                            child.transform.parent = null;
                        }
                    }
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            Fluffy.GetComponent<FluffyScript>().Message("<name> wan' nummies, tu... huu...", null, null, "fwuffy");
        }
    }
}
