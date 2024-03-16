using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_LevelComplete : MonoBehaviour
{
    //Stores the game event script in this variable
    public scp_GameEvent gameEvent;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //Fires the raise method from the game event script
            gameEvent.Raise();
        }
    }
}
