using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private SpriteColor _spriteColor;

    private void Start()
    {
        _spriteColor = GetComponent<SpriteColor>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerBullet")
        {
            StartCoroutine(DeathProcess());
        }
    }

    IEnumerator DeathProcess()
    {
        _spriteColor.PlaySpriteDamageFlash();
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

}
