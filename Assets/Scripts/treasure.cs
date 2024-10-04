using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasure : MonoBehaviour
{
    public GameObject UI_Treasure;
    void Start()
    {
        UI_Treasure.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            UI_Treasure.SetActive(true);
            Destroy(gameObject);
        }
    }
}
