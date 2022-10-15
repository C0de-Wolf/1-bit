using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public float startTimeBetweenSpawns;
    private float TimebetweenSpawns;
    public float SpawnDistance;
    public GameObject Ghosts;

    // Start is called before the first frame update
    void Start()
    {
       TimebetweenSpawns = startTimeBetweenSpawns;
       Instantiate(Ghosts, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform.position, gameObject.transform.position) <= SpawnDistance)
        {

            if (TimebetweenSpawns <= 0)
            {
                Instantiate(Ghosts, transform.position, transform.rotation);
                TimebetweenSpawns = startTimeBetweenSpawns;
            }
            else
            {
                TimebetweenSpawns -= Time.deltaTime;
            }
        }
    }
}
