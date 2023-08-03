using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
      public float currentHP;
      public float maxHP;
      public Image healthBarImage;
      void Update()
      {
            healthBarImage.fillAmount = Mathf.Lerp(healthBarImage.fillAmount, currentHP / maxHP, Time.deltaTime);
      }
      public void DealDamage()
      {
            currentHP -= 25;
      }
      public void Heal()
      {
            currentHP += 25;
      }
}
