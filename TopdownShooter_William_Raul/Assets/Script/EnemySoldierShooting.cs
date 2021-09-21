using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldierShooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private float _bulletForce = 20f;
    [SerializeField] private float _shootingFrequency;
    [SerializeField] private Animator _animator;

    [SerializeField] private AudioClip _shootingClip;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        StartCoroutine(ShootingCycle());
        _audioSource.clip = _shootingClip;
    }

    void Shoot()
    {
        StartCoroutine(PlayShootingAnimation());
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
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(_shootingFrequency);

            if (GetComponent<EnemyHP>()._hp <= 0)
            {
                StopShoot();
            }
        }
    }
    private IEnumerator PlayShootingAnimation()
    {
        _animator.SetBool("IsShooting", true);
        yield return new WaitForSeconds(.35f);
        _animator.SetBool("IsShooting", false);
    }
}
