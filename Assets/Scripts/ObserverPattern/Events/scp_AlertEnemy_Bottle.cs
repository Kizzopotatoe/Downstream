using UnityEngine;

public class scp_AlertEnemy_Bottle : MonoBehaviour
{
    //Stores the game event script in this variable
    public scp_GameEvent gameEvent;
    //Reference to the camera shake script
    public scp_Camera_Shake shake;

    //Audio source and clip
    public AudioSource source;
    public AudioClip clip;

    void Start()
    {
        shake = FindObjectOfType<scp_Camera_Shake>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //Fires the raise method from the game event script
            gameEvent.Raise();
            //Plays audio
            source.PlayOneShot(clip);
            //Destroys the game object
            Destroy(gameObject);
            //Calls the camera shake method 
            shake.Shake();
        }
    }
}
