using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Impot : MonoBehaviour
{
    public Slider slider;
    public TMP_Text impots;

    public List<string> phraseBullshit;

    public float daySpeed = 1;
    public float maxValue = 100;
    public bool isTimeUp;
    public int days;
    private int impotMin;
    private int impotMax;
    public int impotFinal;

    public static Impot current;

    public GameObject canvas;

    private void Awake()
    {
        current = this;
        slider.maxValue = maxValue;
        slider.value = maxValue;
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

        if (Input.GetKeyDown(KeyCode.F))
        {
            Pay();
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

        impots.text = -impotFinal + " " + phraseBullshit[Random.Range(0, phraseBullshit.Count)];

        canvas.GetComponentInChildren<CanvasGroup>().alpha = 0;
        canvas.GetComponentInChildren<CanvasGroup>().DOFade(1, 2);
        canvas.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f, 0.5f);
        canvas.transform.GetChild(0).DOScale(1, 2).SetEase(Ease.OutBack).OnComplete(() => 
        {
            canvas.GetComponentInChildren<CanvasGroup>().DOFade(0, 2);
        });
    }
}