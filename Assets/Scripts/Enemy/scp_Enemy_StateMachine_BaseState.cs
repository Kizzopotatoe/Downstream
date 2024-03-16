using UnityEngine;

public abstract class scp_Enemy_StateMachine_BaseState
{
    public abstract void EnterState(scp_Enemy_StateMachine_Manager stateMachineManager);

    public abstract void UpdateState(scp_Enemy_StateMachine_Manager stateMachineManager);

    public abstract void OnTriggerEnter(scp_Enemy_StateMachine_Manager stateMachineManager, Collider collider);

    public abstract void OnTriggerExit(scp_Enemy_StateMachine_Manager stateMachineManager, Collider collider);
}
