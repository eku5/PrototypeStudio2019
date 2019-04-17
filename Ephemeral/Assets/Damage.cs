using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int health =5;

    public AudioClip myClip;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    //this is called when someone clicks the object
    private void OnMouseDown()
    {
        //take damage
        TakeDamage();
        
        
        //tell the mouseScript to make the joint
        MouseScript.me.MakeJoint(GetComponent<Rigidbody2D>());
    }

    private void TakeDamage()
    {
        health -= 1;

        if (health <= 0)
        {
            //play some kind of sound
            if (myClip != null)
            {
                SoundFriend.me.GetComponent<AudioSource>().PlayOneShot(myClip);            
            }
            else
            {
                //handle case where myClip is empty in the inspector
                //play the clip that's on the soundfriend instead
                SoundFriend.me.GetComponent<AudioSource>().Play();
            }
            
            //delete myself
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {

        TakeDamage();
    }
}
