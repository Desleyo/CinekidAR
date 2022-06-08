using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] TweenTester tween;
    [SerializeField] float cooldown = 2f;
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
}
