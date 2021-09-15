using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TankMovement _player;
    private SpawnEnemies _enemySpawnnerRef;

    [SerializeField] private Vector3 _lastCheckPoint;

    private void Start()
    {
        _player = GameObject.Find("PlayerTank").GetComponent<TankMovement>();
        _enemySpawnnerRef = GameObject.Find("Spawner").GetComponent<SpawnEnemies>();
    }

    public Vector3 LastCheckPoint
    {
        get { return _lastCheckPoint; }
        set { _lastCheckPoint = value; }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Respawn();
        }
    }

    /**
     * This method is only for testing purposes
     */
    public void Respawn()
    {
        DestroyAllEnemies();
        _enemySpawnnerRef.SpawnAllEnemies();
        _player.transform.position = LastCheckPoint;
    }

    public void SetCheckpoint(Vector3 pCheckPoint)
    {
        LastCheckPoint = pCheckPoint;
    }

    private void DestroyAllEnemies()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i=0;i<enemyList.Length;i++)
        {
            Destroy(enemyList[i]);
        }
    }
}
