using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCountUI : MonoBehaviour
{
    private TextMeshProUGUI _scoreCountTMP;
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        _scoreCountTMP = GetComponentInChildren<TextMeshProUGUI>();
        EventManager.OnScoreUIUpdate.AddListener(ScoreUIUpdate);

    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnScoreUIUpdate.RemoveListener(ScoreUIUpdate);
    }
    private void ScoreUIUpdate()
    {
        _scoreCountTMP.SetText(ScoreManager.Instance.score.ToString());
    }
}
