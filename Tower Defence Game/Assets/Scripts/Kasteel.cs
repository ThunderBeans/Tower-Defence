using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kasteel : MonoBehaviour
{
    public int health = 500;
    public bool attacked;
    public TextMeshProUGUI healthText; // Reference to the TextMeshPro component
    public TextMeshProUGUI timerText; // Reference to the TextMeshPro component
    public float timerDuration = 300f; // Timer duration in seconds (5 minutes)
    private float timer; // Current timer value

    private void Start()
    {
        UpdateHealthText();
        timer = timerDuration; // Set the initial timer value
    }

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Death");
        }

        // Decrease the timer value
        timer -= Time.deltaTime;

        // Update the timer text
        UpdateTimerText(timer);

        if (timer <= 0f)
        {
            LoadWinScene();
        }
    }

    public void Damage()
    {
        Debug.Log("ow");
        attacked = false;
        health -= 10;
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        // Update the text displayed in the TextMeshPro component
        healthText.text = "Health: " + health.ToString();
    }

    private void UpdateTimerText(float time)
    {
        // Convert the time to minutes and seconds
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        // Update the text displayed in the TextMeshPro component
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    private void LoadWinScene()
    {
        SceneManager.LoadScene("Won");
    }
}
