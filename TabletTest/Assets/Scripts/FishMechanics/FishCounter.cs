using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishCounter : MonoBehaviour
{
    public static FishCounter fishCounter;
    [SerializeField] Text debugText;
    int currentFishAmount;
    int flocks;

    private void Awake()
    {
        fishCounter = this;
    }

    private void Start()
    {
        flocks = FindObjectsOfType<Flock>().Length;
        currentFishAmount = FindObjectOfType<Flock>().flockSize * flocks;
        
        debugText.text = currentFishAmount.ToString();
    }

    public void FishGotHooked()
    {
        currentFishAmount--;
        debugText.text = currentFishAmount.ToString();
    }
}
