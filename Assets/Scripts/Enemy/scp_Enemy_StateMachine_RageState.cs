using UnityEngine;

public class scp_Enemy_StateMachine_RageState : scp_Enemy_StateMachine_BaseState
{
    public override void EnterState(scp_Enemy_StateMachine_Manager stateMachineManager)
    {
        Debug.Log("Entered the rage state");

        stateMachineManager.StartCoroutine(stateMachineManager.EnrageEnd());
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
        
    }
}
