using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    [SerializeField] Text debugText;

    float startPosY, currentPosY;

    private void Update()
    {
        if (Input.touchCount == 0)
            return;

        CheckTouchInput();
        CheckIfSwipingDown();
    }

    void CheckTouchInput()
    {
        if (Input.GetTouch(0).phase != TouchPhase.Began)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                hit.collider.GetComponent<Interactable>().HookTriggered();
            }
        }
    }

    void CheckIfSwipingDown()
    {
        if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startPosY = Input.GetTouch(0).position.y;
        }
        else if(Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosY = Input.GetTouch(0).position.y;
        }
    }
}
