using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zzz_cardeffect : MonoBehaviour
{
    private static Unit stat;
    [SerializeField] GameManager gm;

    private void PlusCharOnDraw11()
    {
        //foreach(intcarddraw)
        //{
        stat.player.charisme += 1;
        //}
    }


    private void PlusHappinessOnDraw12()
    {
        //foreach(intcarddraw)
        //{
        stat.hapiness *= 5/100;
        //}
    }

    private void CardDrawSix13()
    {
        gm.DrawCard(); gm.DrawCard(); gm.DrawCard(); gm.DrawCard(); gm.DrawCard(); gm.DrawCard();
    }


    private void ResetMood14()
    {
        // effet pas sur parcequ'on a pas les stats de départ
        stat.calm = 100;
        stat.hapiness = 100;
    }
    private void DoublePriceAndNullPatience15()
    {
        int i = Random.Range(1,3); 
        if(i == 1) { stat.price *= 2; }
        else { stat.calm = 0; }
    }

    private void DoublePriceAndNullPatience18()
    {
        stat.price *= 2;
        stat.patience = 0;
    }

    private void IncrementPatienceAndNullInvest19()
    {
        stat.patience += 2;
        //stat.patience = patienceStart;
    }

    private void DoublePriceAndNullPatience20()
    {
        stat.price *= 2;
        stat.patience = 0;
    }

    private void DrawCardPlusInvest21()
    {
       //foreach(intcarddraw)
        //{
            stat.investisment += stat.investisment * (7 / 100);
        //}
    }

    private void DoublePrice22()
    {
        // cost
        // stat.player.energie -= 6;
        stat.price *= 2;
    }

}
