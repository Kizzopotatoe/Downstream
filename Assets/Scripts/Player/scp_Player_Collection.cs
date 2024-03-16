using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scp_Player_Collection : MonoBehaviour
{
    //Variable storing the amount of fish caught by the player
    public int fishCaught = 0;
    //Variable storing the amount of score the player has accumulated
    public int score = 0;

    //Variables storing the UI that will track fish caught and current score
    public TextMeshProUGUI fishUI;
    public TextMeshProUGUI scoreUI;

    //Audio source and clip
    public AudioSource source;
    public AudioClip clip;

    void Start()
    {
        //Sets the UI to display these values
        fishUI.text = fishCaught.ToString();
        scoreUI.text = score.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        //If an enemy enters the trigger inside the bucket, it will be destroyed
        //the fish caught variable will increase by one, and the UI will update.
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            fishCaught++;
            fishUI.text = fishCaught.ToString();
            source.PlayOneShot(clip);
        }

        //If a collectible enters the trigger inside the bucket, it will be destroyed
        //the score variable will increase by one, and the UI will update.
        if(other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            score++;
            scoreUI.text = score.ToString();
            source.PlayOneShot(clip);
            scp_Managers_ScoreTracker.instance.UpdateScore();
        }
    }
}
