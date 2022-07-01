using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishnetIndicator : MonoBehaviour
{
    [SerializeField] Image rightIndicator;
    [SerializeField] Image leftIndicator;
    [SerializeField] Image forwardIndicator;
    [SerializeField] Image backwardIndicator;
    Vector3 targetDirection;

    void Start()
    {
        DisableIndicators();
    }

    void DisableIndicators()
    {
        leftIndicator.enabled = rightIndicator.enabled = false;
        forwardIndicator.enabled = backwardIndicator.enabled = false;
    }

    void Update()
    {
        if (!FindObjectOfType<FishNet>())
        {
            DisableIndicators();
            return;
        }

        CalculateDirection();
    }

    void CalculateDirection()
    {
        targetDirection = FindObjectOfType<FishNet>().transform.position - transform.position;

        float sideAngle = Vector3.Dot(-transform.right, targetDirection); 
        float forwardAngle = Vector3.Dot(transform.forward, targetDirection); 

        if (sideAngle < 0)
        {
            rightIndicator.enabled = false;
            leftIndicator.enabled = true;
        }
        else if (sideAngle > 0)
        {
            leftIndicator.enabled = false;
            rightIndicator.enabled = true;
        }

        if (forwardAngle > 0)
        {
            forwardIndicator.enabled = true;
            backwardIndicator.enabled = false;
        }
        else if (forwardAngle < 0)
        {
            backwardIndicator.enabled = true;
            forwardIndicator.enabled = false;
        }
    }
}
