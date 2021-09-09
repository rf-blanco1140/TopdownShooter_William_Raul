using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject muzzleFlash;
    public float bulletForce = 20f;

    private void Start()
    {
        StartCoroutine(ShootingCycle());
    }

    void Shoot()
    {
        Instantiate(muzzleFlash, firePoint.position, Quaternion.identity);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    IEnumerator ShootingCycle()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(2f);
        }
    }
}
