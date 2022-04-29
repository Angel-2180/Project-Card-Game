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
    public float maxValue = 100;
    public bool isTimeUp;
    public int days;
    private int impotMin;
    private int impotMax;
    public int impotFinal;

    public static Impot current;

    private void Awake()
    {
        current = this;
        slider.maxValue = maxValue;
        slider.value = maxValue;
        //GetComponentInChildren<CanvasGroup>().alpha = 0;
        //GetComponentInChildren<CanvasGroup>().DOFade(1, 2);
        //transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //transform.GetChild(0).DOScale(1, 2).SetEase(Ease.OutBack);
    }

    private void Update()
    {
        if (slider.value == 0)
        {
            isTimeUp = true;
        }
        else
        {
            UpdateSlider();
        }
    }

    private void UpdateSlider()
    {
        slider.value -= daySpeed * Time.deltaTime;
    }

    public void Pay()
    {
        impotMin = days;
        impotMax = days + 50;
        impotFinal = Random.Range(impotMin, impotMax);
    }
}