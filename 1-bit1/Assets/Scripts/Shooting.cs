using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public Transform Firepoint;
    public GameObject Bulletprefab;
    public float BulletLifeSpan;
    private int CloneCount;
    public int NumberofAllowedBulletsinScene;
    public TextMeshProUGUI bulletLeft;

    private void Start()
    {
        bulletLeft.text = "Energy Left: " + (NumberofAllowedBulletsinScene - CloneCount).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && CloneCount < NumberofAllowedBulletsinScene)
        {
            StartCoroutine(Shoot());
        }
        bulletLeft.text = "Energy Left: " + (NumberofAllowedBulletsinScene - CloneCount).ToString();
    }

    IEnumerator Shoot()
    {
        GameObject bullets = Instantiate(Bulletprefab, Firepoint.position, Firepoint.rotation);
        CloneCount++;
        yield return new WaitForSeconds(BulletLifeSpan);
        Destroy(bullets);
        CloneCount--;
             
    }
}
