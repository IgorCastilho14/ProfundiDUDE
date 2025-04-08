using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingMenu : MonoBehaviour
{
    public void AcceptFate()
    {
        LevelManager.HasFinishedGame = true;

        ScoreManager.totalScore = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GiveUp()
    {
        LevelManager.HasFinishedGame = true;

        ScoreManager.totalScore = 0;

        SceneManager.LoadScene(0);
    }
}
