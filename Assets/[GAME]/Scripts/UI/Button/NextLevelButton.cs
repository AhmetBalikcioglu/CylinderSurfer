using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelButton : Button
{
    protected override void OnEnable()
    {
        base.OnEnable();
        onClick.AddListener(NextLevel);
    }

    protected override void OnDisable()
    {
        base.OnEnable();
        onClick.RemoveListener(NextLevel);
    }

    public void NextLevel()
    {
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneBuildIndex);
    }
}
