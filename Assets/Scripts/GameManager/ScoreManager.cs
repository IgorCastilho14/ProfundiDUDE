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

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = totalScore.ToString();
    }

    private void UpdateScore(int score)
    {
        totalScore += score;

        totalScore = Mathf.Clamp(totalScore, 0, int.MaxValue);

        scoreText.text = totalScore.ToString();
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
