using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Dmusic : MonoBehaviour
{
    
    private void Start()
    {
        FindObjectOfType<AudioManager>().Stop("MenuTheme");
        FindObjectOfType<AudioManager>().Play("DungeonTheme");
    }
    
}
