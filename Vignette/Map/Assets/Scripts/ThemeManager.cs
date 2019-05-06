using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ThemeManager : MonoBehaviour
{
    public GameObject[] themes;
    public int currentTheme;

    public int changeSceneTime;

    void Start()
    {
        currentTheme = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void NextTheme()
    {
        
        //themes[currentTheme].SetActive(false);
        if (currentTheme < themes.Length - 1)
        {
            themes[currentTheme + 1].SetActive(true);
            currentTheme += 1;
        }
        else
        {
            Invoke("GoToEnd", changeSceneTime);
        }  
    }

    public void GoToEnd()
    {
        SceneManager.LoadScene(2);
    }
    
    
}
