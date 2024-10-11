using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDifferentColor : MinigameContent
{
    [SerializeField] private Color _normalColor;
    [SerializeField] private Color _targetColor;

    private SpriteRenderer[] _colorObjectArr;

    public override void Setup()
    {
        _colorObjectArr = GetComponentsInChildren<SpriteRenderer>();
    }

    public override void StartMinigame()
    {
        foreach (var renderer in _colorObjectArr)
        {
            renderer.color = _normalColor;
        }

        var rand = _colorObjectArr[Random.Range(0, _colorObjectArr.Length)];
        rand.color = _targetColor;
        // ¿©±â¿¡ AddComponent
    }

    public override void Update()
    {

    }
}
