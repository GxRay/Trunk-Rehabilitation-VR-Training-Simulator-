using UnityEngine;
using UnityEngine.Audio;


[System.Serializable]
public class Sound 
{
    // Calling instance of audioclip class to allow for audio to be played using variable clip.
    public AudioClip clip;
    
    //Using name of audio file
    public string name;


    // Allowing for adjusting of volume and pitch on music
    [Range (0f,1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;


    [HideInInspector]
    public AudioSource source;




}
