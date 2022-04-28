using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayCard : MonoBehaviour, IPointerClickHandler
{
    List<string> test = new List<string>();

    public void OnPointerClick(PointerEventData eventData)
    {
        if(FindObjectOfType<DragAndDrop>().selectedObject != null)
        {
            Debug.Log("Clicked");
        }
    }
}
