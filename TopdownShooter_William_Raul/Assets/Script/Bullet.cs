using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    public void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer != LayerMask.NameToLayer("Bullet"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        //    if (!collision.gameObject.CompareTag("PlayerBullet"))
        //{
        //    GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //    Destroy(gameObject);
        //}

    }
}
