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
			Debug.Log(index);
			//Instantiate(hollowCircle, transform.position, Quaternion.identity);
		
			//Debug.Log(gm.slotAvalable[index]);

            transform.position = GameObject.Find("Played Card Slot").transform.position;
            isPlayed = true;
            gm.slotAvalable[index] = true;
            Invoke("MoveToDiscardPile", 2f);
        }
	}

	void MoveToDiscardPile()
	{
		//Instantiate(effect, transform.position, Quaternion.identity);
		gm.discard.Add(this);
		gameObject.SetActive(false);
		//index = 0;
	}
}
