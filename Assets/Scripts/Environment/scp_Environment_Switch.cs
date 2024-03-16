using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Environment_Switch : MonoBehaviour
{
    //Gate to open
    public GameObject gate;
    //Lever objects
    public GameObject[] levers;

    //Audio source and clip
    public AudioSource source;
    public AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        //If the player's projectile hits this object, the specified gate will be destroyed
        //and the lever position will switch
        if(other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gate);
            levers[0].SetActive(false);
            levers[1].SetActive(true);
            source.PlayOneShot(clip);
        }
    }
}
