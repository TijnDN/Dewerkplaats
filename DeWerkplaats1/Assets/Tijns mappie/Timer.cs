using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float timeLeft = 60f;          // Start time in seconds
    public TextMeshProUGUI timerText;    // Drag your text here

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeLeft / 60);
            int seconds = Mathf.FloorToInt(timeLeft % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timerText.text = "00:00";
            Debug.Log("Time's up!");
            enabled = false; // stops the script
        }
    }
}