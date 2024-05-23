using UnityEngine;

public class scp_Managers_Pause : MonoBehaviour
{
    //Stores the pause screen
    public GameObject pauseScreen;
    //Bool to store whether the scene is paused
    public bool isPaused;

    //Audio clip and source
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        // Hides the cursor and pause screen when the scene starts
        Cursor.visible = false;
        pauseScreen.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") && isPaused == false)
        {
            //Shows the cursor and pause screen
            Cursor.visible = true;
            pauseScreen.SetActive(true);
            isPaused = true;
            //Sets the time scale to 0 to pause the game
            Time.timeScale = 0;
            //Plays audio clip
            source.PlayOneShot(clip);
        }
    }

    public void Unpause()
    {
        //Hides the cursor and pause screen
        Cursor.visible = false;
        pauseScreen.SetActive(false);
        isPaused = false;
        //Sets the time scale to 1 to resume the game
        Time.timeScale = 1;
    }
}
