using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    [SerializeField] float followSpeed = .002f;
    [SerializeField] float swipeRange = 200f;

    [Space, SerializeField] float shakeSpeed = 5f;
    [SerializeField] float shakeAmount = .1f;

    FishHook currentFishHook;
    float startSwipePosY, currentSwipePosY;
    float hookStartPosX;

    private void Update()
    {
        if (Input.touchCount == 0)
            return;

        CheckTouchBegan();
        MoveHook();
        CheckTouchEnded();
    }

    void CheckTouchBegan()
    {
        if (Input.GetTouch(0).phase != TouchPhase.Began)
            return;

        startSwipePosY = Input.GetTouch(0).position.y;

        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("FishHook"))
            {
                currentFishHook = hit.collider.GetComponent<FishHook>();
                hookStartPosX = currentFishHook.transform.position.x;
            }
        }
    }

    void MoveHook()
    {
        Touch touch = Input.GetTouch(0);
        Vector3 currentPos = currentFishHook.transform.position;
        float shakeHookPosX = hookStartPosX + Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;

        currentFishHook.transform.position = new Vector3(shakeHookPosX, currentPos.y + touch.deltaPosition.y * followSpeed, currentPos.z);
    }

    void CheckTouchEnded()
    {
        if (Input.GetTouch(0).phase != TouchPhase.Ended)
            return;

        if (CheckIfSwipeThresholdReached())
        {
            currentFishHook.HookTriggered(false);
        }

        currentFishHook = null;
    }

    bool CheckIfSwipeThresholdReached()
    {
        currentSwipePosY = Input.GetTouch(0).position.y;
        float distancePosY = currentSwipePosY - startSwipePosY;

        return distancePosY < -swipeRange || distancePosY > swipeRange;
    }
}
