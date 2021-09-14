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

    public float camShakeMagnitude, camShakeDuration;
    private CameraFollow _camShake;

    // Update is called once per frame
    private void Start()
    {
        _camShake = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
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
                StartCoroutine(_camShake.Shaking(camShakeDuration, camShakeMagnitude));
            }

        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
}

