using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PassiveSkill : Skill
{
      public Stats buff = new Stats();
      public override void Apply()
      {
            Stats stats = Player.instance.stats;
            stats += buff;
      }
      public override void Remove()
      {
            Stats stats = Player.instance.stats;
            stats -= buff;
      }
}
