using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private CameraFollow _camShake;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject muzzleFlash;

    public float bulletForce = 20f;
    public float shootCooldown = 1f;
    public float camShakeMagnitude, camShakeDuration;

    private bool _alreadyAttacked;
    [SerializeField] private AudioClip _shootingClip;
    [SerializeField] private AudioClip _loadedGunClip;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _camShake = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        _audioSource.clip = _shootingClip;
    }

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
        if (!_alreadyAttacked)
        {
            _audioSource.clip = _shootingClip;
            _audioSource.Play();
            Instantiate(muzzleFlash, firePoint.position, Quaternion.identity);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);


            StartCoroutine(_camShake.Shaking(camShakeDuration, camShakeMagnitude));

            _alreadyAttacked = true;
            Invoke(nameof(ResetShootReload), shootCooldown);
        }
    }

    private void ResetShootReload()
    {
        _audioSource.clip = _loadedGunClip;
        _audioSource.Play();
        Invoke(nameof(ResetShoot), shootCooldown);
    }

    private void ResetShoot()
    {
        _alreadyAttacked = false;

    }

    public CameraFollow GetCamShake()
    {
        return _camShake;
    }
}
