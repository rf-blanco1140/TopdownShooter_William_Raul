using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] List<Transform> spawnPos;

    private void Start()
    {
        SpawnAllEnemies();
    }
    
    private void SpawnEnemyAtLocation(Transform spawnTransform)
    {
        Instantiate(enemy, spawnTransform.position,spawnTransform.rotation);
    }

    private void SpawnAllEnemies()
    {
        for(int i=0;i<spawnPos.Count;i++)
        {
            SpawnEnemyAtLocation(spawnPos[i]);
        }
    }
}
