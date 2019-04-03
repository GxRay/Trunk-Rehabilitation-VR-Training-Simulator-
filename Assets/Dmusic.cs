using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Dmusic : MonoBehaviour
{
    [SerializeField]
    private float SpaceballTimer = 20f;

    public GameObject Spaceball;

    private void Awake()
    {
        InvokeRepeating("MoveSpaceball", SpaceballTimer, SpaceballTimer);

    }

    private void Start()
    {
        FindObjectOfType<AudioManager>().Stop("MenuTheme");
        FindObjectOfType<AudioManager>().Play("DungeonTheme");
    }

    private void MoveSpaceball()
    {
        Spaceball.GetComponent<SpaceBall_Sender>().RandomMovement();
    }
    
}
