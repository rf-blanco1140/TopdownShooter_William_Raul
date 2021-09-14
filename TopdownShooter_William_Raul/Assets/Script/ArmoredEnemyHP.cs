using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredEnemyHP : MonoBehaviour
{
    [SerializeField] private int _hp;
    private SpriteColor _spriteColorRef;

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
    }

    IEnumerator DeathProcess()
    {
        _spriteColorRef.PlaySpriteDamageFlash(); //TODO create separate methods for damage color and for death color
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
