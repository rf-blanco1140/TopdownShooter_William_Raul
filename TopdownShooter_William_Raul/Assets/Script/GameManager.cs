using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TankMovement _player;
    [SerializeField] List<SpawnEnemies> _roomEnemySpawners;

    [SerializeField] private Vector3 _lastCheckPoint;

    private void Start()
    {
        _player = GameObject.Find("PlayerTank").GetComponent<TankMovement>();
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

    public void Respawn()
    {
        DestroyAllEnemies();
        SpawnRoomEnemies();
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

    public void SetCurrentEnemySpawnner(List<SpawnEnemies> pSpawnner)
    {
        _roomEnemySpawners = pSpawnner;
        SpawnRoomEnemies();
    }

    private void SpawnRoomEnemies()
    {
        for(int i=0; i<_roomEnemySpawners.Count;i++)
        {
            _roomEnemySpawners[i].SpawnAllEnemies();
        }
    }
}
