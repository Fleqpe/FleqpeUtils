using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{

      public void Idle(IStateController controller)
      {

      }

      public void Walk(IStateController controller)
      {
            controller.ChangeState(new WalkState());
            Debug.Log("Changing to Walk");
      }
}
