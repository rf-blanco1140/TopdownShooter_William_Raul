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
    private CameraFollow _camShake;

    [SerializeField] private AudioClip _tracksClip;
    [SerializeField] private AudioSource _audioSource;
    private float _playSoundTime = 5.0f;
    private float _currentSoundTime = 5.0f;

    // Update is called once per frame
    private void Start()
    {
        _camShake = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        _audioSource.clip = _tracksClip;
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
            _currentSoundTime += Time.deltaTime;
            Instantiate(moveEffect, wheel1.position, Quaternion.identity);
            Instantiate(moveEffect, wheel2.position, Quaternion.identity);

            if(_currentSoundTime >= _playSoundTime)
            {
                _audioSource.Play();
                _currentSoundTime = 0f;
            }

            if (!Input.GetMouseButtonDown(0))
            {
                StartCoroutine(_camShake.Shaking(camShakeDuration, camShakeMagnitude));
            }

        }

        else if(_audioSource.isPlaying)
        {
            _audioSource.Stop();
            _currentSoundTime = 5.0f;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
}

