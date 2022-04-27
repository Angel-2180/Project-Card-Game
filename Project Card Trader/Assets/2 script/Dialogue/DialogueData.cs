using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "NewDialogue")]
public class DialogueData : ScriptableObject
{
    //Nom afficher
    public string name;

    //Liste des structure de dialogue
    public Data[] introduction;
    public Data[] neutral;
    public Data[] happy;
    public Data[] angry;

    [System.Serializable]
    public struct Data
    {
        //Zone de texte / texte afficher
        [TextArea(3, 10)]
        public string sentence;

        public string message;
    }
}
