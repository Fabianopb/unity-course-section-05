using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRight : MonoBehaviour
{
    Paddle paddle;

    private void Start()
    {
        paddle = FindObjectOfType<Paddle>();
    }

    private void OnMouseDown()
    {
        paddle.SetIsMovingRight(true);
    }

    private void OnMouseUp()
    {
        paddle.SetIsMovingRight(false);
    }
}
