using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;

    [SerializeField] private Vector3 _lastCheckPoint;

    public Vector3 LastCheckPoint
    {
        get { return _lastCheckPoint; }
        set { _lastCheckPoint = value; }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            KillPlayer();
        }
    }

    /**
     * This method is only for testing purposes
     */
    public void KillPlayer()
    {
        _player.transform.position = LastCheckPoint;
    }

    public void SetCheckpoint(Vector3 pCheckPoint)
    {
        LastCheckPoint = pCheckPoint;
    }
}