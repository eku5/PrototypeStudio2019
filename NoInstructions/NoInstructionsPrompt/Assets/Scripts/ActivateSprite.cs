using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class ActivateSprite : MonoBehaviour
{
    private bool isActivated = false;
    public float time;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.anyKey && isActivated == false)
        {
            GetComponent<Fade>().FadeIn(time);
            isActivated = true;
            
        } */

        if (Input.anyKey)
        {
            isActivated = !isActivated;
            if (isActivated == true)
            {
                GetComponent<Fade>().FadeIn(time);
            }
            else
            {
                GetComponent<Fade>().FadeOut(time);
            }
        }

        

    }
}
