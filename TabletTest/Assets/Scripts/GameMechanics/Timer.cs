using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject endScreenPanel;
    [SerializeField] Text fishLeftText;

    [Space, SerializeField] Text timerText;
    [SerializeField] float timeInMinutes;

    float currentTime;
    bool gameHasEnded;

    private void Awake()
    {
        currentTime = timeInMinutes * 60;
    }

    void Update()
    {
        if (gameHasEnded)
            return;

        UpdateTime();
    }
    void UpdateTime()
    {
        currentTime -= Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = "Tijd over: " + time.ToString(@"mm\:ss");
        if (currentTime <= 0)
        {
            DisplayEndScreen();
        }
    }
    void DisplayEndScreen()
    {
        gameHasEnded = true;

        endScreenPanel.SetActive(true);
        fishLeftText.text = "Er zijn nog: " + FishCounter.fishCounter.GetCurrentFishCountAsString() + " vissen over.";
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}