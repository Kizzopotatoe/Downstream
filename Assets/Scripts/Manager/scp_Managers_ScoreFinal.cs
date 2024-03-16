using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scp_Managers_ScoreFinal : MonoBehaviour
{
    //Reference to the score and time UI
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI finalTime;

    //Stores the coin pile game object
    public GameObject coinPile;

    // Start is called before the first frame update
    void Start()
    {   
        //Sets UI to display the player's final score 
        finalScore.text = scp_Managers_ScoreTracker.instance.trackedScore.ToString();
        finalTime.text = scp_Managers_TimeTracker.instance.gameTime.ToString("f0");

        //Sets the coin pile object to false
        coinPile.SetActive(true);
    }

    void Update()
    {
        //If the player has obtained the maximum number of coins possible, 
        //the coin pile object will appear on the end screen
        if(scp_Managers_ScoreTracker.instance.trackedScore < 15)
        {
            coinPile.SetActive(false);
        }
    }
}
