using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Collision : MonoBehaviour
{ 

    public Text Live_Text, Score_Text;
    public int lives, score;


    private void Start()
    {
        lives = 3;
        score = 0;
        SetLiveText();
        SetScoreText();
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colided");

        // If the Player hits the Spiked Ball   
        if (other.gameObject.tag == "Spike")
        {
            lives -= 1;
            SetLiveText();
            FindObjectOfType<AudioManager>().Play("Hurt_Sound");
            Destroy(other.gameObject);
        }
        // If the Player hits the Red Gem
        if (other.gameObject.tag == "Score_Gem")
        {
            score += 10;
            SetScoreText();
            FindObjectOfType<AudioManager>().Play("Gem_Sound");
            Destroy(other.gameObject);
        }

    }

    void SetLiveText()
    {
        Live_Text.text = "Lives: " + lives.ToString();

    }

    void SetScoreText()
    {
        Score_Text.text = "Score: " + score.ToString();

    }



}

