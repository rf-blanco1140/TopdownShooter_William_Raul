using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemySoldier : MonoBehaviour
{
    private SpriteColor _spriteColorRef;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _spriteColorRef = GetComponent<SpriteColor>();
    }

    IEnumerator DeathProcess()
    {
        PlayDeathAnimation();
        //_spriteColorRef.PlaySpriteDamageFlash();
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    private void PlayDeathAnimation()
    {
        _animator.SetTrigger("Dead");
    }
}
