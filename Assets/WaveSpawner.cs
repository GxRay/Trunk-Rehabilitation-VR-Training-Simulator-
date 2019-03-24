using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public Vector3 SpawnZone;

    private void Start()
    {
        /// Adds the start time and final time to the spawn object
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);


    }

    public void SpawnObject()
    {
        // Randomizes Spawn Area for Objects between Back Wall (FOR NOW)
        float SpawnZone_X = Random.Range(-3.64f, 2.1f);
        float SpawnZone_Y = Random.Range(-1.3f, 1.4f);
        float SpawnZone_Z = 0.0f;
        SpawnZone = new Vector3(SpawnZone_X, SpawnZone_Y, SpawnZone_Z);
        Instantiate(spawnee, transform.position+SpawnZone, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");

        }
        
    }


}
