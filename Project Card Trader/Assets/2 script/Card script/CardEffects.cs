using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects : MonoBehaviour
{
    /*Norme fonctions des cartes
    Nom de la fonction (l'effet dans les grandes lignes) 
    avec le numero de la carte
    ex une carte qui fait piocher : private void DrawOne1()*/

    /* TEMPORAIRE MODIFIER POUR FAIRE DES TEST A DELET APRES*/
    private int oui = 7;
    /*---------------------------------------------------*/

    private static Unit stat;
    [SerializeField] GameManager gm;
    

    public static void SearchPlayer()       /* ON NE TOUCHE PAS */
    {
        stat = FindObjectOfType<Unit>();
    }

    private void EnergiePlus1()
    {
        //Debug.Log(stat.player.energie);
        stat.player.energie *= 2;
        //Debug.Log(stat.player.energie);
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
        //Debug.Log(stat.calm);
        stat.calm = stat.calm - (stat.calm * 10 / 100);
        //Debug.Log(stat.calm);
    }

    private void UpHappy4()
    {
        //Debug.Log(stat.hapiness);
        stat.hapiness = stat.hapiness + (stat.hapiness * 10 / 100);
        //Debug.Log(stat.hapiness);
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
        Debug.Log(stat.player.energie);
        stat.player.energie *= 2;

        foreach(Card card in gm.hand)
        {
            gm.discard.Add(card);
        }
        gm.hand.Clear();

        Debug.Log(stat.player.energie);
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

                break;

            case 9:

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

        }

    }
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.U)) /*permet de tester les fonction une par une avec une input*/
        {
            ChooseCardEffects(oui);
        }
    }
}
