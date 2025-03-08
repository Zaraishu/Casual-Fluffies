using UnityEngine;

public class Food : MonoBehaviour
{
    public float hunger;

    public string message;
    public string cannibalMessage;

    public string tag;

    Sprite sprite;

    public int uses;
    public int maxUses;

    public bool SingleUse;
    [SerializeField]
    public AEffect Effect { get; set; }

    public void Fill(float hunger, string message, Sprite sprite, string tag)
    {
        this.hunger = hunger;
        this.message = message;
        this.sprite = sprite;
        this.tag = tag;
        uses = maxUses;
    }

    public bool HasEffect()
    {
        return Effect != null;
    }
}
