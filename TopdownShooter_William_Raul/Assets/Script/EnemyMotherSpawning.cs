using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotherSpawning : MonoBehaviour
{
    [SerializeField] private GameObject _spawnedEnemy;
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private int _maxChildren;
    [SerializeField] private int _currentNumberOfChildren;

    private void Start()
    {
        StartCoroutine(SpawnChildren());
    }

    private IEnumerator SpawnChildren()
    {
        yield return new WaitForSeconds(_spawnCooldown);

        while (true)
        {
            if (_currentNumberOfChildren < _maxChildren)
            {
                _currentNumberOfChildren++;
                SpawnEnemyAtLocation();
            }
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }

    private void SpawnEnemyAtLocation()
    {
        Instantiate(_spawnedEnemy, _spawnTransform.position, _spawnTransform.rotation);
    }
}
