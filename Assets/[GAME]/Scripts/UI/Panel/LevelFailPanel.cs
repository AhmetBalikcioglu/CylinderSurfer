using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailPanel : Panel
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnGameStart.AddListener(HidePanel);
        EventManager.OnLevelFail.AddListener(ShowPanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnGameStart.RemoveListener(HidePanel);
        EventManager.OnLevelFail.RemoveListener(ShowPanel);
    }
}
