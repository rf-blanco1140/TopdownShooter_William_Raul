using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    //Movement
    public float moveSpeed = 5f;
    Vector2 movement;
    public Rigidbody2D rb;

    //Effects
    public Transform wheel1;
    public Transform wheel2;
    public Transform exhaustPort;
    public GameObject moveEffect;

    public float camShakeMagnitude, camShakeDuration;
    private CameraFollow camShake;

    // Update is called once per frame
    private void Start()
    {
        camShake = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

    }
    void FixedUpdate()
    {
        //      Instantiate(moveEffect, exhaustPort.position, Quaternion.identity);

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Instantiate(moveEffect, wheel1.position, Quaternion.identity);
            Instantiate(moveEffect, wheel2.position, Quaternion.identity);

            if (!Input.GetMouseButtonDown(0))
            {
                StartCoroutine(camShake.Shaking(camShakeDuration, camShakeMagnitude));
            }

        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
}

