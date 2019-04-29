using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealCard : MonoBehaviour
{

    public List<GameObject> cards;
    public GameObject showCard;

    //for randomly selecting a card from the deck
    public int index;

    //for keeping track of the order to reveal the cards
    public CardTracker cardTracker;
    public int myRevealTracker;
    
   

    private void OnMouseDown()
    {
        if (myRevealTracker == cardTracker.revealTracker)
        {
            //set the showCard (aka the card to be revealed)
            //picked from the list
            showCard = cards[index];
            showCard.SetActive(true);
            Debug.Log("A card was revealed.");
            cardTracker.revealTracker++;
        }
    }

    void Awake()
    {
        //pick a random number from the list
        index = Random.Range(0, cards.Count);
    }
}
