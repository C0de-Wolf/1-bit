using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemylifeScript : MonoBehaviour
{
    public int health;

 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health == 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
