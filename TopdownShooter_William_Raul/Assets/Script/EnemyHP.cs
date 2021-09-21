using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private int _hp;
//    private SpriteColor _spriteColorRef;
    [SerializeField] private Animator _animator;
    public GameObject deathEffect;

    [SerializeField] private AudioClip _explosionClip;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
//        _spriteColorRef = GetComponent<SpriteColor>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerBullet")
        {
            ReceiveDamage();
            if (_hp <= 0)
            {
                StartCoroutine(DeathProcess());
            }
        }
    }

    private void ReceiveDamage()
    {
        _hp--;
        StartCoroutine(DamageSpriteEffect());

    }

    IEnumerator DamageSpriteEffect()
    {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].color = Color.red;
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].color = new Color(1, 1, 1, 1);
        }
    }
    IEnumerator DeathProcess()
    {
        if(_animator != null)
        {
            PlayDeathAnimation();
        }
        //_spriteColorRef.PlaySpriteDamageFlash(); //TODO create separate methods for damage color and for death color

        yield return new WaitForSeconds(0.5f);
        _audioSource.clip = _explosionClip;
        _audioSource.volume = 1f;
        _audioSource.Play();
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //yield return new WaitForSeconds(1.1f);
        Destroy(this.gameObject);
    }

    private void PlayDeathAnimation()
    {
        _animator.SetTrigger("Dead");
    }
}
