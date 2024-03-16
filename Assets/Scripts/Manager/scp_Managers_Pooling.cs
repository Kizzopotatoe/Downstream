using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scp_Managers_Pooling : MonoBehaviour
{
    //This line is for the Singleton Pattern which will allow us to access this class without any reference
    public static scp_Managers_Pooling instance;

    //List to contain all the pooled objects
    private List<GameObject> pooledProjectiles = new List<GameObject>();
    private List<GameObject> pooledFish = new List<GameObject>();

    //The amount of objects to be added to the pool
    public int poolAmount = 10;

    [Header("Prefabs")] 
    //The prefab we want to pool
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject fishPrefab;

    [Header("Pools")]
    //The object we want to act as the pools
    public GameObject projectilePool;
    public GameObject fishPool;

    private void Awake()
    {
        //Since the singleton requires us to make sure that we have only one
        //instance of the class, we will fill it with this if there are no others
        //and destroy it if there are
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolAmount; i++)                                            //Will run as many times as we want the pool amount to be
        {
            GameObject projectileToAddToPool = Instantiate(projectilePrefab);                 //Will instantiate a projectile prebab each round
            projectileToAddToPool.transform.parent = projectilePool.transform;                //Will set each projectile to be a child of the gameobject this script is attached to
            projectileToAddToPool.SetActive(false);                                           //Will deactivate it
            pooledProjectiles.Add(projectileToAddToPool);                                     //Will add it to the pool list

            GameObject fishToAddToPool = Instantiate(fishPrefab);                               //Will instantiate a fish prebab each round
            fishToAddToPool.transform.parent = fishPool.transform;                              //Will set each fish to be a child of the gameobject this script is attached to
            fishToAddToPool.SetActive(false);                                                   //Will deactivate it
            pooledFish.Add(fishToAddToPool);                                                    //Will add it to the pool list
        }
    }

    public GameObject GetPooledProjectiles()
    {
        for (int i = 0; i < pooledProjectiles.Count; i++)      //Will go through the pool
        {
            if (!pooledProjectiles[i].activeInHierarchy)       //Will look for the first projectile that is not active
            {
                return pooledProjectiles[i];                   //And will return it
            }
        }

        return null;                                    //If there are none, return nothing
    }

    public GameObject GetPooledFish()
    {
        for (int i = 0; i < pooledFish.Count; i++)          //Will go through the pool
        {
            if (!pooledFish[i].activeInHierarchy)           //Will look for the first fish that is not active
            {
                return pooledFish[i];                       //And will return it
            }
        }

        return null;                                    //If there are none, return nothing
    }
}
