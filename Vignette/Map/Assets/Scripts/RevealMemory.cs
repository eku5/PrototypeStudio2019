using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealMemory : MonoBehaviour
{
    public GameObject showText;
    public GameObject showPhoto;
    public bool hasBeenSeen;

    public MouseOverAudio mouseOverAudio;
    
    private bool soundPlayed;

    void Start()
    {
        hasBeenSeen = false;
        soundPlayed = false;
    }
    
    void OnMouseOver()
    {
        showText.SetActive(true);
        showPhoto.SetActive(true);
        hasBeenSeen = true;

        if (!soundPlayed)
        {
            mouseOverAudio.PlaySound();
            soundPlayed = true;
        }
    }

    void OnMouseExit()
    {
        showText.SetActive(false);
        showPhoto.SetActive(false);
        soundPlayed = false;
    }
}
