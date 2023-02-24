using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Assets.Scripts.Controller;
using TMPro;
using UnityEngine;
using static System.Int32;

public class SettingsSection : Section
{
    public TMP_InputField matchDurationField;
    public TMP_InputField enemySpawnRateField;

    void Start()
    {
        matchDurationField.text = $"1:00";
        enemySpawnRateField.text = $"0:05";
    }

    public void OnMatchDurationEndEdit(string text)
    {
        bool isTextValid = ValidateTexts(text);

        if (!isTextValid)
        {
            text = $"1:00";
            matchDurationField.text = text;
        }
    }

    public void OnEnemySpawnRateEndEdit (string text)
    {
        bool isTextValid = ValidateTexts(text);

        if (!isTextValid)
        {
            text = $"0:05";
            enemySpawnRateField.text = text;
        }
    }

    public void SetGameVariables()
    {
        string[] timeformats = { @"m\:ss", @"mm\:ss", @"h\:mm\:ss" };
        TimeSpan matchDuration = TimeSpan.ParseExact(matchDurationField.text, timeformats, CultureInfo.InvariantCulture);
        TimeSpan enemySpawnRate = TimeSpan.ParseExact(enemySpawnRateField.text, timeformats, CultureInfo.InvariantCulture);

        GameController.Instance.SetMatchDuration((float)matchDuration.TotalSeconds);
        GameController.Instance.SetEnemySpawnRate((float)enemySpawnRate.TotalSeconds);
    }

    private bool ValidateTexts(string text)
    {
        bool isTextValid = false;

        if (text.Contains(":"))
        {
            string[] texts = text.Split(':');
            if (texts.Length == 2)
            {
                if (TryParse(texts[0], out int minutes) &&
                    TryParse(texts[1], out int seconds))
                {
                    isTextValid = true;
                }
            }
        }

        return isTextValid;
    }
}
