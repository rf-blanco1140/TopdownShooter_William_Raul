using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector2 movement;
    public GameObject moveEffect;
    public Transform wheel1;
    public Transform wheel2;
    public Transform exhaustPort;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Instantiate(moveEffect, wheel1.position, Quaternion.identity);
            Instantiate(moveEffect, wheel2.position, Quaternion.identity);
        }
    }
    void FixedUpdate()
    {
  //      Instantiate(moveEffect, exhaustPort.position, Quaternion.identity);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
}

