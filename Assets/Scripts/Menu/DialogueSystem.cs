using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private List<string> dialogueList;
    [SerializeField] private TextMeshProUGUI textObject;
    [SerializeField] private TextMeshProUGUI totalScoreObject;
    [SerializeField] private GameObject finalButton;
    [SerializeField] private float typingSpeed;
    [SerializeField] private GameObject kaleo;
    [SerializeField] private GameObject skipButton;

    private void Start()
    {
        if(LevelManager.HasFinishedGame)
        {
            skipButton.SetActive(true);
        }
        
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        foreach (var dialogue in dialogueList)
        {
            textObject.text = "";

            foreach (char c in dialogue)
            {
                textObject.text += c;
                yield return new WaitForSeconds(typingSpeed);
            }

            yield return new WaitForSeconds(2f);
        }

        if(SceneManager.GetActiveScene().name == "EndingLevel")
        {
            textObject.text = "";

            totalScoreObject.text = ScoreManager.totalScore.ToString();

            finalButton.SetActive(true);

            kaleo.GetComponent<Animator>().SetBool("StopTalking", true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void SkipScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
