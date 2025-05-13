using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject winPanel;

    public Text goalText;

    int score = 0;
    int goal = 5;
    bool isGamePaused = false;  // Flag to track if the game is paused

    // Start is called before the first frame update
    void Start()
    {
        UpdateGoalText();

    }

    // Update is called once per frame
    void Update()
    {


    }

    void UpdateGoalText()
    {
        if (goalText != null)
        {
            goalText.text = score.ToString() + " / " + goal.ToString();
        }
        else
        {
            Debug.LogWarning("Goal Text is not assigned!");
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateGoalText();

        if (score >= goal)
        {
            Debug.Log("Goal achieved!");
            // Add logic here for win condition
            ShowWinPanel();
        }

    }

    void ShowWinPanel()
    {
        // Pause the game and show the win panel
        Time.timeScale = 0f; // Pause the game
        winPanel.SetActive(true); // Activate the win panel
        isGamePaused = true;

    }
}
