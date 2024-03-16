using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Enemy_StateMachine_ChaseState : scp_Enemy_StateMachine_BaseState
{
    public override void EnterState(scp_Enemy_StateMachine_Manager stateMachineManager)
    {
        Debug.Log("Entered the chase state");
    }

    public override void UpdateState(scp_Enemy_StateMachine_Manager stateMachineManager)
    {
        stateMachineManager.Chase();
    }

    public override void OnTriggerEnter(scp_Enemy_StateMachine_Manager stateMachineManager, Collider other)
    {

    }

    public override void OnTriggerExit(scp_Enemy_StateMachine_Manager stateMachineManager, Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            stateMachineManager.SwitchState(stateMachineManager.idleState);
        }
    }
}
