using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Controller;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSection : Section
{
    void Start()
    {
        UIController.Instance.ShowMainMenuSection();
    }

    public void OnClickPlayButton ()
    {
        UIController.Instance.settingsSection.SetGameVariables();
        SceneManager.LoadScene(1);
    }

    public void OnClickSettingsButton ()
    {
        UIController.Instance.ShowSettingsSection();
    }
}
