using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private List<Transform> _spawnPos;

    private void SpawnEnemyAtLocation(Transform spawnTransform)
    {
        Instantiate(_enemy, spawnTransform.position,spawnTransform.rotation);
    }

    public void SpawnAllEnemies()
    {
        for(int i=0;i<_spawnPos.Count;i++)
        {
            SpawnEnemyAtLocation(_spawnPos[i]);
        }
    }
}
