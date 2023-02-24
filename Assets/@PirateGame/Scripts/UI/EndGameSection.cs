using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Controller;
using Assets.Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameSection : Section
{
    [SerializeField] private TextMeshProUGUI pointsValue;

    void Start()
    {
        HideSection();
    }

    public void SetPoints()
    {
        pointsValue.text = GameController.Instance.GetPoints().ToString();
    }

    public void OnClickPlayAgainButton()
    {
        RestartController.Instance.ResetLevel();
        HideSection();
    }

    public void OnClickMainMenuButton ()
    {
        SceneManager.LoadScene(SceneType.MainMenu.ToString());
    }
}
