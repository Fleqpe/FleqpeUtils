using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public abstract class SkillNodeDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
      public SkillNode node;
      public Button button;
      public GameObject skillInfoMenu;
      public TMP_Text skillName;
      public TMP_Text skillDescription;
      public TMP_Text skillStats;
      private void Update()
      {
            SetButton();
      }
      public void SetButton()
      {
            button.interactable = node.state == SkillNodeState.NotOpened || node.state == SkillNodeState.Active;
      }
      public abstract void OnPointerEnter(PointerEventData eventData);
      public abstract void OnPointerExit(PointerEventData eventData);
      public abstract void DisplaySkill();
}
