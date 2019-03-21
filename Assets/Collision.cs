using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Collision : MonoBehaviour
{
   
    public Text livesText;
    public int lives;
   // public WaveSpawner spike = new WaveSpawner();

    private void Start()
    {
        lives = 3;
        SetLiveText();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colided");
        lives -= 1;
        SetLiveText();
        FindObjectOfType<AudioManager>().Play("Hurt_Sound");
        Destroy(other.gameObject);
    }

    void SetLiveText()
    {
        livesText.text = "Lives: " + lives.ToString();

    }
}
