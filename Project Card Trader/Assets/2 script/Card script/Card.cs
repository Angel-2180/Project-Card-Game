using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    public int id;
    public int index;
    public int cost;

    public bool isCost = true;
    public bool isPlayed;
    public bool beingDrag;
    private bool isInshop;

    public CardEffects effects;
    public GameManager gm;

    //private void OnMouseDown()
    //{
    //    if (!isPlayed)
    //    {
    //        transform.position = GameObject.Find("Played Card Slot").transform.position;
    //        isPlayed = true;
    //        gm.slotAvalable[index] = true;
    //        Invoke("MoveToDiscardPile", 2f);
    //    }
    //}

    private void MoveToDiscardPile()
    {
        gm.hand.Remove(this);
        gm.discard.Add(this);
        gameObject.SetActive(false);

        // PLAY  SOUND
        AudioManager_SE.instance.Play_Card_Discard();
    }

    public void BanCard()
    {
        gm.hand.Remove(this);
        gm.banCard.Add(this);
        gameObject.SetActive(false);

        // PLAY  SOUND
        AudioManager_SE.instance.Play_Card_Exhaust();
    }

    private void OnMouseUp()
    {
        if (isInshop)
        {
            if (cost <= CardEffects.stat.player.energie)
            {
                gm.nbCardPlay += 1;
                Debug.Log("B" + CardEffects.stat.player.energie);
                isPlayed = true;
                CardEffects.stat.player.energie -= cost;
                effects.ChooseCardEffects(id);
                gm.slotAvalable[index] = true;
                Invoke("MoveToDiscardPile", 2f);
                Debug.Log("A" + CardEffects.stat.player.energie);

                // PLAY  SOUND
                AudioManager_SE.instance.Play_Card_Select();
            }
            else
            {
                transform.position = gm.handSlot[index].position;
            }
        }
        else if (!isInshop)
        {
            transform.position = gm.handSlot[index].position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shop")
        {
            Debug.Log("trop bon les pieds");
            isInshop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Shop")
        {
            Debug.Log("ALED");
            isInshop = false;
        }
    }

    private void Update()
    {
        if (!beingDrag)
        {
            //Retourne dans la main
            //print("Retrun to hand");
        }
        beingDrag = false;
    }

    private void OnMouseDrag()
    {
        beingDrag = true;
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        transform.position = worldPosition;

        // PLAY  SOUND
        AudioManager_SE.instance.Play_Card_Hover();
    }
}