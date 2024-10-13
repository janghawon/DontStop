using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloseAllPopup : MinigameContent
{
    [SerializeField][Range(0, 17.778f)] private float _length;
    [SerializeField][Range(0, 10)] private float _height;

    [SerializeField] private Popup _popupPanel;
    [SerializeField] private string[] _textArr;
    private int _clickCnt = 0;

    public override void StartMinigame()
    {
        _popupPanel.Setup(HandleCountingPopup);
        RedrawPopup();
    }

    private void HandleCountingPopup()
    {
        if(_clickCnt >= _textArr.Length)
        {
            CallbackManager.Instance.Callback("NextGame");
            return;
        }

        RedrawPopup();
    }

    private void RedrawPopup()
    {
        _popupPanel.SetText(_textArr[_clickCnt]);

        float generatedLength = _length - (_popupPanel.transform.localScale.x);
        float generatedHeight = _height - (_popupPanel.transform.localScale.y);

        float randomX = Random.Range(-generatedLength / 2, generatedLength / 2);
        float randomY = Random.Range(-generatedHeight / 2, generatedHeight / 2);

        _popupPanel.SetPosition(new Vector3(randomX, randomY));

        _clickCnt++;
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
