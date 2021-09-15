using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameManager _gm;
    private bool _unused;
    [SerializeField] List<SpawnEnemies> _roomEnemySpawners;
    

    private void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SetCheckPoint(collision.gameObject.GetComponent<PlayerHP>());
        }
    }

    public void SetCheckPoint(PlayerHP pPlayerHP)
    {
        if(!_unused)
        {
            _unused = true;
            _gm.SetCurrentEnemySpawnner(_roomEnemySpawners);
            _gm.SetCheckpoint(transform.position);
            pPlayerHP.RestoreOneHP();
        }
    }
}
