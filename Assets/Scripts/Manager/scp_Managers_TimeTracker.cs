using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scp_Managers_TimeTracker : MonoBehaviour
{
    //This line is for the Singleton Pattern which will allow us to access this class without any reference
    public static scp_Managers_TimeTracker instance;

    //Reference to the timer UI
    public TMP_Text timerText;
    //The current in game time
    public float gameTime = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        //Displays the game time in the timer text
        timerText.text = gameTime.ToString("f0");

        //Puts this game object into don't destroy on load so it persists between scenes
        DontDestroyOnLoad(gameObject);

        //Since the singleton requires us to make sure that we have only one
        //instance of the class, we will fill it with this if there are no others
        //and destroy the other if there is one. This resets the time if the
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
    void Update()
    {
        AddAndDisplayTime();  
    }

    private void AddAndDisplayTime()
    {
        //Adds and updates the time
        gameTime += Time.deltaTime;
        timerText.text = gameTime.ToString("f0");
    }
}
