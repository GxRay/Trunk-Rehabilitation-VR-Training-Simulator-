using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{
    public float timer = 60.0f;
    public float timeIncrement = 0.1f;
    public int level = 1;
    public Text Time_Text;
    double timer_totext;
    public GameObject LiveText, ScoreText, BioFeedback, ScoreBoard,Spaceball;
    public WaveSpawner SGemSpawner, LGemSpawner, SpSpawner;
    public float SpaceballTimer = 20f;


    private void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        timer = 40.0f;
        InvokeRepeating("MoveSpaceball", SpaceballTimer, SpaceballTimer);
        InvokeRepeating("SetTimeText", 0f, timeIncrement);
        SpaceballTimer = SpaceballTimer / 2;

    }

    // Displays the LevelCompleted menu and disables everything else
    public void ScoreMenu()
    {
        LiveText.SetActive(false);
        ScoreText.SetActive(false);
        BioFeedback.SetActive(false);
        SGemSpawner.stopSpawning = true;
        LGemSpawner.stopSpawning = true;
        SpSpawner.stopSpawning = true;
        ScoreBoard.SetActive(true);

    }
    // Decreasing and printing current time elapsed on screen.
    void SetTimeText()
    {
        timer -= timeIncrement;
        if (timer <= 0f)
        {
            CancelInvoke("SetTimeText");
            CancelInvoke("MoveSpaceball");
            ScoreMenu();

        }
        // Rounds the current time to 2 decimal places
        timer_totext = Math.Round(timer, 2);
        Time_Text.text = "Time: " + timer_totext.ToString();

    }

    public void LevelAdd ()
    {
        level += 1;

        // Resume Spawning of Objects
        SGemSpawner.stopSpawning = false;
        LGemSpawner.stopSpawning = false;
        SpSpawner.stopSpawning = false;

        SGemSpawner.StartSpawn();
        LGemSpawner.StartSpawn();
        SpSpawner.StartSpawn();
    }

    //Controlling Spaceball movement
    private void MoveSpaceball()
    {
        Spaceball.GetComponent<SpaceBall_Sender>().RandomMovement();
    }


}
