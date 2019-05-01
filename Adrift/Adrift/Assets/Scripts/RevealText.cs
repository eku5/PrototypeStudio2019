using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealText : MonoBehaviour
{
    public GameObject showText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    
    void OnMouseOver()
    {
        showText.SetActive(true);
       
    }

    void OnMouseExit()
    {
        showText.SetActive(false);
    }
    
}
