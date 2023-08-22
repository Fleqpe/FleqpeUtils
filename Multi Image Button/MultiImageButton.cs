using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MultiImageButton : Button
{
    [SerializeField] List<Graphic> targetGraphics = new List<Graphic>();

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        if (targetGraphics.Count == 0 || targetGraphics.Exists(x => x == null))
            return;
        var targetColor =
            state == SelectionState.Disabled ? colors.disabledColor :
            state == SelectionState.Highlighted ? colors.highlightedColor :
            state == SelectionState.Normal ? colors.normalColor :
            state == SelectionState.Pressed ? colors.pressedColor :
            state == SelectionState.Selected ? colors.selectedColor : Color.white;

        foreach (var graphic in targetGraphics)
            graphic.CrossFadeColor(targetColor, instant ? 0 : colors.fadeDuration, true, true);
    }
}

