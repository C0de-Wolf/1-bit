using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] enemy;
    private int zVal;
    public int DeathSec;

    public float SpawnStartTime;
    private float SpawnTimeCounter;

    private int insNum;
    public int mininstNum;
    public int maxintNum;

    private int RandomPrefab;

    private void Start()
    {
        SpawnTimeCounter = SpawnStartTime;

    }
    void Update()
    {
        
        SpawnTimeCounter -= Time.deltaTime;


        if (SpawnTimeCounter <= 0)
        {
            insNum = Random.Range(mininstNum, maxintNum);
            GameObject[] clone = new GameObject[insNum];

            for (int i = 0; i < insNum; i++)
            {
                zVal = Random.Range(-360, 360);
                RandomPrefab = Random.Range(0,2);
                Instantiate(enemy[RandomPrefab], transform.position, Quaternion.Euler(new Vector3(0, 0, zVal)));
                Destroy(GameObject.FindWithTag("Obstacle"), DeathSec);
                Destroy(GameObject.FindWithTag("Obstacle"), DeathSec);
                Destroy(GameObject.FindWithTag("Obstacle"), DeathSec);
                Destroy(GameObject.FindWithTag("Obstacle"), DeathSec);

            }

            SpawnTimeCounter = SpawnStartTime;
        }
    

    }
}
