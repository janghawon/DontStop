using DG.Tweening;
using Function;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneUIContent : SceneUIContent
{
    public override void SceneUIStart()
    {
        var startHoverRange = FindUIObject<TitleStartHoverText>("StartHoverRange");
        startHoverRange.OnHoverEvent += HandleHoverTitleText;
    }

    public override void SceneUIEnd()
    {

    }

    private void HandleHoverTitleText(UIObject @obj)
    {
        
    }
}
