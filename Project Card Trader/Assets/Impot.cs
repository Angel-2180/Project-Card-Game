using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Impot : MonoBehaviour
{
    public Slider slider;
    public TMP_Text[] impots;
    public TMP_Text reste;

    public List<string> phraseBullshit;
    public List<int> argent;

    public float daySpeed = 1;

    private void Awake()
    {
        GetComponentInChildren<CanvasGroup>().alpha = 0;
        GetComponentInChildren<CanvasGroup>().DOFade(1, 2);
        transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f, 0.5f);
        transform.GetChild(0).DOScale(1, 2).SetEase(Ease.OutBack);
        Pay();
    }

    private void Update()
    {
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        slider.value -= daySpeed * Time.deltaTime;
    }

    private void Pay()
    {
        List<string> temp = phraseBullshit;
        for(int i = 0; i < impots.Length; i++)
        {
            argent.Add(Random.Range(50, 100)); //Génère des valeurs random
        }
        foreach (TMP_Text x in impots)
        {
            string tempWord = temp[Random.Range(0, temp.Count)];
            temp.Remove(tempWord);
            x.text = -argent[Random.Range(0, argent.Count)] + " " + tempWord;
        }
        /*foreach(int x in argent)
        {
            StateMachine.current.enemyUnit.player.money -= x; //Soustrait l'argent au joueur
        }
        reste.text = StateMachine.current.enemyUnit.player.money.ToString();*/
    }
}
