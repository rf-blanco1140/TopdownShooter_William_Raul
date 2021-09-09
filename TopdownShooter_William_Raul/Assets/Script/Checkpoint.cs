using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameManager _gm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SetCheckPoint();
        }
    }

    public void SetCheckPoint()
    {
        _gm.SetCheckpoint(transform.position);
    }
}
