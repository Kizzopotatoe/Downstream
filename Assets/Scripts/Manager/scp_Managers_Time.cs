using UnityEngine;
using TMPro;

public class scp_Managers_Time : MonoBehaviour
{
    //Reference to the timer UI
    public TMP_Text timerText;
    //The current in game time
    public float gameTime = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        //Displays the game time in the timer text
        timerText.text = gameTime.ToString("f0");
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
