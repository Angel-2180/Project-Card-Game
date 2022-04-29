using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public List<Card> deck;
    public Transform[] handSlot;
    public bool[] slotAvalable;

    public List<Card> discard;

    private void DrawCardFirstTurn()
    {
        if (deck.Count >= 1)
        {
            Card randCard = deck[Random.Range(0, deck.Count)];
            for (int i = 0; i < slotAvalable.Length; i++)
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

                    // PLAY  SOUND
                    AudioManager_SE.instance.Play_Card_Draw();
                }
            }
        }
    }

    private void Update()
    {
        DrawCardFirstTurn();
    }
}