using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Projectile : MonoBehaviour
{
    //Reference to the projectiles rigidbody component
    public Rigidbody rb;

    void OnTriggerEnter(Collider other)
    {
        //If the projectile hits a wall, it will respawn a fish
        if(other.gameObject.CompareTag("Wall"))
        {
            SpawnFish();
        }

        //If the projectile hits a desired target, no fish will be spawned
        if (other.gameObject.CompareTag("Target"))
        {
            NoFish();
        }
    }

    void SpawnFish()
    {
        //Stores the first fish in the pool as the spawned fish variable
        GameObject spawnedFish = scp_Managers_Pooling.instance.GetPooledFish();
        if (spawnedFish != null)
        {
            //Spawns the fish at the position and rotation of the projectile
            spawnedFish.transform.position = gameObject.transform.position;
            spawnedFish.transform.rotation = gameObject.transform.rotation;
            //Sets the fish object active
            spawnedFish.SetActive(true);
            //Destroys projectile
            gameObject.SetActive(false);
            //Sets the velocity of the projectile to zero, stopping the force on the object
            rb.velocity = Vector3.zero;
        }
    }

    void NoFish()
    {
        //Destroys projectile
        gameObject.SetActive(false);
        //Sets the velocity of the projectile to zero, stopping the force on the object
        rb.velocity = Vector3.zero;
    }

}
