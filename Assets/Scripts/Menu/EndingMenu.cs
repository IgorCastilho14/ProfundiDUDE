using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingMenu : MonoBehaviour
{
    public void AcceptFate()
    {
        SceneManager.LoadScene(0);
    }

    public void GiveUp()
    {
        Application.Quit();
    }
}
