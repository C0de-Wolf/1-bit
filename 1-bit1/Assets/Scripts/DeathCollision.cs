using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollision : MonoBehaviour
{
    public Transform StartPos;
    private Transform PlayerPos;
    private void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPos.position = StartPos.position;
        }
    }
}
