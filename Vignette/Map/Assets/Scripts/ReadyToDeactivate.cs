using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyToDeactivate : MonoBehaviour
{
    public RevealMemory[] allTheMemoriesInThisTheme;
    public ThemeManager themeManager;

    public AudioSource audioSource;
    

    private bool allMemoriesSeen;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("update is occuring");
            
        
        allMemoriesSeen = true;
        
        for (int i = 0; i < allTheMemoriesInThisTheme.Length; i++)
        {
            //Debug.Log("for loop is occuring");
            if (!allTheMemoriesInThisTheme[i].hasBeenSeen)
            {
                allMemoriesSeen = false; //if it hasn't been seen yet, it is set to false
                Debug.Log("index " + i + " has not been seen");
            }
        }

        if (allMemoriesSeen)
        {
            PlaySound();
            Debug.Log("allMemoriesSeen");
            themeManager.NextTheme();
            Destroy(this);
            
        }

    }
    
    public void PlaySound()
    {
        audioSource.Play();
    }
}
