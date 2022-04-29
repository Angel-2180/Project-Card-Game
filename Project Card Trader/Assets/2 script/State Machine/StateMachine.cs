using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum GameState
{ Start, PlayerTurn, EnemyTurn, Wait, Sell }

public class StateMachine : MonoBehaviour
{
    public static StateMachine current;
    public GameState state;

    public List<GameObject> enemyPrefabs;
    public List<GameObject> cpyEnemyPrefabs;
    public Unit enemyUnit;
    public Transform enemyTransform;

    public BattleHUD enemyHUD;
    private GameObject enemyGO;
    private Impot impot;
    private sellObjList list;

    private float buffAttack;
    private int index;

    private void Awake()
    {
        foreach (GameObject enemy in enemyPrefabs)
        {
            cpyEnemyPrefabs.Add(enemy);
        }
        list = sellObjList.current;
        current = this;
    }

    public void Start()
    {
        impot = Impot.current;
        state = GameState.Start;
        StartCoroutine(setupBattle());
    }

    private IEnumerator setupBattle()
    {
        if (enemyPrefabs.Count > 0)
        {
            index = Random.Range(0, enemyPrefabs.Count - 1);
            Debug.Log("index " + index);
            yield return new WaitForSeconds(2f);

            enemyGO = Instantiate(enemyPrefabs[index], enemyTransform);
            enemyUnit = enemyGO.GetComponent<Unit>();
            CardEffects.SearchPlayer();

            enemyHUD.setHUD(enemyUnit);
        }

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

        enemyUnit.patience -= 1;
        enemyHUD.updatePatience(enemyUnit.patience);
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
        if (impot.isTimeUp)
        {
            impot.slider.value = impot.maxValue;

            StartCoroutine(setupDay());
            StartCoroutine(sell());
            impot.isTimeUp = false;
        }
        else
        {
            StartCoroutine(sell());
        }
    }

    private IEnumerator sell()
    {
        Debug.Log(list.objList.Count);
        if (state != GameState.Sell)
        {
            yield break;
        }

        if (list.objList.Count > 0 && !impot.isTimeUp)
        {
            Debug.Log("HERE");
            list.objList.RemoveAt(enemyUnit.index);
            enemyUnit.player.money += enemyUnit.price;

            enemyHUD.setMoney(enemyUnit.player.money);
            Destroy(enemyGO);
        }
        if (list.objList.Count == 0)
        {
            Debug.Log("break");
        }
        else
        {
            StartCoroutine(setupBattle());
        }

        enemyHUD.resetHUD();
        if (enemyPrefabs.Count > 0)
        {
            enemyPrefabs.RemoveAt(index);
        }
        yield return new WaitForSeconds(2f);
        state = GameState.PlayerTurn;
        playerTurn();
    }

    private IEnumerator setupDay()
    {
        impot.days += 1;
        impot.Pay();
        Debug.Log(impot.impotFinal);
        enemyPrefabs.Clear();
        enemyUnit.listOBJ.objList.Clear();
        foreach (GameObject enemy in cpyEnemyPrefabs)
        {
            enemyPrefabs.Add(enemy);
        }
        foreach (sellObject obj in list.cpyobjList)
        {
            list.objList.Add(obj);
        }
        yield return new WaitForSeconds(2f);
        enemyUnit.player.money -= impot.impotFinal;
        enemyHUD.updatePrice(enemyUnit.price);
        state = GameState.PlayerTurn;
        playerTurn();
    }

    private void AttackPatern(int rng)
    {
        switch (rng)
        {
            case 1:
                if (enemyUnit.price > 0)
                {
                    enemyUnit.price -= (int)System.Math.Round((10) + (0.5 * (5)) * enemyUnit.mefiance + buffAttack);
                }
                else
                {
                    enemyUnit.price = 0;
                }
                enemyHUD.updatePrice(enemyUnit.price);
                break;

            case 2:
                //atk2 loose 1 patience per card played
                break;

            case 3:
                buffAttack = enemyUnit.price * (5 / 100);
                break;

            case 4:
                //add 1 energy to (hopefully) all card
                break;

            case 5:
                enemyUnit.player.charisme -= 1 + (enemyUnit.mefiance / 2);
                break;
        }
    }

    private IEnumerator enemyTurn()
    {
        if (state != GameState.EnemyTurn)
        {
            yield break;
        }
        if (enemyUnit.patience <= 0 || enemyUnit.mood <= 0)
        {
            Destroy(enemyGO);
            enemyPrefabs.RemoveAt(index);
            state = GameState.PlayerTurn;
            playerTurn();
            StartCoroutine(setupBattle());
            yield break;
        }
        Debug.Log("ENEMY TURN");
        int rng = Random.Range(1, 5);
        AttackPatern(rng);
        Debug.Log(rng);

        yield return new WaitForSeconds(2f);
        state = GameState.PlayerTurn;
        playerTurn();
    }
}