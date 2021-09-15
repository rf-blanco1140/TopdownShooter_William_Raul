using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimAtPlayer : MonoBehaviour
{
    private Vector2 _playerPos;
    private Rigidbody2D _rb;
    private Vector2 _lookingDir;
    private float _rotationAngle;

    private void Start()
    {
        _playerPos = GameObject.Find("PlayerTank").transform.position;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _playerPos = GameObject.Find("PlayerTank").transform.position;
    }

    private void FixedUpdate()
    {
        _lookingDir = _playerPos - _rb.position;
        _rotationAngle = Mathf.Atan2(_lookingDir.y, _lookingDir.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = _rotationAngle;
    }
}
