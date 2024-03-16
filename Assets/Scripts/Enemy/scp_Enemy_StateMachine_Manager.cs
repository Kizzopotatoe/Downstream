using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scp_Enemy_StateMachine_Manager : MonoBehaviour
{
    [SerializeField]scp_Enemy_StateMachine_BaseState currentState;     //This variable will keep track of what state is currently active


    //These variables will store references to the script that manage each state 
    public scp_Enemy_StateMachine_IdleState idleState = new scp_Enemy_StateMachine_IdleState();
    public scp_Enemy_StateMachine_ChaseState chaseState = new scp_Enemy_StateMachine_ChaseState();
    public scp_Enemy_StateMachine_RageState rageState = new scp_Enemy_StateMachine_RageState();

    //Variables holding the player's position and the enemy's navmesh
    public Transform playerObj;
    protected NavMeshAgent enemyMesh;

    // Start is called before the first frame update
    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
        playerObj = GameObject.FindWithTag ("Player").transform;

        currentState = idleState;                                   //Sets the current state to be idle, thus making it idle by default as soon as we press play
        currentState.EnterState(this);                              //This line makes sure that the EnterState() method will actually work in each state
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.UpdateState(this);            //The ? means "if it is not null (not empty)". This line will make sure that the Update() works in each state
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);           //In order to enable OnTriggerEnter in each state
    }

    private void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(this, other);           //In order to enable OnTriggerExit in each state
    }


    //This method will be used to switch states
    public void SwitchState(scp_Enemy_StateMachine_BaseState stateWeWantToUse)
    {
        currentState = stateWeWantToUse;
        currentState.EnterState(this);
    }


    //This method will be used to set the enemy's destination to itself
    public void Idle()
    {
        enemyMesh.SetDestination(this.transform.position); 
    }

    //This method will be used to set the enemy's destination to the player
    public void Chase()
    {
        enemyMesh.SetDestination(playerObj.position); 
    }

    //Puts the enemy into the rage state
    public void Enrage()
    {
        SwitchState(rageState);   
    }

    //Ends the rage state after 3 seconds and returns the enemy to normal behaviour
    public IEnumerator EnrageEnd()
    {
        yield return new WaitForSeconds(3);

        SwitchState(chaseState);
    }
}
