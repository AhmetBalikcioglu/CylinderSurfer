using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSuccessPanel : Panel
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnGameStart.AddListener(HidePanel);
        EventManager.OnLevelSuccess.AddListener(ShowPanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnGameStart.RemoveListener(HidePanel);
        EventManager.OnLevelSuccess.RemoveListener(ShowPanel);
    }
}
