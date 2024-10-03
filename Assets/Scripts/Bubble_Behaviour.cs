using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_Behaviour : MonoBehaviour
{
    public float Surface;
    void Start()
    {
        Surface = Surface + transform.position.y;
    }

    void Update()
    {
        if(transform.position.y > Surface || GetComponent<Rigidbody2D>().velocity.y==0)
        {
            Destroy(gameObject);
        }    
    }
}
