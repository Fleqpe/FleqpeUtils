using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
[RequireComponent(typeof(CanvasGroup))]
public class SwitchableCanvasGroup : MonoBehaviour
{
    private CanvasGroup targetCanvasGroup;
    private void Awake()
    {
        targetCanvasGroup = GetComponent<CanvasGroup>();
    }
    public void Switch()
    {
        targetCanvasGroup.Switch();
    }
    public void Close()
    {
        targetCanvasGroup.Close();
    }
    public void Open()
    {
        targetCanvasGroup.Open();
    }
}

public static class CanvasGroupExtension
{
    public static void Open(this CanvasGroup c)
    {
        if (c == null)
        {
            Debug.LogError("Please set the canvas group!");
            return;
        }
        c.alpha = 1;
        c.interactable = true;
        c.blocksRaycasts = true;
    }
    public static void Switch(this CanvasGroup c)
    {
        if (c == null)
        {
            Debug.LogError("Please set the canvas group!");
            return;
        }
        if (c.alpha == 0)
            Open(c);
        else
            Close(c);
    }
    public static void Close(this CanvasGroup c)
    {
        if (c == null)
        {
            Debug.LogError("Please set the canvas group!");
            return;
        }
        c.alpha = 0;
        c.interactable = false;
        c.blocksRaycasts = false;
    }

    public static bool IsOpened(this CanvasGroup c)
    {
        if (c == null)
        {
            Debug.LogError("Please set the canvas group!");
            return false;
        }
        return c.alpha == 1;
    }
}