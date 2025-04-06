using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private float totalTime;
    private float remainingTime;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = totalTime;

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
            // encerrar a fase
        }
    }
}
