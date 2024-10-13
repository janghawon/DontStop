using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    private event Action _onClick;
    [SerializeField] private TextMeshPro _text;

    public void Setup(Action evt)
    {
        _onClick += evt;
    }

    public void SetText(string sentence)
    {
        _text.text = sentence;
    }

    public void SetPosition(Vector2 pos)
    {
        transform.position = pos;
    }

    private void OnMouseDown()
    {
        _onClick?.Invoke();
    }
}
