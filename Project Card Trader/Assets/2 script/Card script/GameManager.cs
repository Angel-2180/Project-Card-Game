using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Card> deck;
    public List<Card> initialDeck;

    public Transform[] handSlot;
    public bool[] slotAvalable;

    private bool StartTurn = true;

    [SerializeField] private int nbStartCard;

    public List<Card> discard;

    private void Start()
    {
        initialDeck = deck;
    }
    private void DrawCardFirstTurn()
    {
        if (deck.Count >= 1)
        {
            Card randCard = deck[Random.Range(0, deck.Count)];
            for (int i = 0; i < nbStartCard; i++)
            {
                if (slotAvalable[i] == true)
                {
                    randCard.gameObject.SetActive(true);
                    randCard.index = i;
                    randCard.transform.position = handSlot[i].position;
                    randCard.isPlayed = false;
                    deck.Remove(randCard);
                    slotAvalable[i] = false;                  
                    return;
                }
            }
        }
    }  

    private void DrawCard()
    {
        for (int i = 0; i < slotAvalable.Length; i++)
        {
            if (slotAvalable[i] == true)
            {
                Card cardDraw = deck[Random.Range(0, deck.Count)];
                cardDraw.gameObject.SetActive(true);
                cardDraw.index = i;
                cardDraw.transform.position = handSlot[i].position;
                cardDraw.isPlayed = false;
                deck.Remove(cardDraw);
                slotAvalable[i] = false;
                return;
            }
        }
    }

    private void DiscardToDeck()
    {
        foreach(Card card in discard)
        {
            deck.Add(card);
        }
        discard.Clear();
    }
    void Update()
    {
            DrawCardFirstTurn();

        if (Input.GetKeyDown(KeyCode.J))
        {
        }
       
        if (Input.GetKeyDown(KeyCode.K))
        {
            DrawCard();
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            DiscardToDeck();
        }
    }
}
