using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTester : MonoBehaviour
{
    public TweenMachine tweenMachine;

    Vector3 startPos, loweredPos;
    public float speed;

    public EaseTypes easeType;

    private void Awake()
    {
        tweenMachine = FindObjectOfType<TweenMachine>();

        startPos = loweredPos = transform.position;
        loweredPos.y = 0f;
    }

    public void StartEasing(bool shouldHookLower)
    {
        Vector3 targetPos = shouldHookLower ? loweredPos : startPos;

        switch (easeType)
        {
            case EaseTypes.Linear:
                tweenMachine.MoveGameObject(gameObject, targetPos, speed, Easings.Linear);
                break;

            case EaseTypes.EaseInQuad:
                tweenMachine.MoveGameObject(gameObject, targetPos, speed, Easings.EaseInQuad);
                break;

            case EaseTypes.EaseInCubic:
                tweenMachine.MoveGameObject(gameObject, targetPos, speed, Easings.EaseInCubic);
                break;

            case EaseTypes.EaseInQuart:
                tweenMachine.MoveGameObject(gameObject, targetPos, speed, Easings.EaseInQuart);
                break;

            case EaseTypes.EaseInQuint:
                tweenMachine.MoveGameObject(gameObject, targetPos, speed, Easings.EaseInQuint);
                break;

            case EaseTypes.EaseInBack:
                tweenMachine.MoveGameObject(gameObject, targetPos, speed, Easings.EaseInBack);
                break;

            case EaseTypes.EaseInCirc:
                tweenMachine.MoveGameObject(gameObject, targetPos, speed, Easings.EaseInCirc);
                break;

            case EaseTypes.EaseInSine:
                tweenMachine.MoveGameObject(gameObject, targetPos, speed, Easings.EaseInSine);
                break;

            case EaseTypes.EaseOutQuad:
                tweenMachine.MoveGameObject(gameObject, targetPos, speed, Easings.EaseOutQuad);
                break;

            case EaseTypes.EaseOutCubic:
                tweenMachine.MoveGameObject(gameObject, targetPos, speed, Easings.EaseOutCubic);
                break;

            case EaseTypes.EaseOutQuart:
                tweenMachine.MoveGameObject(gameObject, targetPos, speed, Easings.EaseOutQuart);
                break;

            case EaseTypes.EaseOutQuint:
                tweenMachine.MoveGameObject(gameObject, targetPos, speed, Easings.EaseOutQuint);
                break;

            case EaseTypes.EaseOutBack:
                tweenMachine.MoveGameObject(gameObject, targetPos, speed, Easings.EaseOutBack);
                break;

            case EaseTypes.EaseOutCirc:
                tweenMachine.MoveGameObject(gameObject, targetPos, speed, Easings.EaseOutCirc);
                break;

            case EaseTypes.EaseOutSine:
                tweenMachine.MoveGameObject(gameObject, targetPos, speed, Easings.EaseOutSine);
                break;
        }
    }
}