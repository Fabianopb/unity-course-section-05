using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUp : MonoBehaviour
{
    Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    private void OnMouseDown()
    {
        ball.Launch();
        Destroy(gameObject);
    }
}
