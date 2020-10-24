using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 5f;

    Ball ball;
    GameSession gameSession;

    bool isMovingRight = false;
    bool isMovingLeft = false;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    public void SetIsMovingRight(bool isMoving)
    {
        isMovingRight = isMoving;
    }

    public void SetIsMovingLeft(bool isMoving)
    {
        isMovingLeft = isMoving;
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        } else
        {
            if (isMovingRight)
            {
                return transform.position.x + 0.2f;
            }
            if (isMovingLeft)
            {
                return transform.position.x - 0.2f;
            }
            return transform.position.x;
        }
    }
}
