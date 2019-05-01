using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealMemory : MonoBehaviour
{
    public GameObject showText;
    public GameObject showPhoto;
    
    void OnMouseOver()
    {
        showText.SetActive(true);
        showPhoto.SetActive(true);
    }

    void OnMouseExit()
    {
        showText.SetActive(false);
        showPhoto.SetActive(false);
    }
}
