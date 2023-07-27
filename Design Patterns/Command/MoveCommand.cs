using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoveCommand : Command
{
      public float speed;
      public Vector3 target;
      public GameObject agent;
      public override bool isFinished => !(DOTween.IsTweening(agent, true));
      public override void Execute()
      {
            agent.transform.DOMove(target, speed)
            .SetSpeedBased(true);
      }
}
