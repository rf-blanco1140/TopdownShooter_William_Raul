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

    [SerializeField] private AudioClip _shootingClip;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        StartCoroutine(ShootingCycle());
        _audioSource.clip = _shootingClip;
    }

    void Shoot()
    {
        Instantiate(_muzzleFlash, _firePoint.position, Quaternion.identity);
        _audioSource.Play();
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
    }

    public void StopShoot()
    {
        StopCoroutine(ShootingCycle());
    }

    IEnumerator ShootingCycle()
    {
        while(true)
        {

            if (GetComponent<EnemyHP>()._hp <= 0)
            {
                StopShoot();
            }
            else
            Shoot();
            yield return new WaitForSeconds(_shootingFrequency);
        }
    }

}
