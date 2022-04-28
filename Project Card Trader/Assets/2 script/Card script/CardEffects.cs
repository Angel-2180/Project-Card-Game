using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects : MonoBehaviour
{
    /*Norme fonctions des cartes
    Nom de la fonction (l'effet dans les grandes lignes) 
    avec le numero de la carte
    ex une carte qui fait piocher : private void DrawOne1()*/


    private static Unit stat;
    [SerializeField] GameManager gm;

    /*Valeurs pour les tours d'apres*/
    public int stayEnergie;

    public static void SearchPlayer()       /* ON NE TOUCHE PAS */
    {
        stat = FindObjectOfType<Unit>();
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

    private void GainEnergieDiscard6()
    {

    }
    private void MultipliEnergie7()
    {
        stat.player.energie *= 2;

        foreach(Card card in gm.hand)
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

    private void ConservEnergie16()
    {
        stayEnergie = stat.player.energie;
    }

    private void SellPriceUp17()
    {
        stat.price *= 2;
        stat.patience -= 3;     
    }

    private void ChooseCardEffects(int numberCardEffect)
    {
        switch (numberCardEffect)
        {
            case 1:
                EnergiePlus1();
                break;

            case 2 :
                DrawOne2();
                break;

            case 3:
                LowAngry3();
                break;

            case 4:
                UpHappy4();
                break;
            case 5:
                DrawTwo5();
                break;

            case 6:
                GainEnergieDiscard6();
                break;

            case 7:
                MultipliEnergie7();
                break;

            case 8:
                UpInvestissement8();
                break;

            case 9:
                HappinessUpInvestDown9();
                break;

            case 10:

                break;

            case 11:

                break;

            case 12:

                break;

            case 13:

                break;

            case 14:

                break;
            case 15:

                break;
            case 16:
                ConservEnergie16(); /* théorie ca marche manque les modifications dans le stateMachine*/
                break;
            case 17:
                SellPriceUp17();
                break;
            case 18:

                break;
            case 19:

                break;
            case 20:

                break;
            case 21:

                break;
            case 22:

                break;
            case 23:

                break;
            case 24:

                break;


        }

    }
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.U)) /*permet de tester les fonction une par une avec une input*/
        {
            ChooseCardEffects(9);
        }
    }
}
