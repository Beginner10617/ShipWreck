using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndGame : MonoBehaviour
{
    public AudioManager audioManager;
    public TextMeshProUGUI score;
    public TextMeshProUGUI UIScore;
    void Start()
    {
        audioManager.SFX.PlayOneShot(audioManager.GameOver);
        score.text = UIScore.text;
        Invoke("STOP", 1f);
    }
    void STOP()
    {
            audioManager.background.gameObject.SetActive(false);
            audioManager.SFX.gameObject.SetActive(false);
        
    }
}
