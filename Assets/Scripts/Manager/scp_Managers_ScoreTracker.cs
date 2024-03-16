using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Managers_ScoreTracker : MonoBehaviour
{
    //This line is for the Singleton Pattern which will allow us to access this class without any reference
    public static scp_Managers_ScoreTracker instance;

    //Reference to the player collection script
    public scp_Player_Collection collectScript;
    //Int to hold the player's current score
    public int trackedScore;

    void Awake()
    {
        //Gets the collect script 
        collectScript = FindObjectOfType<scp_Player_Collection>();

        //Puts this game object into don't destroy on load so it persists between scenes
        DontDestroyOnLoad(gameObject);

        //Since the singleton requires us to make sure that we have only one
        //instance of the class, we will fill it with this if there are no others
        //and destroy the other if there is one. This resets the score if the
        //player chooses the restart option in the end scene
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
            instance = this;
        }
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        //Checks the player's score in the collect script, and stores it here
        trackedScore = collectScript.score;
    }
}
