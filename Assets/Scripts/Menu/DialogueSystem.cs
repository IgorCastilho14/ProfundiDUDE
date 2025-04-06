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
    [SerializeField] private GameObject finalButton;
    [SerializeField] private float typingSpeed;

    private void Start()
    {
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
            finalButton.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
