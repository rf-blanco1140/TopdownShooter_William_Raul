using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemiesLeft = 0;
    bool killedAllEnemies = false;
    void Start()
    {
        enemiesLeft = 10; // or whatever;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        enemiesLeft = enemies.Length;
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    enemiesLeft--;
        //}
        if (enemiesLeft == 0)
        {
            Debug.Log("doorOpen");
        }
    }
}
