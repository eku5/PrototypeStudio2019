using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float cameraHeight;
    void Start(){
        cameraHeight = transform.position.z; //where the camera is in the editor
    }
    void Update() {
        Vector3 pos = player.transform.position;
        pos.z = cameraHeight;
        transform.position = pos;
    }
}