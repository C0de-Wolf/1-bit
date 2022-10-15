using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xaxismovingplatform : MonoBehaviour
{
    private float min;
    private float max;
    public float range = 3f;
    public float speed = 2f;
    // Use this for initialization
    void Start()
    {

        min = transform.position.x -(range/2);
        max = transform.position.x + (range/2);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, max - min) + min, transform.position.y, transform.position.z);
    }
}
