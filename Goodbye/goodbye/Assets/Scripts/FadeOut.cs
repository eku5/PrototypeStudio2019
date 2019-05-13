using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
   
    private SpriteRenderer sr;
    public float fadeTime;
    
    void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }

    private void OnTriggerEnter2D()
    {
        
        Color c = sr.color;
        c.a -= 1 / fadeTime * Time.deltaTime; //how much the alpha is changing per frame
        sr.color = c;
    }
}
