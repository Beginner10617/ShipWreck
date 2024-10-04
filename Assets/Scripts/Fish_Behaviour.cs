using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Behaviour : MonoBehaviour
{
    public float speed;
    public float pause;
    public Transform startPoint;
    public Transform endPoint;
    public float minimum_vicinity;

    
    float time = 0;    
    float random;
    Vector3 Point = new Vector3();
    Vector3 StartPoint = new Vector3();
    Vector3 EndPoint = new Vector3();
    
    void Start()
    {
        Point = transform.position;
        StartPoint = startPoint.position;
        EndPoint = endPoint.position;
    }
    void Update()
    {
        time += Time.deltaTime;
        if(time>pause)
        {
            time = 0;
            random = Random.value;
            Point = random * StartPoint + (1-random) * EndPoint;
            transform.localScale = Vector3.Normalize(transform.position - Point) + new Vector3(0,1,1);
        }
        else if(Vector2.Distance(Point,transform.position)>minimum_vicinity)
        {
            transform.position += speed * Time.deltaTime * Vector3.Normalize(Point - transform.position);
        }
    }
}
