using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Controller;
using UnityEngine;

public class Section : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    protected virtual void Awake ()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ShowSection (CanvasGroup canvasGroup)
    {
        if (UIController.Instance.currentSections.Count > 0)
        {
            HideSection(UIController.Instance.lastSection);
        }

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        UIController.Instance.lastSection = canvasGroup;
        UIController.Instance.currentSections.Add(canvasGroup);
    }

    public void ShowSection ()
    {
        if (UIController.Instance.currentSections.Count > 0)
        {
            HideSection(UIController.Instance.lastSection);
        }

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        UIController.Instance.lastSection = canvasGroup;
        UIController.Instance.currentSections.Add(canvasGroup);
    }

    public void HideSection (CanvasGroup canvasGroup, bool hideAll = false)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        if (!hideAll)
        {
            if (UIController.Instance.currentSections.Contains(canvasGroup))
            {
                UIController.Instance.currentSections.Remove(canvasGroup);
            }
        }
    }

    public void HideSection (bool hideAll = false)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        if (!hideAll)
        {
            if (UIController.Instance.currentSections.Contains(canvasGroup))
            {
                UIController.Instance.currentSections.Remove(canvasGroup);
            }
        }
    }

    public void HideAllSections ()
    {
        foreach (CanvasGroup section in UIController.Instance.currentSections)
        {
            HideSection(section, true);
        }
        UIController.Instance.currentSections.Clear();
    }
}
