using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float nextFire = 4f;

    private void FixedUpdate()
    {
        
        if (Time.time > nextFire)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            nextFire = nextFire + Random.Range(1, 3);
        }
    }
}
