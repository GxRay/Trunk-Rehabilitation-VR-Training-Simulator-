using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    private void Start()
    {
        /// Adds the start time and final time to the spawn object
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);


    }

    public void SpawnObject()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");

        }
        
    }


}
