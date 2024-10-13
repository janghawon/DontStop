using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToClickCircle : MonoBehaviour
{
    private SpriteRenderer _visualRenderer;
    private event Action _onClickEvent;

    public void Setup(Action evt)
    {
        _visualRenderer = GetComponent<SpriteRenderer>();
        _onClickEvent += evt;
    }

    public void OnMouseDown()
    {
        _onClickEvent?.Invoke();
        _visualRenderer.DOFade(0, 0.1f).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
