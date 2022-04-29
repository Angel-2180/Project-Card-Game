using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Card> deck;
    public List<Card> initialDeck;
    public List<Card> hand;

    public Transform[] handSlot;
    public bool[] slotAvalable;

    [SerializeField] private int nbStartCard;

    public List<Card> discard;
    public List<Card> banCard;

    public int nbCardDraw;
    public int nbCardBan;
    public int nbCardPlay;

    public bool discardHandEndTurn = true;

    private void Start()
    {
        initialDeck = deck;
    }

    public void DrawCardFirstTurn()
    {
        if (deck.Count >= 1)
        {
            for (int i = 0; i < nbStartCard; i++)
            {
                Card randCard = deck[Random.Range(0, deck.Count)];
                if (slotAvalable[i] == true)
                {
                    randCard.gameObject.SetActive(true);
                    randCard.index = i;
                    randCard.transform.position = handSlot[i].position;
                    randCard.isPlayed = false;
                    deck.Remove(randCard);
                    hand.Add(randCard);
                    slotAvalable[i] = false;

                    // PLAY  SOUND
                    //AudioManager_SE.instance.Play_Card_Draw();
                }
            }
        }
    }

    public void DiscardHand()
    {
        for (int i = 0; i < handSlot.Length; i++)
        {
            slotAvalable[i] = true;
        }
        foreach (Card card in hand)
        {
            discard.Add(card);
            card.gameObject.SetActive(false);

            // PLAY  SOUND
            AudioManager_SE.instance.Play_Card_Discard();
        }
        hand.Clear();
    }

    public void DrawCard()
    {
        for (int i = 0; i < slotAvalable.Length; i++)
        {
            if (slotAvalable[i] == true)
            {
                Card cardDraw = deck[Random.Range(0, deck.Count)];
                nbCardDraw += 1;
                cardDraw.gameObject.SetActive(true);
                cardDraw.index = i;
                cardDraw.transform.position = handSlot[i].position;
                cardDraw.isPlayed = false;
                deck.Remove(cardDraw);
                hand.Add(cardDraw);
                slotAvalable[i] = false;
                return;

                // PLAY  SOUND
                AudioManager_SE.instance.Play_Card_Draw();
            }
        }
    }

    public void DiscardToDeck()
    {
        foreach (Card card in discard)
        {
            deck.Add(card);

            // PLAY  SOUND
            AudioManager_SE.instance.Play_Card_Discard();
        }
        discard.Clear();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    hand[1].transform.position = GameObject.Find("Played Card Slot").transform.position;
        //}
        //DrawCardFirstTurn();

        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //}

        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    DrawCard();
        //}
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    DiscardToDeck();
        //}
    }
}