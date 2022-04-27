using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{ Start, PlayerTurn, EnemyTurn, Wait, Sell }

public class StateMachine : MonoBehaviour
{
    public GameState state;

    public GameObject enemyPrefabs;
    public Unit enemyUnit;
    public Transform enemyTransform;

    public BattleHUD enemyHUD;

    public void Start()
    {
        state = GameState.Start;
        StartCoroutine(setupBattle());
    }

    private IEnumerator setupBattle()
    {
        yield return new WaitForSeconds(2f);

        GameObject enemyGO = Instantiate(enemyPrefabs, enemyTransform);
        enemyUnit = enemyGO.GetComponent<Unit>();

        enemyHUD.setHUD(enemyUnit);

        state = GameState.PlayerTurn;
        playerTurn();
    }

    private void playerTurn()
    {
        //do something basically wait here
    }

    public void OnEndTurn()
    {
        if (state != GameState.PlayerTurn)
        {
            return;
        }

        state = GameState.EnemyTurn;
        StartCoroutine(enemyTurn());
    }

    public void OnDeal()
    {
        if (state != GameState.PlayerTurn)
        {
            return;
        }

        state = GameState.Sell;
        StartCoroutine(sell());
    }

    private IEnumerator sell()
    {
        enemyUnit.player.money += enemyUnit.objPrice.price;
        yield return new WaitForSeconds(2f);
    }

    private IEnumerator enemyTurn()
    {
        int rng = Random.Range(1, 7);
        switch (rng)
        {
            case 1:

                enemyUnit.objPrice.price -= (int)System.Math.Round(Mathf.Lerp(1, 100, Random.Range(0, 1)));
                break;

            case 2:
                //atk2 loose 1 patience per card played
                break;

            case 3:
                //next turn atk +5%
                break;

            case 4:
                //add 1 energy to (hopefully) all card
                break;

            case 5:
                enemyUnit.player.charisme -= 1 + (enemyUnit.mefiance * 2) + enemyUnit.mefiance / 2;
                break;
        }

        yield return new WaitForSeconds(2f);
        state = GameState.PlayerTurn;
        playerTurn();
    }
}