using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public AudioClip sound;
    AudioSource audioSource;
    bool soundplayed = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && soundplayed == false)
        {
            audioSource.PlayOneShot(sound, .7f);
            Invoke("AdvanceScene", 4);
            soundplayed = true;
        }
    }
    
    void AdvanceScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
