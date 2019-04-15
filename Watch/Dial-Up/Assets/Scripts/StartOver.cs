using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RestartGame", 5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RestartGame()
    {
        Application.Quit();
    }
}
