using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Controller
{
    public class UIController : Shared.Controller<UIController>
    {
        public MainMenuSection mainMenuSection;
        public SettingsSection settingsSection;
        public EndGameSection endGameSection;

        [HideInInspector] public CanvasGroup lastSection;
        [HideInInspector] public List<CanvasGroup> currentSections;

        protected override void Awake()
        {
            currentSections = new List<CanvasGroup>();

            if (Instance != null)
            {
                Instance.lastSection = lastSection;
                Instance.currentSections = currentSections;
                if (SceneManager.GetActiveScene().name == SceneType.MainMenu.ToString())
                {
                    Instance.mainMenuSection = mainMenuSection;
                    Instance.settingsSection = settingsSection;
                }
                else if (SceneManager.GetActiveScene().name == SceneType.Gameplay.ToString())
                {
                    Instance.endGameSection = endGameSection;
                }
            }
            base.Awake();
        }
        
        public void ShowMainMenuSection()
        {
            mainMenuSection.ShowSection();
        }

        public void ShowSettingsSection ()
        {
            settingsSection.ShowSection();
        }

        public void ShowEndGameSection ()
        {
            endGameSection.ShowSection();
        }
    }
}