using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimations : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();

    public void Start()
    {
        foreach(var audioSource in GetComponentsInChildren<AudioSource>())
        {
            audioSources[audioSource.gameObject.name] = audioSource;
        }
    }
    public void PlaySoundByName(string audioSourceName)
    {

        if (audioSources.ContainsKey(audioSourceName))
        {
            audioSources[audioSourceName].Play();
        }
        else
        {
            Debug.Log($"Audiosource with name {audioSourceName} not found!");
        }
    }
   

}
