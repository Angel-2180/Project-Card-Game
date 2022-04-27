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

    public uint hapiness;

    [HideInInspector] public int maxCalm;

    public uint calm;

    [HideInInspector]
    public static int maxPatience = 15;

    public int mefiance;

    public int patience;

    public List<sellObject> objList;

    [HideInInspector]
    public sellObject objPrice;

    public playerStat player;

    private void Start()
    {
        maxHapiness = Random.Range(0, 200);
        maxCalm = Random.Range(0, 200);
        patience = UnityEngine.Random.Range(11, maxPatience + 1);
        objPrice = objList[UnityEngine.Random.Range(0, objList.Count)];
    }

    public void changePrice(int change)
    {
        if (investisment < money)
        {
            investisment = change;
        }
    }

    public void addHapiness(uint newhapiness)
    {
        if (hapiness < 200 || hapiness > 0)
        {
            hapiness += newhapiness;
        }
    }

    public void looseHapiness(uint newhapiness)
    {
        if (hapiness < 200 || hapiness > 0)
        {
            hapiness -= newhapiness;
        }
    }

    public void addCalm(uint newcalm)
    {
        if (calm < 200 || calm > 0)
        {
            calm += newcalm;
        }
    }

    public void looseCalm(uint newcalm)
    {
        if (calm < 200 || calm > 0)
        {
            calm -= newcalm;
        }
    }
}