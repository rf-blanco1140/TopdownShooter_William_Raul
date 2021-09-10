using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemiesLeft = 0;
    bool killedAllEnemies = false;
    public GameObject door;

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;

        if (enemiesLeft > 0)
        {
            door.SetActive(true);
        }
        if (enemiesLeft == 0)
        {
            door.SetActive(false);
        }
    }
}
