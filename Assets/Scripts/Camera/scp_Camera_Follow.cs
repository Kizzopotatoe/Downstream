using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Camera_Follow : MonoBehaviour
{
    //Reference to the main camera
    public Transform mainCamera;
    //Stores the next position we would like the camera to go to
    public Transform nextPosition;
    //Reference to a child object with a collider preventing the player from going backwards
    public GameObject progressLock;
    //Stores the enemies in the next area
    public GameObject[] enemiesToSpawn;

    void Start()
    {
        //Sets the progress lock to inactive upon start
        progressLock.SetActive(false);

        //Goes through each enemy in the array and sets them to inactive
        for(int i = 0; i < enemiesToSpawn.Length; i++) 
        {
            enemiesToSpawn[i].SetActive(false);
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //If the player collides with this object, the main camera will move to the next position
        if(other.gameObject.CompareTag("Player"))
        {
            mainCamera.position = nextPosition.position;
            progressLock.SetActive(true);
            
            //Goes through each enemy in the array and sets them to active
            for(int i = 0; i < enemiesToSpawn.Length; i++) 
            {
                enemiesToSpawn[i].SetActive(true);
            }
        }
    }
} 

