using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHook : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
