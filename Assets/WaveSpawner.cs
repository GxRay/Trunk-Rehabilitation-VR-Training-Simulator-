using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public GameObject Player;
   // public int Game_Level;
    public Vector3 SpawnZone;

    private void Start()
    {
        /// Adds the start time and final time to the spawn object
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void StartSpawn ()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);

    }

    public void SpawnObject()
    {
        if (stopSpawning)
        {
            Destroy(spawnee);
            CancelInvoke("SpawnObject");
            
        } 
        else
        {
            // Randomizes Spawn Area for Objects between Back Wall (FOR NOW)
            float SpawnZone_X = Random.Range(Player.transform.position.x - 2f, Player.transform.position.x + 2f);
            float SpawnZone_Y = Random.Range(Player.transform.position.y - 4f, Player.transform.position.y + 1f);
            float SpawnZone_Z = 25.02f;
            SpawnZone = new Vector3(SpawnZone_X, SpawnZone_Y, SpawnZone_Z);
            Instantiate(spawnee, SpawnZone, transform.rotation);

        }
      
       
        
    }


}
