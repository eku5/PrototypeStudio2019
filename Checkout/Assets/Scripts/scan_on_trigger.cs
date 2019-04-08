using UnityEngine;
using System.Collections;

public class scan_on_trigger : MonoBehaviour
{
    public bool activateTrigger = false;

   
    public GameObject Sound;
    private Animator scanned;


    void Start()
    {
        
        Sound.SetActive(false);
        scanned = GetComponent<Animator>();
    }


    void Update()
    {

        if (activateTrigger)
        {
            
            Sound.SetActive(true);
            scanned.SetBool("isScanning", true);
            
            Debug.Log("Scanned!");
            
            //Destroy(this.gameObject);
        }
      

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Something hit the scanner");
        if (col.gameObject.CompareTag("StuffToScan"))
        {
            
            activateTrigger = true;
        }

    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("StuffToScan"))
        {
            
            activateTrigger = false;
            scanned.SetBool("isScanning", false);
        }

    }
}