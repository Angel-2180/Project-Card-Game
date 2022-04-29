using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text WealthText;
    public Text investmentText;
    public Text priceText;
    public Text patienceText;
    public Text customerName;
    public Text monetyText;
    public Text nbrObj;
    public Text nbrDedck;
    public Text nbrdiscard;

    public Slider moodSlider;
    public static GameManager gm;
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        WealthText.text = "";
        investmentText.text = "";
        patienceText.text = "";
        customerName.text = "";
        priceText.text = "";
        nbrObj.text = sellObjList.current.objList.Count.ToString();
        nbrDedck.text = "";
   nbrdiscard.text =  "";
    moodSlider.maxValue = 10;
        moodSlider.value = 0;
    }

    public void setHUD(Unit unit)
    {
        WealthText.text = unit.wealth.ToString();
        investmentText.text = unit.investisment.ToString();
        patienceText.text = unit.patience.ToString();
        customerName.text = unit.name;
        priceText.text = unit.price.ToString();
        monetyText.text = unit.player.money.ToString();
        nbrObj.text = unit.listOBJ.objList.Count.ToString();
        nbrDedck.text = gm.deck.Count.ToString();
        nbrdiscard.text = gm.discard.Count.ToString();
        
        moodSlider.maxValue = unit.maxHapiness * unit.maxCalm;
        moodSlider.value = unit.hapiness * unit.calm;
    }

    public void resetHUD()
    {
        WealthText.text = "";
        investmentText.text = "";
        patienceText.text = "";
        customerName.text = "";
        priceText.text = "";
        nbrObj.text = sellObjList.current.objList.Count.ToString();
        nbrDedck.text = "";
        nbrdiscard.text = "";
        moodSlider.maxValue = 10;
        moodSlider.value = 0;
    }

    public void updatePatience(int patience)
    {
        patienceText.text = patience.ToString();
    }

    public void updatePrice(int price)
    {
        priceText.text = price.ToString();
    }

    public void setMoney(int money)
    {
        monetyText.text = money.ToString();
    }

    public void setInvestement(int investment)
    {
        investmentText.text = investment.ToString();
    }

    public void setPatience(int patience)
    {
        patienceText.text = patience.ToString();
    }

    public void setMood(uint hapiness, uint calm)
    {
        moodSlider.value = hapiness * calm;
    }
}