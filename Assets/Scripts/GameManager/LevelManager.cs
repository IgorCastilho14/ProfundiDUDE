using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private float totalTime;
    [SerializeField] private GameObject blackHole;
    [SerializeField] private float blackHoleDistance;
    private MeteorSpawner meteorSpawner;
    private StarSpawner starSpawner;
    private float remainingTime;

    private PlayerDodging player;
    public static bool HasFinishedGame = false;

    [SerializeField] private float tutorialTime = 20f;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI tutorialText;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = totalTime;

        meteorSpawner = FindAnyObjectByType<MeteorSpawner>();

        starSpawner = FindAnyObjectByType<StarSpawner>();

        player = FindAnyObjectByType<PlayerDodging>();

        timeText.text = Mathf.Ceil(remainingTime).ToString();

        InvokeRepeating(nameof(VerifyTime), 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        tutorialTime -= Time.deltaTime;
    }

    private void VerifyTime()
    {
        timeText.text = Mathf.Ceil(remainingTime).ToString();

        if(SceneManager.GetActiveScene().name == "DodgingLevel" && tutorialTime <= 0f)
        {
            tutorialText.text = "";
        }

        if (remainingTime <= 0f)
        {
            CancelInvoke();

            if(SceneManager.GetActiveScene().name == "DodgingLevel")
            {
                meteorSpawner.StopSpawn();
                //starSpawner.StopSpawn();

                Vector3 spawnLocation = new Vector3(
                    player.transform.position.x,
                    player.transform.position.y,
                    player.transform.position.z + blackHoleDistance);

                Instantiate(blackHole, spawnLocation, Quaternion.identity);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
