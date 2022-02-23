using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuScript : MonoBehaviour {

    public AudioMixer Audio;
    public AudioMixer Music;

    public void Resume()
    {
        gameObject.transform.Find("Menu").gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Options()
    {
        gameObject.transform.Find("Options").gameObject.SetActive(true);
        gameObject.transform.Find("Menu").gameObject.SetActive(false);
    }

    public void Back()
    {
        gameObject.transform.Find("Options").gameObject.SetActive(false);
        gameObject.transform.Find("Menu").gameObject.SetActive(true);
    }

    public void SetVolume(float Volume)
    {
        Audio.SetFloat("Volume", Volume);
    }

    public void SetMusic(float Volume)
    {
        Music.SetFloat("Volume", Volume);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetTime(float TimeSpeed)
    {
        Time.timeScale = TimeSpeed;
    }
}
