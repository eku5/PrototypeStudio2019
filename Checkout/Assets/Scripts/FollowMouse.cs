﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {
	




    // Use this for initialization
    void Start () {


    }
	
    // Update is called once per frame
    void Update () {


        //have the object follow mouse
        Vector3 temp = Input.mousePosition;
        temp.z = 10f;

        this.transform.position = Camera.main.ScreenToWorldPoint(temp);

    }
}
