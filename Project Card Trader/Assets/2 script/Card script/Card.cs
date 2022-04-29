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

    void MoveToDiscardPile()
	{
		gm.hand.Remove(this);
		gm.discard.Add(this);
		gameObject.SetActive(false);
	}

	public void BanCard()
	{
		gm.hand.Remove(this);
		gm.banCard.Add(this);
		gameObject.SetActive(false);
	}

    private void OnMouseUp()
    {
        if(isInshop)
        {
            isPlayed = true;
            gm.slotAvalable[index] = true;
            Invoke("MoveToDiscardPile", 2f);
        }
        else if (!isInshop)
        {
            transform.position = gm.handSlot[index].position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shop")
        {
            Debug.Log("trop bon les pieds");
            isInshop = true;
        }
    }

    void OnTriggerExit(Collider other)
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
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Shop"))
        {
			
			print("Play Card");
        }

    }
}
