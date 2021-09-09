using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject muzzleFlash;
    public float bulletForce = 20f;
    public float camShakeMagnitude, camShakeDuration;


    public CameraFollow camShake;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(muzzleFlash, firePoint.position, Quaternion.identity);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);


        StartCoroutine(camShake.Shaking(camShakeDuration, camShakeMagnitude));
    }
}
