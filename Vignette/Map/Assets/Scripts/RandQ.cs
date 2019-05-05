using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandQ : MonoBehaviour
{
   void Update()
       {
           if (Input.GetKeyDown(KeyCode.R))
           {
               SceneManager.LoadScene(0);
           }
           
           if (Input.GetKey("escape") || Input.GetKeyDown(KeyCode.Q))
           {
               Application.Quit();
           }
        }
}
