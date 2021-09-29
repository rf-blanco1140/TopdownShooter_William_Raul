using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathEffect;
    private GameManager _gm;
    private SpriteColor _spriteColor;
    private CameraFollow _camShake;

    [SerializeField] private float _camShakeMagnitude, _camShakeDuration;

    private void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _camShake = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
    }

    public void StartDeathProcess()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        StartCoroutine(DeathProcess());

    }

    IEnumerator DeathProcess()
    {
        MakePlayerInvulnerable();
        StartCoroutine(_camShake.Shaking(_camShakeDuration, _camShakeMagnitude));
        yield return new WaitForSeconds(0.1f);
        _gm.Respawn();
        yield return new WaitForSeconds(1f);
        RestorePlayerVulnerability();
    }

    private void MakePlayerInvulnerable()
    {
        //GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    private void RestorePlayerVulnerability()
    {

        //GetComponent<BoxCollider2D>().enabled = true;
    }
}
