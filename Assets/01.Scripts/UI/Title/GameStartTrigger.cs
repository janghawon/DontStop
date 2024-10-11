using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartTrigger : MonoBehaviour
{
    private bool _isAlreadyGameStart = false;

    private Animator _animator;
    private readonly int _startHash = Animator.StringToHash("isStart");

    private TextMeshProUGUI _titleText;
    private GameObject _triggerText;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _titleText = transform.Find("Title").GetComponent<TextMeshProUGUI>();
        _triggerText = transform.Find("TriggerText").gameObject;
    }

    private void Update()
    {
        if(Input.anyKeyDown && !_isAlreadyGameStart)
        {
            _isAlreadyGameStart = true;
            _triggerText.SetActive(false);
            _animator.SetBool(_startHash, true);
        }
    }

    public void Countdown()
    {
        StartCoroutine(CountdownCO());
    }

    public void Finish()
    {
        _animator.enabled = false;
    }

    private IEnumerator CountdownCO()
    {
        for(int i = 3; i > 0; i--)
        {
            _titleText.text = i.ToString();
            _titleText.transform.localScale = Vector3.one * 2f;

            _titleText.transform.DOScale(Vector3.one, 0.8f).SetEase(Ease.OutBack);
            
            yield return new WaitForSeconds(1);
        }

        SceneLoader.ChangeScene("InGame");
    }
}
