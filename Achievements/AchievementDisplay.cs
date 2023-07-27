using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.EventSystems;
namespace FleqpeUtils.Achievement
{
      public abstract class AchievementDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
      {
            public GameObject achievementBox;
            public TMP_Text achievementInfoText;
            public TMP_Text achievementNameText;
            public UnityEvent milestoneCheckTrigger;
            public string id;
            public abstract void DisplayAchievementInfoText();
            public abstract void DisplayAchievementNameText();
            public abstract void OnPointerEnter(PointerEventData eventData);
            public abstract void OnPointerExit(PointerEventData eventData);
      }
}