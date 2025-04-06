using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField] private int enemyHit;
    [SerializeField] private int playerHit;
    public static int totalScore = 0;
    public int currentScore = 0;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    private void UpdateScore(int score)
    {
        currentScore += score;

        currentScore = Mathf.Clamp(currentScore, 0, int.MaxValue);

        scoreText.text = currentScore.ToString();
    }

    public void OnEnemyHit()
    {
        UpdateScore(enemyHit);
    }

    public void OnPlayerHit()
    {
        UpdateScore(playerHit);
    }
}
