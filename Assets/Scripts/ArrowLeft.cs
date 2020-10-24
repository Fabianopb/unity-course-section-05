using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLeft : MonoBehaviour
{
    Paddle paddle;

    private void Start()
    {
        paddle = FindObjectOfType<Paddle>();
    }

    private void OnMouseDown()
    {
        paddle.SetIsMovingLeft(true);
    }

    private void OnMouseUp()
    {
        paddle.SetIsMovingLeft(false);
    }
}
