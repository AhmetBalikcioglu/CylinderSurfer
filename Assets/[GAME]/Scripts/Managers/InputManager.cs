using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private Vector2 _firstTouchPosition;
    private Vector2 _currentTouchPosition;
    private bool _isControllable = true;

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnLevelFinish.AddListener(() => _isControllable = false);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnLevelFinish.RemoveListener(() => _isControllable = false);

    }

    private void Update()
    {
        if (!_isControllable)
            return;
        GetMouseInput();
    }

    private void GetMouseInput()
    {
        float tempXPosition = 0;
        // Swipe/Click started
        if (Input.GetMouseButtonDown(0))
        {
            if (!GameManager.Instance.isGameStarted)
                GameManager.Instance.StartGame();
            _firstTouchPosition = (Vector2)Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            _currentTouchPosition = (Vector2)Input.mousePosition;
            tempXPosition = _currentTouchPosition.x - _firstTouchPosition.x;
            _firstTouchPosition = _currentTouchPosition;
            EventManager.OnSwipeDetected.Invoke(tempXPosition);
        }
    }
}