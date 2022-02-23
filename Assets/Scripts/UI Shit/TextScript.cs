using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {
	
	// Update is called once per frame
	public IEnumerator Fade () {
        gameObject.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(3);
        float Alpha = 1;
        while (Alpha > 0)
        {
            yield return 0;
            Alpha -= 0.25f * Time.deltaTime;
            gameObject.GetComponent<Text>().color = new Color(1, 1, 1, Alpha);
        }
        gameObject.SetActive(false);
	}
}
