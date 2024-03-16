using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Environment_Current : MonoBehaviour
{
    //The strength of the current
    public float strength;
    //The direction of the current
    public Vector3 direction;
    //Stores the player's rigidbody
    public Rigidbody playerRb;
    //Bool checking wether the player is in the current or not
    public bool inCurrent = false;

    void FixedUpdate()
    {
        //If the player is in the current, force will be added
        if(inCurrent)
        {
            playerRb.AddForce(direction * strength);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        //If the player is colliding with this object, inCurrent is true
        if(other.gameObject.CompareTag("Player"))
        {
            inCurrent = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //If the player stops colliding with this object, inCurrent is false
        if(other.gameObject.CompareTag("Player"))
        {
            inCurrent = false;
        }
    }

}
