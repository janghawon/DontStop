using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameDebugHelper : MonoBehaviour
{
    private void Start()
    {
        MinigameContent content = FindObjectOfType<MinigameContent>();
        content.Setup();
        content.StartMinigame();
    }
}
