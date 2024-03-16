using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Managers_Credits : MonoBehaviour
{
    //Stores the ending and credits screens
    public GameObject credits;
    public GameObject ending;

    // Start is called before the first frame update
    void Start()
    {
        credits.SetActive(false);
        ending.SetActive(true);
    }

    //Opens the controls screen
    public void OpenCredits()
    {
        credits.SetActive(true);
        ending.SetActive(false);
    }

    //Closes the controls screen
    public void CloseCredits()
    {
        credits.SetActive(false);
        ending.SetActive(true);
    }
}
