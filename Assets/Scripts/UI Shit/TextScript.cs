using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public void Fade(string text)
    {
        StopAllCoroutines();
        StartCoroutine(FadeText(text));
    }

    private IEnumerator FadeText(string text)
    {
        gameObject.GetComponent<Text>().text = text;
        gameObject.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(3);
        float alpha = 1;
        while (alpha > 0)
        {
            yield return null;
            alpha -= 0.25f * Time.deltaTime;
            gameObject.GetComponent<Text>().color = new Color(1, 1, 1, alpha);
        }
        gameObject.SetActive(false);
    }
}
