using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private GameManager _gm;
    private SpriteColor _spriteColor;
    private CameraFollow _camShake;

    [SerializeField] private float _camShakeMagnitude, _camShakeDuration;

    private void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _spriteColor = GetComponent<SpriteColor>();
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
        MakePlayerInvulnerable();
        _spriteColor.PlaySpriteDamageFlash();
        StartCoroutine(_camShake.Shaking(_camShakeDuration, _camShakeMagnitude));
        yield return new WaitForSeconds(0.1f);
        _gm.Respawn();
        _spriteColor.PlayInvulnerabilityFlash();
        yield return new WaitForSeconds(1f);
        RestorePlayerVulnerability();
        _spriteColor.StopInvulnerabilityFlash();
    }

    private void MakePlayerInvulnerable()
    {
        GetComponent<CircleCollider2D>().enabled = false;
    }

    private void RestorePlayerVulnerability()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }
}
