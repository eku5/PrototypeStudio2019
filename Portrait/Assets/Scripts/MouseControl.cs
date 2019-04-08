using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public ParticleSystem ps;

    private Transform cameraTransform;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
  //      Cursor.lockState = CursorLockMode.Confined; //lock the cursor
    //    Cursor.visible = false; //hide the cursor
        cameraTransform = Camera.main.transform;
        cam = Camera.main;
        
    }


    // Update is called once per frame
    void Update()
    {
        
        //move the mouse object when the mouse moves
        //have the object follow mouse
        Vector3 temp = Input.mousePosition;
        temp.z = 10f;
        Vector3 newPosition = cam.ScreenToWorldPoint(temp);
      

        transform.position = newPosition;

    
        if (Input.GetMouseButtonDown(0))
        {
            ps.Play();   
        }

        if (Input.GetMouseButtonUp(0))
        {
            ps.Stop();
        }

    }
}
