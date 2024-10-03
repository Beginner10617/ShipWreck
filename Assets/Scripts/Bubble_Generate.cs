using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_Generate : MonoBehaviour
{
    public GameObject bubble;
    public float SpeedOfBubble;
    public float TimePeriod;
    public Transform Mouth;
    public Transform Collecter;

    float time;
    GameObject spawned;
    void Update()
    {
        time += Time.deltaTime;
        if(time>TimePeriod)
        {
            time = 0;
            spawned = Instantiate(bubble, Mouth.position, Quaternion.identity, Collecter);
            spawned.GetComponent<Rigidbody2D>().velocity = new Vector2(0,SpeedOfBubble);
        }
    }
}
