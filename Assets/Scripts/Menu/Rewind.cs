using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rewind : MonoBehaviour
{
    [SerializeField] private float rewindTime = 2.5f;

    void Start()
    {
        Invoke(nameof(RewindGame), rewindTime);
    }

    private void RewindGame()
    {
        SceneManager.LoadScene(1);
    }
}
