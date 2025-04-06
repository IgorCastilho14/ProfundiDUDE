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
    private float remainingTime;

    private PlayerDodging player;


    [Header("Text")]
    [SerializeField] private TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = totalTime;

        meteorSpawner = FindAnyObjectByType<MeteorSpawner>();

        player = FindAnyObjectByType<PlayerDodging>();

        timeText.text = Mathf.Ceil(remainingTime).ToString();

        InvokeRepeating(nameof(VerifyTime), 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
    }

    private void VerifyTime()
    {
        timeText.text = Mathf.Ceil(remainingTime).ToString();

        if (remainingTime <= 0)
        {
            CancelInvoke();

            if(SceneManager.GetActiveScene().name == "DodgingLevel")
            {
                meteorSpawner.StopSpawn();

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
