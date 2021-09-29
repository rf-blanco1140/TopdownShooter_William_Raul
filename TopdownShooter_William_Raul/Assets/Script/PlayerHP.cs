using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int _currentHP = 3;
    [SerializeField] private int _maxHP = 3;
    [SerializeField] private PlayerHpUi _hpUI;
    [SerializeField] private GameObject _damageParticles;
    private PlayerDeath _playerDeathRef;
    private bool _invulnerable;


    private void Start()
    {
        _playerDeathRef = GetComponent<PlayerDeath>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "EnemyBullet")
        {
            ReceiveDamage();
            if (_currentHP <= 0)
            {
                _playerDeathRef.StartDeathProcess();
                _currentHP = 3;
                _hpUI.RecoverAllHearts();
            }
            if (_currentHP <= 1)
            {
                _damageParticles.SetActive(true);
            }
            else
                _damageParticles.SetActive(false);
        }
    }

    private void ReceiveDamage()
    {
        if (!_invulnerable)
        _currentHP--;
        //Debug.Log("HP: "+_currentHP);//ONLY FOR TESTING
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();

        StartCoroutine(DamageSpriteEffect());

        _hpUI.RemoveHeart(_currentHP);
    }

    IEnumerator DamageSpriteEffect()
    {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        _invulnerable = true;
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].color = Color.red;
        }
        yield return new WaitForSeconds(1f);
        _invulnerable = false;
        for (int i = 0; i < sprites.Length; i++)
        {

            sprites[i].color = new Color(1, 1, 1, 1);
        }
    }

        public void RestoreOneHP()
    {
        if(_currentHP<_maxHP)
        {
            _currentHP++;
            _hpUI.AddHeart(_currentHP);
        }
    }
}
