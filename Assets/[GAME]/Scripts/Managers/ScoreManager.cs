using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private float _score;
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
        _score *= multiplier;
    }

    public void ScoreUpdate(float amount)
    {
        _score += amount;
    }

}