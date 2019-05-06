using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public int changeSceneTime;
    void Start()
    {
        changeSceneTime = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Invoke("NextScene",changeSceneTime);
        } 
    }

    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
    }
}
