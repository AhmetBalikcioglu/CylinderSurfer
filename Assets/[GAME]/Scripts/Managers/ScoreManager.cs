using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public float score;
    public float scoreMultiplier;
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnScoreMultiply.AddListener(ScoreMultiply);
        EventManager.OnScoreUpdate.AddListener(ScoreUpdate);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnScoreMultiply.RemoveListener(ScoreMultiply);
        EventManager.OnScoreUpdate.RemoveListener(ScoreUpdate);
    }

    private void ScoreMultiply(float multiplier)
    {
        scoreMultiplier = multiplier;
        score *= multiplier;
        EventManager.OnLevelSuccess.Invoke();
    }

    public void ScoreUpdate(float amount)
    {
        score += amount;
        EventManager.OnScoreUIUpdate.Invoke();
    }

}