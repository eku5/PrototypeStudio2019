using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyToDeactivate : MonoBehaviour
{
    public RevealMemory[] allTheMemoriesInThisTheme;
    public ThemeManager themeManager;

    private bool allMemoriesSeen;


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
            Debug.Log("allMemoriesSeen");
            themeManager.NextTheme();
            Destroy(this);
            
        }
        

    }
}
