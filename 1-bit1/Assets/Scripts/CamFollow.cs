using System.Collections;
using UnityEngine;
public class CamFollow : MonoBehaviour
{
    private Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Vector3 desiredpos = target.position + offset;
        Vector3 smoothedpos = Vector3.Lerp(transform.position, desiredpos, smoothSpeed * Time.deltaTime);
        transform.position = smoothedpos;

        transform.LookAt(target);
    }
}
