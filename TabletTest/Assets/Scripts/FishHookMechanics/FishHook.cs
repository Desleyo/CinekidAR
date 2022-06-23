using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHook : MonoBehaviour
{
    [SerializeField] TweenTester tween;
    [SerializeField] float destroyCooldown = 3f;
    [SerializeField] float fishHookWaitTime = 1f;

    bool inCooldown;

    private void Start()
    {
        HookTriggered(true);
    }

    public void HookTriggered(bool shouldLowerHook)
    {
        if (inCooldown)
            return;

        tween.StartEasing(shouldLowerHook);

        if (!shouldLowerHook)
        {
            inCooldown = true;
            Destroy(gameObject, destroyCooldown);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Fish"))
            return;

        StartCoroutine(ReturnHook(other.gameObject));
    }

    IEnumerator ReturnHook(GameObject fish)
    {
        yield return new WaitForSeconds(fishHookWaitTime);

        fish.SetActive(false);
        FishCounter.fishCounter.FishGotHooked();

        HookTriggered(false);
        GetComponent<Collider>().enabled = false;
    }
}
