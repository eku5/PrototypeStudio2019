using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeImage : MonoBehaviour
{
    private int clicks = 0;

    //the renderer that will draw the sprites. Here I'm setting it in code (in Start())
    //but you could also set it public and set it in the inspector

    private SpriteRenderer spriteRenderer;
    
    //make list for the order of the images
    //we'll use Sprites (the actual image file) for the list

    public List<Sprite> dialUpImages;
    
    private int index; //this variable keeps track of the index for the lists

    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            clicks++;
        }

        if ((index ==0) && (clicks>50)){
            //now that clicks is over 50 let's start giving it a chance to change
            //Random.value is a random number between 0 and 1. 10% of the time it should be above 0.9
          
            if (Random.value > 0.9f){ 
                index = 1;
                spriteRenderer.sprite = dialUpImages[index];
            }
        }
       
        if ((index == 1) && (clicks >= 100))
        {
            //same again
            if (Random.value > 0.9f){ 
                index = 2;
                spriteRenderer.sprite = dialUpImages[index];
            }
            
        }

        if (index == 2)
        {
            Invoke("NextScene", 4);
        }

    }
    
    void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}