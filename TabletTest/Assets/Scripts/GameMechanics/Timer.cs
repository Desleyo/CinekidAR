using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;
    [SerializeField] GameObject endScreenPanel;
    [SerializeField] Text fishLeftText;

    [Space, SerializeField] Text timerText;
    [SerializeField] float timeInMinutes;

    float currentTime;
    bool gameHasEnded;

    private void Awake()
    {
        Time.timeScale = 1f;

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

        infoPanel.SetActive(false);
        endScreenPanel.SetActive(true);

        fishLeftText.text = "Er zijn nog: " + FishCounter.fishCounter.GetCurrentFishCountAsString() + " vissen over " +
        "\n Je hebt: " + FishHookCounter.fishHookCounter.GetFishHooksStoppedAsString() + " haken en netten gestopt" +
        "\n Zonder jou zouden deze vissen uitsterven \n Goed zo!";

        Time.timeScale = 0f;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}