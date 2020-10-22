using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 6f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 5f;

    Ball ball;
    GameSession gameSession;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameSession = FindObjectOfType<GameSession>();
        Debug.Log("Screen.width " + Screen.width);
    }

    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        } else
        {
            Debug.Log("Input.mousePosition.x " + Input.mousePosition.x);
            Debug.Log("Transformed X " + Input.mousePosition.x / Screen.width * screenWidthInUnits);
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
