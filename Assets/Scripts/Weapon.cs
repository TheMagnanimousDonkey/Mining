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
    private IronUpdate ironUpdate;

    private void Start()
    {
        ironUpdate = GetComponent<IronUpdate>();
        StartCoroutine(Delay());
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        
    }

    IEnumerator Delay()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Instantiate(enemySpawn, enemySpawnPoint.position, Quaternion.identity);
            StartCoroutine(ShootDelay());
        };
    }
    IEnumerator ShootDelay()
    {

    yield return new WaitForSeconds(2);

        if (ironUpdate.ironCount > 0)
        {
            Shoot();
            ironUpdate.IronShoot();
        }
        

    }
}
