using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private float _bulletForce = 20f;
    [SerializeField] private float _shootingFrequency;

    private void Start()
    {
        StartCoroutine(ShootingCycle());
    }

    void Shoot()
    {
        Instantiate(_muzzleFlash, _firePoint.position, Quaternion.identity);
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
    }

    IEnumerator ShootingCycle()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(_shootingFrequency);
        }
    }
}
