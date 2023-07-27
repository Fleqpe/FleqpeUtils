using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
      public Image healthBarFill;
      public float maxHP = 100;
      public float currentHP = 100;
      public float barSpeed = 0;
      private void Update()
      {
            healthBarFill.fillAmount = Mathf.Lerp(healthBarFill.fillAmount, currentHP / maxHP, Time.deltaTime * barSpeed);
      }
      public void DealDamage(int damage)
      {
            currentHP -= damage;
      }
      public void HealHealth(int healAmount)
      {
            currentHP += healAmount;
      }
}
