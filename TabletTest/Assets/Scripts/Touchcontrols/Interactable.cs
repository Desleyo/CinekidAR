using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Space, SerializeField] float minCooldown = 3;
    [SerializeField] float maxCooldown = 5;
    bool inCooldown;
      
    private void Start()
    {
        HookTriggered();   
    }

    public void HookTriggered()
    {
        if (inCooldown)
            return;

        //Use ease mechanic

        StartCoroutine(HookCooldown(Random.Range(minCooldown, maxCooldown)));
    }

    IEnumerator HookCooldown(float cooldown)
    {
        inCooldown = true;

        yield return new WaitForSeconds(cooldown);

        //Use ease mechanic

        inCooldown = false;
    }
}
