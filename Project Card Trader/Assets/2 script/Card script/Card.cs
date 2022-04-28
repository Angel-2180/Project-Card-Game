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

	void MoveToDiscardPile()
	{
		gm.hand.Remove(this);
		gm.discard.Add(this);
		gameObject.SetActive(false);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Shop"))
        {
			//Ici tu appelle l'effet de la carte bg
        }
    }
}
