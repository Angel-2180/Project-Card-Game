using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


//Le dialogue trigger est le script qui va demarrer le dialogue
public class DialogueTrigger : MonoBehaviour
{
    //On fait reference au component dialogue
    [SerializeField]
    public DialogueData dataDialogue;

    public bool _trigger;

    public string targetTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_trigger && collision.CompareTag(targetTag))
        {
            TriggerAngryDialogue();
            Destroy(gameObject);
        }
    }

    private void ObjectClick()
    {

        TriggerAngryDialogue();
    }

    public void TriggerIntroDialogue()
    {
        TriggerDialogue(dataDialogue.introduction, dataDialogue.name);
        _trigger = true;
    }

    public void TriggerAngryDialogue()
    {
        TriggerDialogue(dataDialogue.angry, dataDialogue.name);
        _trigger = true;
    }

    public void TriggerHappyDialogue()
    {
        TriggerDialogue(dataDialogue.happy, dataDialogue.name);
        _trigger = true;
    }

    public void TriggerNeutralDialogue()
    {
        TriggerDialogue(dataDialogue.neutral, dataDialogue.name);
        _trigger = true;
    }

    //On démarre le dialogue et si l'objet possède le component CameraTrigger on change les valeurs de la camera
    public void TriggerDialogue(DialogueData.Data[] sentences, string name)
    {
        DialogueManager.current.StartDialogue(sentences, name);
        _trigger = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_trigger)
            {
                DialogueManager.current.DisplayNextSentence();
            }
            else
            {
                TriggerAngryDialogue();
            }
        }
    }
}
