using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10.0f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 12;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void IncreaseScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }
}
