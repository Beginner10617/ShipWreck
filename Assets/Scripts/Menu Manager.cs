using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject inst;
    public AudioManager audioManager;
    public GameObject bkc;
    public void ClickSound()
    {
        audioManager.SFX.PlayOneShot(audioManager.Click);
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
    public void Instructions()
    {
        inst.SetActive(true);
        bkc.SetActive(false);
    }
    public void BackToMenu()
    {
        inst.SetActive(false);
        bkc.SetActive(true);
    }
}
