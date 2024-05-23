using UnityEngine;

public class scp_Managers_Controls : MonoBehaviour
{
    //Stores the controls screen
    public GameObject controls;

    //Audio clip and source
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        controls.SetActive(false);
    }

    //Opens the controls screen
    public void OpenControls()
    {
        controls.SetActive(true);
        //Plays audio clip
        source.PlayOneShot(clip);
    }

    //Closes the controls screen
    public void CloseControls()
    {
        controls.SetActive(false);
    }
}
