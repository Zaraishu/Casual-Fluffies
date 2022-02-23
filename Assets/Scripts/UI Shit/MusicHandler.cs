using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour {

	// Update is called once per frame
	public IEnumerator Transition (string Track) {
		while (gameObject.GetComponent<AudioSource>().volume > 0)
        {
            yield return 0;
            gameObject.GetComponent<AudioSource>().volume -= 0.1f * Time.deltaTime;
        }
        gameObject.GetComponent<AudioSource>().volume = 1;
        gameObject.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Music/" + Track);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
