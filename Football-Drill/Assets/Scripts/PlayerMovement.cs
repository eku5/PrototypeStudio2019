using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = .05f; // (or whatever)

    public Transform[] targets;
    private int currentTargetNumber = 0;

    public Rigidbody2D ballRB;
    
   void FixedUpdate() {
       
   
       //get a reference to the rigidbody so we can move it
       Rigidbody2D rb = GetComponent<Rigidbody2D>();

       Transform currentTarget = targets[currentTargetNumber];
       //run to current target

       //get the vector between the target and the player
       //triangle
       Vector2 vectorToTarget = (Vector2)currentTarget.position - rb.position;
      
       //check to see if we're close to the target
       if (vectorToTarget.magnitude < 0.1f)
       {
           if (currentTargetNumber < targets.Length - 1)
           {
               //change target and recalculate the vectors
               currentTargetNumber += 1;
               currentTarget = targets[currentTargetNumber];
               vectorToTarget = (Vector2)currentTarget.position - rb.position;
           }
          
       }
       
       
      //run at moveSpeed toward the target
      rb.velocity = vectorToTarget.normalized * moveSpeed;

      
  
      //let's have the player face in the direction they're running in
      //to do this we derive the angle from the x and y part of the direction vector
      //really just a canned line of code that you don't have to remember
      float angle = Mathf.Atan2(vectorToTarget.normalized.y, vectorToTarget.normalized.x) * Mathf.Rad2Deg -90f; 
          
      rb.MoveRotation(angle); //set the rotation


      //to kick the ball
      //if (Input.GetMouseButtonDown(0)) //0 is left mouse button
      if (Input.GetKeyDown("space"))
      {
          //get distance vector to the ball from the player
          Vector2 vectorToBall = ballRB.position - rb.position;
          float distanceToBall = vectorToBall.magnitude;
          if (distanceToBall < 1.0f)
          {
              //kick the ball
              float kickSpeed = 4f;
              ballRB.velocity = vectorToBall.normalized * kickSpeed;
          }

      }
   }
}
