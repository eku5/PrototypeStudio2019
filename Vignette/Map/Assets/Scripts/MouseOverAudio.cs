using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Plays a random audio clip from the audioClips array when PlaySound is called
/// Requires an AudioSource
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class MouseOverAudio : MonoBehaviour
{
    public AudioClip[] audioClips;

    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
    }
}
