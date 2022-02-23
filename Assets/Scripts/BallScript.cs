using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Play(FluffyScript Fluffy)
    {
        Fluffy.Message("baww! wheeeee!", null, null, null);
        Fluffy.SpawnParticle("Heart Particle");
        if (Fluffy.gameObject.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-250, 300));
            gameObject.GetComponent<Rigidbody2D>().AddTorque(-80);
        } else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(250, 300));
            gameObject.GetComponent<Rigidbody2D>().AddTorque(80);
        }
    }
}