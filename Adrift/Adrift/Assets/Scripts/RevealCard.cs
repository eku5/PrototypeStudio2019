using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealCard : MonoBehaviour
{

    public List<GameObject> cards;
    public GameObject showCard;
    public GameObject backOfCard;
   

    public bool cardIsFlipped;

    public int index;
    public int revealTracker;

    private void OnMouseDown()
    {
        showCard = cards[index];
        showCard.SetActive(true);
        backOfCard.SetActive(false);
        cardIsFlipped = true;
        Debug.Log("A card was revealed.");
    }



    void Awake()
    {
        revealTracker = 0;
        cardIsFlipped = false;
        index = Random.Range(0, cards.Count);
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            
            /*if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);

                if (hit.collider.gameObject.name == "Left_Card" && revealTracker == 0)
                {
                    GameObject.Find("Moon").SetActive(true);
                    GameObject.Find("Moon_Text").SetActive(true);
                    revealTracker = 1;
                    Debug.Log("Left card revealed. Reveal tracker: " + revealTracker);
                }
                
                void OnMouseOver()
                {
                    //If your mouse hovers over the GameObject with the script attached, output this message
                    Debug.Log("Mouse is over GameObject.");
                }

                
                if (hit.collider.gameObject.name == "Center_Card" && revealTracker == 1)
                {
                    GameObject.Find("Star_Reversed").SetActive(true);
                    GameObject.Find("Star_Reversed_Text").SetActive(true);
                    Debug.Log("Star Reversed revealed. Reveal tracker: " + revealTracker);
                    revealTracker = 2;
                }

                
            }*/
        }


    }
}
