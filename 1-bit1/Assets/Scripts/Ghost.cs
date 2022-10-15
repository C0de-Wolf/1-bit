using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    private float speed;
    private float StoppingDistance;
    private float RetreatDistance;
    private Transform TargetPlayer;

    private float TimebetweenShots;
    public float StartTimebetweenShots;

    public GameObject Projectile;



    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2.400f, 3.560f);
        StoppingDistance = Random.Range(1.450f, 2.400f);
        RetreatDistance = Random.Range(0.300f, 1.500f);
        TargetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        TimebetweenShots = StartTimebetweenShots;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > TargetPlayer.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (transform.position.x < TargetPlayer.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Vector2.Distance(transform.position, TargetPlayer.position) > StoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, TargetPlayer.position, speed * Time.deltaTime);
        } else if (Vector2.Distance(transform.position, TargetPlayer.position) < StoppingDistance && Vector2.Distance(transform.position, TargetPlayer.position) > RetreatDistance)
        {
            transform.position = this.transform.position;
        } else if (Vector2.Distance(transform.position, TargetPlayer.position) < RetreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, TargetPlayer.position, -speed * Time.deltaTime);

        }
        if (TimebetweenShots <= 0)
        {
            Instantiate(Projectile, transform.position, transform.rotation);
            TimebetweenShots = StartTimebetweenShots;
        }
        else
        {
            TimebetweenShots -= Time.deltaTime;
        }
    }
}
