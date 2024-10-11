using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinigameContent : MonoBehaviour
{
    // �ʱ�ȭ �۾� �� ������ ����
    public virtual void Setup()
    {

    }

    // ���� ����
    public abstract void StartMinigame();

    // ������Ʈ
    public abstract void Update();
}
