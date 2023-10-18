using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System;
using UnityEngine.UI;
using System.ComponentModel;
[RequireComponent(typeof(TextMeshProUGUI))]
public class TMP_AnimatedNumberText : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private TMP_Text text;
    private void OnValidate()
    {
        text = GetComponent<TMP_Text>();
    }
    private float currentValue;
    public void StartLoop(float targetValue, int comma, Action displayEvent = null)
    {
        DOVirtual.Float(currentValue, targetValue, speed, (x) =>
        {
            targetValue = x;
            text.text = x.ToString("F" + comma);
            if (displayEvent == null)
                return;
        })
        .SetSpeedBased(true)
        .SetEase(Ease.InSine)
        .OnComplete(() => StartLoop(targetValue, comma, displayEvent));
    }
}
