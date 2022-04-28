using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Card : MonoBehaviour
{
    public int index;
    public bool isPlayed;

	public bool isCost = true;

    public bool beingDrag;


	public GameManager gm;

    private void Awake()
    {
		GetComponent<BoxCollider2D>().isTrigger = true;
		GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnMouseDown()
	{
		if (!isPlayed)
		{
			transform.position = GameObject.Find("Played Card Slot").transform.position;
			isPlayed = true;
			gm.slotAvalable[index] = true;
			Invoke("MoveToDiscardPile", 2f);
		}
	}

    private void Update()
    {
        if (!beingDrag)
        {
			//Retourne dans la main
			print("Retrun to hand");
		}
		beingDrag = false;
	}

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
			//Ici tu appelle l'effet de la carte bg
			print("Play Card");
        }

    }
}
