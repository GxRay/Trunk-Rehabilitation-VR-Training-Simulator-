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
        StartSpawn();
    }

    public void StartSpawn ()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);

    }

    public void SpawnObject()
    {
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
            
        } 
        else
        {
            bool same = true;
            // Randomizes Spawn Area for Objects between Back Wall (FOR NOW)
            float SpawnZone_X = Random.Range(Player.transform.position.x - 2f, Player.transform.position.x + 2f);
            float SpawnZone_Y = Random.Range(Player.transform.position.y - 3f, Player.transform.position.y + 1f);
            while (same)
            {
                if (SpawnZone_X >= Player.transform.position.x - 0.5 && SpawnZone_X <= Player.transform.position.x + 0.5)
                {
                    SpawnZone_X = Random.Range(Player.transform.position.x - 1.5f, Player.transform.position.x + 1.5f);
                }
                if (SpawnZone_Y >= Player.transform.position.y - 1 && SpawnZone_Y <= Player.transform.position.y + 0.263)
                {
                    SpawnZone_Y = Random.Range(Player.transform.position.y - 3f, Player.transform.position.x + 1f);
                }
                else
                {
                    same = false;
                }
            }
            float SpawnZone_Z = 25.02f;
            SpawnZone = new Vector3(SpawnZone_X, SpawnZone_Y, SpawnZone_Z);
            Instantiate(spawnee, SpawnZone, transform.rotation);

        }
      
       
        
    }


}
