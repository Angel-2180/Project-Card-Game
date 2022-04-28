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
    public Slider moodSlider;

    public void setHUD(Unit unit)
    {
        WealthText.text = unit.wealth.ToString();
        investmentText.text = unit.investisment.ToString();
        patienceText.text = unit.patience.ToString();
        customerName.text = unit.name;
        priceText.text = unit.price.ToString();
        monetyText.text = "Money: " + unit.player.money.ToString();
        moodSlider.maxValue = unit.maxHapiness * unit.maxCalm;
        moodSlider.value = unit.hapiness * unit.calm;
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
        monetyText.text = "Money: " + money.ToString();
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