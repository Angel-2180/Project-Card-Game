using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum wealthValue
{ rich, moderate, poor }

public class Unit : MonoBehaviour
{
    public string name;
    public wealthValue wealth;
    public int money; //max Money
    public int investisment; // theorique max input in the product

    [HideInInspector] public int maxHapiness;

    public int hapiness;

    [HideInInspector] public float maxCalm;

    public float calm;

    [HideInInspector]
    public int maxPatience = 15;

    public int mefiance;

    public int patience;

    [HideInInspector]
    public sellObjList listOBJ;

    public int index;

    public int price = 600;

    public playerStat player;

    private void Awake()
    {
        mefiance = Random.Range(0, 1);
        int rng = Random.Range(1, 3);
        switch (rng)
        {
            case 1:
                wealth = wealthValue.poor;
                money = Random.Range(50, 150);
                investisment = Random.Range(money / 2, money * 90 / 100);
                break;

            case 2:
                wealth = wealthValue.moderate;
                money = Random.Range(200, 450);
                investisment = Random.Range(money * 40 / 100, money * 80 / 100);
                break;

            case 3:
                wealth = wealthValue.rich;
                money = Random.Range(500, 1000);
                investisment = Random.Range(money / 4, money * 60 / 100);
                break;
        }
        listOBJ = sellObjList.current;

        maxHapiness = Random.Range(0, 200);
        maxCalm = Random.Range(0f, 1f);
        hapiness = Random.Range(0, maxHapiness);
        calm = Random.Range(0, maxCalm);
        patience = UnityEngine.Random.Range(11, maxPatience + 1);

        if (listOBJ.objList.Count > 0)
        {
            price = (int)Math.Round(listOBJ.objList[UnityEngine.Random.Range(0, listOBJ.objList.Count)].price * hapiness * calm);
            index = UnityEngine.Random.Range(0, listOBJ.objList.Count);
        }
        else
        {
            price = 0;
            index = 0;
        }

        player = playerStat.current;
    }

    public void changePrice(int change)
    {
        if (investisment < money)
        {
            investisment = change;
        }
    }

    public void addHapiness(int newhapiness)
    {
        if (hapiness < 200 || hapiness > 0)
        {
            hapiness += newhapiness;
        }
    }

    public void looseHapiness(int newhapiness)
    {
        if (hapiness < 200 || hapiness > 0)
        {
            hapiness -= newhapiness;
        }
    }

    public void addCalm(int newcalm)
    {
        if (calm < 200 || calm > 0)
        {
            calm += newcalm;
        }
    }

    public void looseCalm(int newcalm)
    {
        if (calm < 200 || calm > 0)
        {
            calm -= newcalm;
        }
    }
}