using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClickMovingCircle : MinigameContent
{
    [SerializeField] private float _setDestinationTime;
    private float _currentTime;

    private Vector2 screenSize;

    private List<MovingCircle> _circleList = new List<MovingCircle>();


    public override void StartMinigame()
    {
        _circleList = GetComponentsInChildren<MovingCircle>().ToList<MovingCircle>();
        foreach(MovingCircle circle in _circleList)
        {
            circle.onDestroy += DiscardCircle;
        }

        screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        _currentTime = 0;
    }

    public override void Update()
    {
        // next game
        if(_circleList.Count == 0)
        {
            MinigameManager.Instance.CreateNextMinigame();
        }

        if (_currentTime <= 0)
        {
            _currentTime = _setDestinationTime;

            foreach (MovingCircle circle in _circleList)
            {
                Vector2 randomPos = new Vector2(Random.Range(-screenSize.x, screenSize.x),
                    Random.Range(-screenSize.y, screenSize.y));
                circle.SetDestination(randomPos, _setDestinationTime);
            }
        }
        else
        {
            _currentTime -= Time.deltaTime;
        }
    }

    private void DiscardCircle(MovingCircle circle)
    {
        _circleList.Remove(circle);
    }
}
