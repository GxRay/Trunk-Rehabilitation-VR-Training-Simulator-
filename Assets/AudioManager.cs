using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;


     void Awake()
    {
        // Allows ony one instance of audiomanager to run through game
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
               // Doesn't destory audiomanager, allows for use of script throughout multiple scenes
        //DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
       Sound s= Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        // If sound is not found
        if (s == null)
        {
            Debug.Log("Sound: " + name + "not found!");
             return;
        }
          
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
        // If sound is not found
        if (s == null)
        {
            Debug.Log("Sound: " + name + "not found!");
            return;
        }

    }




}
