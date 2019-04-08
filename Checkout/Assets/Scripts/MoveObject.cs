using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Start is called before the first frame update
    Transform dragObject;
     
    void Update() {
 
        if (dragObject) {
            // dragObject not null, move it according to mouse input
        }
 
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hitInfo = new RaycastHit();
            if ( Physics.Raycast( Camera.main.ScreenPointToRay( Input.mousePosition ), out hitInfo )) {
                dragObject = hitInfo.collider.transform;
            }
        }
 
        if (Input.GetMouseButtonUp(0)) {
            dragObject = null;
        }
 
    }
}
