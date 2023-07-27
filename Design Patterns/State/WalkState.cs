using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IState
{
      public void Idle(IStateController controller)
      {
            controller.ChangeState(new IdleState());
      }

      public void Walk(IStateController controller)
      {

      }
}
