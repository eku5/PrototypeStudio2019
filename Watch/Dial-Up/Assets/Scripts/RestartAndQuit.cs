using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartAndQuit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        if (Input.GetKey("escape") || Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            PlaytestChangeScene();
        }
    }

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("RestartAndQuit");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
	
    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    void PlaytestChangeScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
        
}

