using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform PlayerTarget;
    public float Closeness;
    public float LifeSpawn = 5;


    void Start()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, PlayerTarget.position) > Closeness)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerTarget.position, speed * Time.deltaTime);
        }
        LifeSpawn -= Time.deltaTime;
        if (LifeSpawn <= 0) {
                Destroy(gameObject);
            }
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    
        
    
}
