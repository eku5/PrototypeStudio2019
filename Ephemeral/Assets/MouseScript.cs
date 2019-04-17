using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Camera cam;
    private SpringJoint2D joint;
    public static MouseScript me;
    void Awake()
    {
        me = this;
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        joint = GetComponent<SpringJoint2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //body follow the mouse
        rb.MovePosition(cam.ScreenToWorldPoint(Input.mousePosition));
    }

    public void MakeJoint(Rigidbody2D clickedBody)
    {
        joint.connectedBody = clickedBody;
    }
    
    void Update()
    {
        //is the player holding the mosue button?
        if (Input.GetMouseButton(0) == false)
        {
            //player isn't holding mouse
            joint.connectedBody = null; //disconnect the attached body if there is one
        }
        
    }
}
