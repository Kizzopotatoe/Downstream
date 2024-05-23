using UnityEngine;

public class scp_Enemy_StateMachine_IdleState : scp_Enemy_StateMachine_BaseState
{
    public override void EnterState(scp_Enemy_StateMachine_Manager stateMachineManager)
    {
        Debug.Log("Entered the idle state");
    }

    public override void UpdateState(scp_Enemy_StateMachine_Manager stateMachineManager)
    {
        stateMachineManager.Idle();
    }

    public override void OnTriggerEnter(scp_Enemy_StateMachine_Manager stateMachineManager, Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            stateMachineManager.SwitchState(stateMachineManager.chaseState);
        }
    }

    public override void OnTriggerExit(scp_Enemy_StateMachine_Manager stateMachineManager, Collider other)
    {
        
    }
}
