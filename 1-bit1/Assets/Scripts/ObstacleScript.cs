using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public Transform StartPos;
    private Transform PlayerPos;
    public float speed;
    public string[] Tags;
    private void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "Obstacle")
        {
            if (collision.CompareTag("Player"))
            {
                PlayerPos.position = StartPos.position;
                Destroy(gameObject);

            }
            for (int i = 0; i < Tags.Length; i++)
            {
                if (collision.CompareTag(Tags[i]))
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            if (collision.CompareTag("Player"))
            {
                PlayerPos.position = StartPos.position;
            }
        }
    }

}
