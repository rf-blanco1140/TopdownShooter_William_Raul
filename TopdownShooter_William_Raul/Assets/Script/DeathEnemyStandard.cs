using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemyStandard : MonoBehaviour
{
    private SpriteColor _spriteColorRef;

    private void Start()
    {
        _spriteColorRef = GetComponent<SpriteColor>();
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
        _spriteColorRef.PlaySpriteDamageFlash();
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
