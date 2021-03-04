using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameEnd = new UnityEvent();
    public static UnityEvent OnGameRestart = new UnityEvent();
    public static UnityEvent OnSceneLoad = new UnityEvent();

    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();

    public static UnityEvent OnLevelSuccess = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();

    public static InputEvent OnSwipeDetected = new InputEvent();

    public static UnityEvent OnCylinderCollected = new UnityEvent();
    public static UnityEvent OnCylinderSlammed = new UnityEvent();
    public static UnityEvent OnMultiplierPlatform = new UnityEvent();

    public static ScoreEvent OnScoreMultiply = new ScoreEvent();
    public static ScoreEvent OnScoreUpdate = new ScoreEvent();
    public static UnityEvent OnScoreUIUpdate = new UnityEvent();
}
public class InputEvent : UnityEvent<float> { }
public class ScoreEvent : UnityEvent<float> { }