using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStat : MonoBehaviour
{
    public static playerStat current;
    public bool isWeekEnd;
    public int charisme;
    public int money = 50;
    public int semaine;
    public int energie;

    private void Awake()
    {
        current = this;
    }
}