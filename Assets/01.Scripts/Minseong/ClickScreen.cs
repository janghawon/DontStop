using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScreen : MinigameContent
{
    [SerializeField] private float _clickTarget;

    public override void StartMinigame()
    {
        
    }

    public override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickTarget--;
        }

        // next game
        if(_clickTarget <= 0)
        {
            MinigameManager.Instance.CreateNextMinigame();
        }
    }
}
