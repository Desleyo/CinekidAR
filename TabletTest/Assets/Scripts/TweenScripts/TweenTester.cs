using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTester : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed;

    public EaseTypes easeType;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))

            switch (easeType)
            {
                case EaseTypes.Linear:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.Linear);
                    break;

                case EaseTypes.EaseInQuad:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuad);
                    break;

                case EaseTypes.EaseInCubic:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInCubic);
                    break;

                case EaseTypes.EaseInQuart:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuart);
                    break;

                case EaseTypes.EaseInQuint:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuint);
                    break;

                case EaseTypes.EaseInBack:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuint);
                    break;

                case EaseTypes.EaseInCirc:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuint);
                    break;

                case EaseTypes.EaseInSine:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuint);
                    break;

                case EaseTypes.EaseOutQuad:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuad);
                    break;

                case EaseTypes.EaseOutCubic:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInCubic);
                    break;

                case EaseTypes.EaseOutQuart:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuart);
                    break;

                case EaseTypes.EaseOutQuint:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuint);
                    break;

                case EaseTypes.EaseOutBack:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuint);
                    break;

                case EaseTypes.EaseOutCirc:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuint);
                    break;

                case EaseTypes.EaseOutSine:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuint);
                    break;
            }
    }
}