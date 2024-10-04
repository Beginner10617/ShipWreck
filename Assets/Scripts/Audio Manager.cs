using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] public AudioSource background;
    [SerializeField] public AudioSource SFX;
    [Header("Clips")]
    [SerializeField] public AudioClip Treasure;
    [SerializeField] public AudioClip GameOver;
    [SerializeField] public AudioClip Warning;
    [SerializeField] public AudioClip DoorOpen;
    [SerializeField] public AudioClip Movement;
    [SerializeField] public AudioClip BackgroundClip;
    [SerializeField] public AudioClip Coin;
    void Start()
    {
        background.clip = BackgroundClip;
        background.Play();   
    }

    void Update()
    {
        
    }
}
