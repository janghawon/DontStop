using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinigameContent : MonoBehaviour
{
    // 초기화 작업 및 간단한 셋팅
    public virtual void Setup()
    {

    }

    // 게임 시작
    public abstract void StartMinigame();

    // 업데이트
    public abstract void Update();
}
