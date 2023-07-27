using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
      public void Walk(IStateController controller);
      public void Idle(IStateController controller);
}
