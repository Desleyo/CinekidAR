using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    [SerializeField] Text debugText;

    [Space, SerializeField] float followSpeed = .01f;
    [SerializeField] float swipeRange = 50f;
    float startPosY, currentPosY;
    bool swipingDown;

    Interactable currentInteractable;

    private void Update()
    {
        if (Input.touchCount == 0)
            return;

        CheckTouchBegan();
        CheckTouchMoved();
        CheckTouchEnded();
    }

    void CheckTouchBegan()
    {
        if (Input.GetTouch(0).phase != TouchPhase.Began)
            return;

        startPosY = Input.GetTouch(0).position.y;

        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                currentInteractable = hit.collider.GetComponentInParent<Interactable>();
            }
        }
    }

    void CheckTouchMoved()
    {
        if (Input.GetTouch(0).phase != TouchPhase.Moved)
            return;

        Touch touch = Input.GetTouch(0);
        Vector3 currentPos = currentInteractable.transform.position;

        currentInteractable.transform.position = new Vector3(currentPos.x, currentPos.y + touch.deltaPosition.y * followSpeed, currentPos.z);
    }

    void CheckTouchEnded()
    {
        if (Input.GetTouch(0).phase != TouchPhase.Ended)
            return;

        if (CheckIfSwipingDown())
        {
            currentInteractable.HookTriggered(false);
        }

        currentInteractable = null;
    }

    bool CheckIfSwipingDown()
    {
        currentPosY = Input.GetTouch(0).position.y;

        return (currentPosY - startPosY) < -swipeRange;
    }
}
