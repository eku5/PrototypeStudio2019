using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Change_Image : MonoBehaviour
{
    // Start is called before the first frame update

    private int clicks = 0;
    SpriteRenderer currentImage;
    SpriteRenderer nextImage;
    //make list for the order of the images
    public List<SpriteRenderer> dialUpImages;
    int index = 0; //this variable keeps track of the index for the lists

    
    void Start()
    {
        currentImage = dialUpImages[index];
        nextImage = dialUpImages[index + 1];
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyUp(KeyCode.RightArrow))
       {
           clicks++;
       }

       if (clicks == 50)
       {
           index = 1;
           changeImages();
         
           
       } 
       
       if (clicks >= 100)
       {
           index = 2;
           changeImages();
           //Debug.Log("Index: " + index);
       }

       Debug.Log("Clicks: " + clicks);
       Debug.Log("Index: " + index);

    }


    void changeImages()
    {
        //enables and disables SpriteRenderer
        currentImage.enabled = false;
        nextImage.enabled = true;

        currentImage = dialUpImages[index];
        
        //if (index < dialUpImages.Count -1) {
     
        //    index++;
        //}
        
        if (index < dialUpImages.Count -1) { //this is to prevent an out of range error
            nextImage = dialUpImages [index + 1];
   
        }
        
    }
  

  



  
    
}
