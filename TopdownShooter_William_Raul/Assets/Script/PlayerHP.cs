using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int _currentHP = 3;
    [SerializeField] private int _maxHP = 3;
    private PlayerDeath _playerDeathRef;
    public Text healthText;
    private int _health;

    private void Start()
    {
        _playerDeathRef = GetComponent<PlayerDeath>();
    }

    private void Update()
    {
        _health = _currentHP;
        healthText.text = _health.ToString();
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
                Debug.Log("HP: " + _currentHP);//ONLY FOR TESTING
            }
        }
    }

    private void ReceiveDamage()
    {
        _currentHP--;
        Debug.Log("HP: "+_currentHP);//ONLY FOR TESTING
    }

    public void RestoreOneHP()
    {
        if(_currentHP<_maxHP)
        {
            _currentHP++;
            Debug.Log("HP: " + _currentHP);//ONLY FOR TESTING
        }
    }
}
