using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] Text text;
    [SerializeField] float currentTime;

    private void Awake()
    {
        currentTime *= 60;
    }

    void Update()
    {
        currentTime = currentTime - Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        text.text = "Time: " + time.ToString(@"mm\:ss");
    }
}