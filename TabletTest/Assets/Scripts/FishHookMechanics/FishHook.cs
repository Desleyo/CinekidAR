using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHook : MonoBehaviour
{
    [SerializeField] TweenTester tween;
    [SerializeField] float cooldown = 3f;
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
            StartCoroutine(HookCooldown());
        }
    }

    IEnumerator HookCooldown()
    {
        inCooldown = true;

        yield return new WaitForSeconds(cooldown);

        Destroy(gameObject);
    }

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

        HookTriggered(false);
        GetComponent<Collider>().enabled = false;
    }
}
