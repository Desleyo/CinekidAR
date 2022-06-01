using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    [SerializeField] Text debugText;

    private void Update()
    {
        CheckTouchInput();
    }

    void CheckTouchInput()
    {
        if (Input.touchCount == 0 || Input.GetTouch(0).phase != TouchPhase.Began)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.CompareTag("Interactable"))
            {
                hit.collider.GetComponent<Interactable>().HookTriggered();
            }
        }
    }
}
