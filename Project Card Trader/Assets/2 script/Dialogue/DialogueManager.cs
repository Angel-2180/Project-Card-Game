using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    #region Variables
    #region UI_Components
    public TMP_Text dialogueTextNameComponent;
    public TMP_Text dialogueTextDialogueComponent;
    public Transform dialogueBox;
    #endregion

    private float moveDistance = 400;
    private float moveSppeed = 0.5f;

    public static DialogueManager current;

    public bool isPlayingDialogue;

    //public Animator animator;
    private Queue<DialogueData.Data> sentences;

    [SerializeField]
    private float dialogueSpeed;
    #endregion

    private void Awake()
    {
        if (current == null)
        {
            current = this;
            DontDestroyOnLoad(current);
        }
        else
        {
            Destroy(gameObject);
        }

        //animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        sentences = new Queue<DialogueData.Data>();
    }

    //We stop the time and set isDialogue of the player on true
    //Set the name
    public void StartDialogue(DialogueData.Data[] dialogue, string name)
    {
        //On demarre l'animation d'entree de la boite de dialogue
        dialogueBox.DOMove(dialogueBox.position + Vector3.up * moveDistance, moveSppeed).SetEase(Ease.InOutSine);
        isPlayingDialogue = true;

        //dialogueBox.eulerAngles = new Vector3(0, 0, -5);
        //dialogueBox.DORotate(dialogueBox.eulerAngles + new Vector3(0, 0, 10), 0.05f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);

        //On vide la pile de sentence
        sentences.Clear();

        //On defini le nom
        dialogueTextNameComponent.text = name + " : ";

        //On va enfiler sentences avec la liste des sentneces de dialogue
        foreach (DialogueData.Data sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }

        //On va afficher la prochaine sentence  
        DisplayNextSentence();
    }

    public void DisplayNextSentence()//Affiche la prochaine sentence
    {
        //On veifie si il reste des sentences a affciher
        if (sentences.Count == 0)
        {
            //On arrete l'animation du texte
            StopAllCoroutines();
            //On met fin au dialogue
            EndDialogue();
            return;
        }
        //On vide la liste de sentence
        DialogueData.Data sentence = sentences.Dequeue();

        //On arrete toutes les couroutines
        StopAllCoroutines();
        //On demarre l'animation du texte
        StartCoroutine(TypeSentence(sentence.sentence));
    }

    IEnumerator TypeSentence(string sentence)//Animation du texte
    {
        //On vide le texte du dialogue
        dialogueTextDialogueComponent.text = "";
        //On ajoute les lettres de chaque sentences 1 par 1
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueTextDialogueComponent.text += letter;
            if(sentence.IndexOf(letter) % 2 == 0)
                SendMessage("PlayAudio", SendMessageOptions.RequireReceiver);
            //On attend 1 frame
            yield return WaitForRealSeconds(dialogueSpeed);
        }
        WoobleLetter();
    }

    IEnumerator WaitForRealSeconds(float seconds)
    {
        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - startTime < seconds)
        {
            yield return null;
        }
    }

    public void EndDialogue()//On met fin au dialogue 
    {
        FindObjectOfType<DialogueTrigger>()._trigger = false;
        isPlayingDialogue = false;
        //On enleve la boite de dialogue de l'ecran
        dialogueBox.DOMove(dialogueBox.position - Vector3.up * moveDistance, moveSppeed).SetEase(Ease.InOutSine);
        //On arrete toutes les couroutines
        StopAllCoroutines();
        sentences.Clear();
    }
    
    public void WoobleLetter()
    {
        dialogueTextDialogueComponent.textInfo.characterInfo[5].color = new Color32(1, 0, 0, 1);
    }
}
