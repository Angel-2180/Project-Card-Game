using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects : MonoBehaviour
{
    /*Norme fonctions des cartes
    Nom de la fonction (l'effet dans les grandes lignes)
    avec le numero de la carte
    ex une carte qui fait piocher : private void DrawOne1()*/

    public static Unit stat;
    [SerializeField] private GameManager gm;

    public static BattleHUD hud;

    /*Valeurs pour les tours d'apres*/
    public int stayEnergie;

    public static void SearchPlayer()       /* ON NE TOUCHE PAS */
    {
        hud = FindObjectOfType<BattleHUD>();
        stat = FindObjectOfType<Unit>();
        Debug.Log(stat.name);
    }

    private void EnergiePlus1()
    {
        stat.player.energie *= 2;
    }

    private void DrawOne2()
    {
        for (int i = 0; i < stat.player.energie; i++)
        {
            gm.DrawCard();
        }
    }

    private void LowAngry3()
    {
        stat.calm = stat.calm - (stat.calm * 10 / 100);
    }

    private void UpHappy4()
    {
        stat.hapiness = stat.hapiness + (stat.hapiness * 10 / 100);
    }

    private void DrawTwo5()
    {
        gm.DrawCard();
        gm.DrawCard();
    }

    private void DontDiscardHand6()
    {
        gm.discardHandEndTurn = false;
    }

    private void MultipliEnergie7()
    {
        stat.player.energie *= 2;

        foreach (Card card in gm.hand)
        {
            gm.discard.Add(card);
        }
        gm.hand.Clear();
    }

    private void UpInvestissement8()
    {
        stat.investisment = stat.investisment + (stat.investisment * 15 / 100);
    }

    private void HappinessUpInvestDown9()
    {
        stat.hapiness = stat.hapiness + (stat.hapiness / 2);
        stat.investisment = stat.investisment - (stat.investisment / 2);
    }

    private void UpInvestDownPatience10()
    {
        stat.investisment += stat.investisment * 50 / 100;
        stat.patience -= 1;
    }

    private void PlusCharOnDraw11()
    {
        stat.player.charisme += (1 * gm.nbCardBan);
    }

    private void PlusHappinessOnDraw12()
    {
        stat.hapiness += ((stat.hapiness * 5 / 100) * gm.nbCardDraw);
    }

    private void CardDrawSix13()
    {
        for (int i = 0; i < 5; i++)
        {
            gm.DrawCard();
        }
    }

    private void ResetMood14()          /**/
    {
        stat.calm = 0.5f;
        stat.hapiness = 100;
    }

    private void DoublePriceAndNullPatience15()
    {
        int i = Random.Range(1, 3);
        if (i == 1) { stat.price *= 2; }
        else { stat.calm = 0; }
    }

    private void ConservEnergie16()
    {
        stayEnergie = stat.player.energie;
    }

    private void SellPriceUp17()
    {
        stat.price *= 2;
        stat.patience -= 3;
    }

    private void DoublePriceAndNullPatience18()
    {
        stat.price *= 2;
        stat.patience = 0;  /* a confirmer*/
    }

    private void IncrementPatienceAndNullInvest19()
    {
        stat.patience += 2;
        //stat.patience = patienceStart;
    }

    private void DrawCardPlusInvest21()
    {
        stat.investisment += (stat.investisment * 7 / 100) * gm.nbCardDraw;
    }

    private void DoublePrice22()
    {
        stat.price *= 2;
    }

    public void ChooseCardEffects(int numberCardEffect)
    {
        Debug.Log(hud.gameObject);
        switch (numberCardEffect)
        {
            case 1:
                EnergiePlus1();
                hud.setHUD(stat);
                break;

            case 2:
                DrawOne2();
                hud.setHUD(stat);
                break;

            case 3:
                LowAngry3();
                hud.setHUD(stat);
                break;

            case 4:
                UpHappy4();
                hud.setHUD(stat);
                break;

            case 5:
                DrawTwo5();
                hud.setHUD(stat);
                break;

            case 6:
                DontDiscardHand6();
                hud.setHUD(stat);
                break;

            case 7:
                MultipliEnergie7();
                hud.setHUD(stat);
                break;

            case 8:
                UpInvestissement8();
                hud.setHUD(stat);
                break;

            case 9:
                HappinessUpInvestDown9();
                hud.setHUD(stat);
                break;

            case 10:
                UpInvestDownPatience10();
                hud.setHUD(stat);
                break;

            case 11:
                PlusCharOnDraw11();
                hud.setHUD(stat);
                break;

            case 12:
                PlusHappinessOnDraw12();
                hud.setHUD(stat);
                break;

            case 13:
                CardDrawSix13();
                hud.setHUD(stat);
                break;

            case 14:
                ResetMood14();
                hud.setHUD(stat);
                break;

            case 15:
                DoublePriceAndNullPatience15();
                hud.setHUD(stat);
                break;

            case 16:
                ConservEnergie16(); /* théorie ca marche manque les modifications dans le stateMachine*/
                hud.setHUD(stat);
                break;

            case 17:
                SellPriceUp17();
                hud.setHUD(stat);
                break;

            case 18:
                DoublePriceAndNullPatience18();
                hud.setHUD(stat);
                break;

            case 19:
                IncrementPatienceAndNullInvest19();
                hud.setHUD(stat);
                break;

            case 21:
                DrawCardPlusInvest21();
                hud.setHUD(stat);
                break;

            case 22:
                DoublePrice22();
                hud.setHUD(stat);
                break;
        }

    }

    private void Update()
    {
        if (stat != null)
        {
            if (stat.price > stat.investisment)
            {
                stat.price = stat.investisment;
            }
        }

    }
}