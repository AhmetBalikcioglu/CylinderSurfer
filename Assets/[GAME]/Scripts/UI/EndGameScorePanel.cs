using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameScorePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _multiplyText;
    [SerializeField] private TextMeshProUGUI _totalDiamondText;
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnLevelSuccess.AddListener(EndPanelUpdate);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnLevelSuccess.RemoveListener(EndPanelUpdate);
    }

    private void EndPanelUpdate()
    {
        _multiplyText.SetText(ScoreManager.Instance.scoreMultiplier.ToString() + "X");
        _totalDiamondText.SetText(ScoreManager.Instance.score.ToString());
        GetComponentInParent<Animator>().SetTrigger("LevelSuccess");
    }
}
