using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMachine : MonoBehaviour
{
    private List<Tween> _activeTweens = new List<Tween>();

    private void Update()
    {
        if (_activeTweens.Count < 1) return;

        for (int i = 0; i < _activeTweens.Count; i++)
        {
            _activeTweens[i].UpdateTween(Time.deltaTime);
        }
    }

    public void MoveGameObject(GameObject objectToMove, Vector3 targetPosition, float speed, Func<float, float> EaseMethod)
    {
        PositionTween newTween = new PositionTween(objectToMove, targetPosition, speed, EaseMethod);
        _activeTweens.Add(newTween);
    }
}
