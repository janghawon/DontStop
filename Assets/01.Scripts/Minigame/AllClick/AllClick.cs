using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AllClick : MinigameContent
{
    [SerializeField] [Range(0, 17.778f)] private float _length;
    [SerializeField] [Range(0, 10)] private float _height;

    private ToClickCircle[] _toClickCircleArr;
    private int _clickCnt = 0;

    public override void Setup()
    {
        _toClickCircleArr = GetComponentsInChildren<ToClickCircle>();
    }

    public override void StartMinigame()
    {
        foreach(var circle in  _toClickCircleArr)
        {
            circle.Setup(HandleClickCircle);

            float generatedLength = _length - (circle.transform.localScale.x);
            float generatedHeight = _height - (circle.transform.localScale.y);

            float randomX = Random.Range(-generatedLength / 2, generatedLength / 2);
            float randomY = Random.Range(-generatedHeight / 2, generatedHeight / 2);

            circle.transform.position = new Vector3(randomX, randomY);
        }
    }

    private void HandleClickCircle()
    {
        _clickCnt++;

        if(_clickCnt >= _toClickCircleArr.Length)
        {
            CallbackManager.Instance.Callback("NextGame");
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector3[] horArr =
        {
            new Vector3(_length * 0.5f, _height * 0.5f),
            new Vector3(-_length * 0.5f, _height * 0.5f),
            new Vector3(-_length * 0.5f, -_height * 0.5f),
            new Vector3(_length * 0.5f, -_height * 0.5f),
        };

        ReadOnlySpan<Vector3> points = new ReadOnlySpan<Vector3>(horArr);
        Gizmos.DrawLineList(points);

        Vector3[] verArr =
        {
            new Vector3(-_length * 0.5f, _height * 0.5f),
            new Vector3(-_length * 0.5f, -_height * 0.5f),
            new Vector3(_length * 0.5f, _height * 0.5f),
            new Vector3(_length * 0.5f, -_height * 0.5f),
        };

        points = new ReadOnlySpan<Vector3>(verArr);
        Gizmos.DrawLineList(points);
    }
#endif
}
