using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1 = null;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] AudioClip[] ballSounds = null;

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    AudioSource audioSource;
 
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchMouseOnClick();
        }
    }

    private void LaunchMouseOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length - 1)];
            audioSource.PlayOneShot(clip);
        }
    }
}
