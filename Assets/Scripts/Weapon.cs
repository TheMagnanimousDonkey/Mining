using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject BulletPrefab;
    public Transform enemySpawnPoint;
    public GameObject enemySpawn;
    public GameObject ironText;
    private float nextSpawn = 4f;
    private IronUpdate ironUpdate;

    private void Start()
    {
        ironUpdate = GetComponent<IronUpdate>();
    }

    private void FixedUpdate()
    {

        if (Time.time > nextSpawn)
        {
            Instantiate(enemySpawn, enemySpawnPoint.position, Quaternion.identity);
            nextSpawn = nextSpawn + Random.Range(1, 3);
            StartCoroutine(Delay());
        }

    }
    void Shoot()
    {
        Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        
    }

    IEnumerator Delay()
    {

    yield return new WaitForSeconds(2);

        if (ironUpdate.ironCount > 0)
        {
            Shoot();
            ironUpdate.IronShoot();
        }
        

    }
}
