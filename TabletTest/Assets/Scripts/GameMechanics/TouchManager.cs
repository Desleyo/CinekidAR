using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    [Space, SerializeField] float followSpeed = .002f;
    [SerializeField] float swipeRange = 200f;

    float startPosY, currentPosY;

    FishHook currentFishHook;

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
            if (hit.collider.CompareTag("FishHook"))
            {
                currentFishHook = hit.collider.GetComponent<FishHook>();
            }
        }
    }

    void CheckTouchMoved()
    {
        if (Input.GetTouch(0).phase != TouchPhase.Moved)
            return;

        Touch touch = Input.GetTouch(0);
        Vector3 currentPos = currentFishHook.transform.position;

        currentFishHook.transform.position = new Vector3(currentPos.x, currentPos.y + touch.deltaPosition.y * followSpeed, currentPos.z);
    }

    void CheckTouchEnded()
    {
        if (Input.GetTouch(0).phase != TouchPhase.Ended)
            return;

        if (CheckIfSwipingDown())
        {
            currentFishHook.HookTriggered(false);
        }

        currentFishHook = null;
    }

    bool CheckIfSwipingDown()
    {
        currentPosY = Input.GetTouch(0).position.y;

        float distancePosY = currentPosY - startPosY;
        return distancePosY < -swipeRange || distancePosY > swipeRange;
    }
}
