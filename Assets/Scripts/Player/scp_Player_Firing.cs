using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Player_Firing : MonoBehaviour
{
    //Stores the point where the fish spawns
    public Transform firepoint;
    //Stores the speed that the fish will be fired at
    public float projectileSpeed;

    //Reference to the collection script
    public scp_Player_Collection collection;

    //Audio source and clip
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        //Stores the collection script
        collection = GetComponent<scp_Player_Collection>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the player presses the space key, and they have at least 1 fish caught, then..
        if (Input.GetKeyDown("space") && collection.fishCaught >= 1)
        {
            //Calls the Fire method
            Fire();
            //Removes 1 from the fish caught variable
            collection.fishCaught--;
            //Updates the UI
            collection.fishUI.text = collection.fishCaught.ToString();
            //Plays audio
            source.PlayOneShot(clip);
        }
    }

    void Fire()
    {
        //Stores the first projectile in the pool as the spawned projectile variable
        GameObject spawnedProjectile = scp_Managers_Pooling.instance.GetPooledProjectiles();
        if (spawnedProjectile != null)
        {
            //Spawns the projectile at the position and rotation of the firepoint
            spawnedProjectile.transform.position = firepoint.transform.position;
            spawnedProjectile.transform.rotation = firepoint.transform.rotation;
            //Sets the projectile object active
            spawnedProjectile.SetActive(true);
            //Adds force to the spawned projectile along the Z axis
            spawnedProjectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, projectileSpeed));
        }
    }
}
