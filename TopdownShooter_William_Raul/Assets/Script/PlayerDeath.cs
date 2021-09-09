using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private GameManager _gm;
    private CameraFollow _camShake;

    [SerializeField] private float _camShakeMagnitude, _camShakeDuration;

    private void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _camShake = GetComponent<Shooting>().GetCamShake();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "EnemyBullet")
        {
            StartCoroutine(DeathProcess());
        }
    }

    IEnumerator DeathProcess()
    {
        StartCoroutine(_camShake.Shaking(_camShakeDuration, _camShakeMagnitude));
        yield return new WaitForSeconds(0.1f);
        _gm.Respawn();
    }
}
