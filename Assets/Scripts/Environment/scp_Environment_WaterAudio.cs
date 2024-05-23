using UnityEngine;

public class scp_Environment_WaterAudio : MonoBehaviour
{
    //Audio source and clip
    public AudioSource source;
    public AudioClip clip;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            source.PlayOneShot(clip);
        }
    }
}
