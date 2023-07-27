using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour, IStateController
{
      private IState currentState = new IdleState();
      void ChangeState(IState state)
      {
            currentState = state;
      }
      public void Walk() => currentState.Walk(this);
      public void Idle() => currentState.Idle(this);
      private void Start()
      {
            Walk();
      }
}
