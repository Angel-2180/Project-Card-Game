using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Le dialogue trigger est le script qui va demarrer le dialogue
public class DialogueTrigger : MonoBehaviour
{
    //On fait reference au component dialogue
    [SerializeField]
    public DialogueData dataDialogue;

    public bool _trigger;

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
                int rdm = Random.Range(0, 3);
                switch (rdm)
                {
                    case 0:
                        TriggerAngryDialogue();
                        break;
                    case 1:
                        TriggerHappyDialogue();
                        break;
                    case 2:
                        TriggerNeutralDialogue();
                        break;
                    case 3:
                        TriggerIntroDialogue();
                        break;
                }
            }
        }
    }
}
