using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform firePoint;

    public float shootRateLow = 0.5f;
    public float shootRateHigh = 1f;
    private float nextShoot = 0f;

    private float bulletForce = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextShoot)
        {
            Shoot();

            nextShoot = Time.time + 1f / Random.Range(shootRateLow, shootRateHigh);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Debug.Log(bullet);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
