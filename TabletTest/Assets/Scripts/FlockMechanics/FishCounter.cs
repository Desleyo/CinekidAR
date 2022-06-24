using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishCounter : MonoBehaviour
{
    public static FishCounter fishCounter;
    [SerializeField] Text debugText;

    int flocks;
    int currentFishCount;

    private void Awake()
    {
        fishCounter = this;
    }

    private void Start()
    {
        flocks = FindObjectsOfType<Flock>().Length;
        currentFishCount = FindObjectOfType<Flock>().flockSize * flocks;
        
        debugText.text = "Vissen over: " + currentFishCount.ToString();
    }

    public void FishGotHooked()
    {
        currentFishCount--;
        debugText.text = "Vissen over: " + currentFishCount.ToString();
    }

    public string GetCurrentFishCountAsString()
    {
        return currentFishCount.ToString();
    }
}
