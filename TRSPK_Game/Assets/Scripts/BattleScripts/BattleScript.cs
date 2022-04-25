using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    public GameObject playerField;
    public GameObject enemyField;
    System.Random rand = new System.Random();
    public int coin;
    public static List<Memento> mementos;
    public int turnBackCount;
    public bool isDead;


    public void Awake()
    {
        mementos = new List<Memento>();
        playerField = GameObject.Find("Field");
        enemyField = GameObject.Find("Field(Clone)");
        coin = rand.Next(0, 2);
        if(coin == 1)
        {
            Debug.Log("First turn is after player!");
        }
        else
        {
            Debug.Log("First turn is after enemy!");
        }
    }

    public void Fight()
    {
        isDead = false;
        int playerUnit = CheckPlayerUnits(0, playerField);
        if (playerUnit == -1)
        {
            Debug.Log("No units on Player field!");
            return;
        }
        int enemyUnit = CheckPlayerUnits(0, enemyField);
        if (enemyUnit == -1)
        {
            Debug.Log("No units on enemy field!");
            return;
        }
        while(!isDead)
        {
            if(coin%2 == 1)
            {
                Duel(playerField.transform.GetChild(playerUnit).GetChild(0).gameObject, enemyField.transform.GetChild(enemyUnit).GetChild(0).gameObject);
                if(enemyField.transform.GetChild(enemyUnit).GetChild(0).GetComponent<Spawner>().HP <= 0)
                {
                    isDead = true;
                    LoopForCallback(playerUnit + 1, playerField.transform.childCount, playerField, enemyField);
                }
            }
            else
            {
                Duel(enemyField.transform.GetChild(enemyUnit).GetChild(0).gameObject, playerField.transform.GetChild(playerUnit).GetChild(0).gameObject);
                if(playerField.transform.GetChild(playerUnit).GetChild(0).GetComponent<Spawner>().HP <= 0)
                {
                    isDead = true;
                    LoopForCallback(enemyUnit + 1, enemyField.transform.childCount, enemyField, playerField);
                }
            }
            coin++;
        }
        
    }
    public void BackTurn()
    {
        
    }




    private int CheckPlayerUnits(int playerUnit, GameObject field)
    {
        for(int i = playerUnit; i < field.transform.childCount; i++)
        {
            if (field.transform.GetChild(i).childCount > 0)
            {
                //Debug.Log(i);
                return i;
            }
        }
        return -1;
    }
    private void Duel(GameObject playerUnit, GameObject enemyUnit)
    {
        
        ActionScript actionFirst = enemyUnit.GetComponent<ActionScript>();
        actionFirst?.TakeDamage(playerUnit.GetComponent<Spawner>().Attack);
    }
    private void CallSpecAction(GameObject unit, GameObject field, GameObject enemyField)
    {
        ActionScript Action = unit.GetComponent<ActionScript>();
        Action?.Ultimate(field, enemyField);
    }
    private void LoopForCallback(int start, int end, GameObject field, GameObject enemyField)
    {
        for(int i = start; i < end; i ++)
        {
            if(field.transform.GetChild(i).childCount > 0)
            {
                CallSpecAction(field.transform.GetChild(i).GetChild(0).gameObject, field, enemyField);
            }
        }
    }
}
