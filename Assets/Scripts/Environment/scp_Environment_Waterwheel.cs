using UnityEngine;

public class scp_Environment_Waterwheel : MonoBehaviour
{
    //Gate to open
    public GameObject gate;

    //Audio source and clip
    public AudioSource source;
    public AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        //If this object collides with a trigger, the specified gate will be destroyed.
        //In game, the trigger will be a section of the waterwheel that must be rotated 
        //to collide with the object this script is attached to.
        if(other.gameObject.CompareTag("Trigger"))
        {
            Destroy(gate);
            source.PlayOneShot(clip);
        }
    }
}
