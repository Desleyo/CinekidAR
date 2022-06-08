using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHook : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Fish"))
            return;

        other.gameObject.SetActive(false);

        ReturnHook();
    }

    void ReturnHook()
    {
        FishCounter.fishCounter.FishGotHooked();

        GetComponent<Collider>().enabled = false;
        GetComponentInParent<Interactable>().HookTriggered(false);
    }
}
