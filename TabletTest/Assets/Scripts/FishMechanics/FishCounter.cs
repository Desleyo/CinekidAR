using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishCounter : MonoBehaviour
{
    public static FishCounter fishCounter;

    [SerializeField] Text debugText;
    int currentFishAmount;

    private void Awake()
    {
        fishCounter = this;
    }

    private void Start()
    {
        currentFishAmount = FindObjectOfType<Flock>().flockSize;
        debugText.text = currentFishAmount.ToString();
    }

    public void FishGotHooked()
    {
        currentFishAmount--;
        debugText.text = currentFishAmount.ToString();
    }
}
