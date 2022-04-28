using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int index;
    public bool isPlayed;

	public GameManager gm;
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
}
