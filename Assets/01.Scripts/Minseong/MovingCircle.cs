using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingCircle : MonoBehaviour
{
    public event Action<MovingCircle> onDestroy;

    public void SetDestination(Vector2 pos, float duration)
    {
        transform.DOLocalMove(pos, duration).SetEase(Ease.Linear);
    }

    private void DestroyCircle()
    {
        DOTween.Kill(transform);
        onDestroy.Invoke(this);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        DestroyCircle();
    }
}
