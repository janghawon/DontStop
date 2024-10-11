using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoSingleton<MinigameManager>
{
    [SerializeField] private MinigameContent[] _minigameContentArr;
    private Queue<MinigameContent> _minigameContentContainer = new ();
    private MinigameContent _currentMinigame;

    private void Awake()
    {
        foreach(var game in _minigameContentArr)
        {
            _minigameContentContainer.Enqueue(game);
        }
    }

    public void CreateNextMinigame()
    {
        Destroy(_currentMinigame.gameObject);

        _currentMinigame = Instantiate(_minigameContentContainer.Dequeue(), transform);

        _currentMinigame.Setup();
        _currentMinigame.StartMinigame();
    }
}
