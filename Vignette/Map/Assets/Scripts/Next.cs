using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public int changeSceneTime;
    public AudioSource audioSource;
    
    private bool soundPlayed;
    void Start()
    {
        changeSceneTime = 2;
        soundPlayed = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!soundPlayed)
            {
                PlaySound();
                soundPlayed = true;
            }
            Invoke("NextScene",changeSceneTime);
        } 
    }
    public void PlaySound()
    {
        audioSource.Play();
    }
    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
    }
}
