using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timercountdown : MonoBehaviour
{
    // Start is called before the first frame update

    private float timer = 0f;
    private TextMeshProUGUI timerText;

    private void Start()
    {
        // Get the TextMeshPro component from the GameObject
        timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Update the TextMeshPro text with the formatted timer value
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        // Format the timer as minutes and seconds
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");

        // Update the TextMeshPro text
        timerText.text = $"Session Time: {minutes}:{seconds}";
    }
}
