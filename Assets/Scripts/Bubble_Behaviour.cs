using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_Behaviour : MonoBehaviour
{
    public float Surface;
    void Update()
    {
        if(transform.position.y > Surface)
        {
            Destroy(gameObject);
        }    
    }
}
