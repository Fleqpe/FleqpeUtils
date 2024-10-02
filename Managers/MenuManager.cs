using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuManager : SingletonManager<MenuManager>
{
    private List<CanvasGroup> canvasGroups = new List<CanvasGroup>();
    [SerializeField] private List<CanvasGroup> blackListCanvasGroup = new List<CanvasGroup>();
    public static Action<CanvasGroup> onClose, onOpen;
    void Awake()
    {
        canvasGroups = FindObjectsOfType<CanvasGroup>().ToList();
        blackListCanvasGroup.ForEach(x => canvasGroups.Remove(x));
        canvasGroups.ForEach(otherCanvasGroup => otherCanvasGroup.Close());
    }
    public void SwitchCanvasGroup(CanvasGroup targetCanvasGroup)
    {
        canvasGroups.ForEach(otherCanvasGroup => otherCanvasGroup.Close());
        targetCanvasGroup.Open();
    }
    public void Switch(CanvasGroup targetCanvasGroup)
    {
        if (targetCanvasGroup.alpha == 1)
            onClose?.Invoke(targetCanvasGroup);
        else
            onOpen?.Invoke(targetCanvasGroup);
        targetCanvasGroup.Switch();
    }
    public void Close(CanvasGroup targetCanvasGroup)
    {
        targetCanvasGroup.Close();
        onClose?.Invoke(targetCanvasGroup);
    }
    public void Open(CanvasGroup targetCanvasGroup)
    {
        targetCanvasGroup.Open();
        onOpen?.Invoke(targetCanvasGroup);
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