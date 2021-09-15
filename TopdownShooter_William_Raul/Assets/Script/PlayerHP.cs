using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int _hp = 3;
    private PlayerDeath _playerDeathRef;

    private void Start()
    {
        _playerDeathRef = GetComponent<PlayerDeath>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "EnemyBullet")
        {
            ReceiveDamage();
            if (_hp <= 0)
            {
                _playerDeathRef.StartDeathProcess();
                _hp = 3;
            }
        }
    }

    private void ReceiveDamage()
    {
        _hp--;
        Debug.Log("HP: "+_hp);//ONLY FOR TESTING
    }
}
