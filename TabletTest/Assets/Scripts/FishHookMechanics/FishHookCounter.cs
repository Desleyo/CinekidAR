using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishHookCounter : MonoBehaviour
{
    public static FishHookCounter fishHookCounter;
    [SerializeField] Text fishHooksStoppedText;

    int fishHooksStopped;

    private void Awake()
    {
        fishHookCounter = this;

        fishHooksStoppedText.text = "Vishaken gestopt: " + GetFishHooksStoppedAsString();
    }

    public void FishHookGotStopped()
    {
        fishHooksStopped++;
        fishHooksStoppedText.text = "Vishaken gestopt: " + GetFishHooksStoppedAsString();
    }

    public string GetFishHooksStoppedAsString()
    {
        return fishHooksStopped.ToString();
    }
}
