using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    public GameObject playerField;
    public GameObject enemyField;
    //public GameObject grave;
    System.Random rand = new System.Random();
    public int coin;

    public void Awake()
    {
        playerField = GameObject.Find("Field");
        enemyField = GameObject.Find("Field(Clone)");
        //grave = GameObject.Find("DeadUnits");
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
        int playerUnit = CheckPlayerUnits(0);
        if (playerUnit == -1)
        {
            Debug.Log("No units on Player field!");
            return;
        }
        int enemyUnit = CheckEnemyUnits(enemyField.transform.childCount - 1);
        if (enemyUnit == -1)
        {
            Debug.Log("No units on enemy field!");
            return;
        }

        if(coin%2 == 1)
        {
            Duel(playerField.transform.GetChild(playerUnit).GetChild(0).gameObject, enemyField.transform.GetChild(enemyUnit).GetChild(0).gameObject);
            if(enemyField.transform.GetChild(enemyUnit).GetChild(0).GetComponent<Spawner>().HP <= 0)
            {
                LoopForCallback(playerUnit + 1, playerField.transform.childCount, playerField, enemyField);
            }
        }
        else
        {
            Duel(enemyField.transform.GetChild(enemyUnit).GetChild(0).gameObject, playerField.transform.GetChild(playerUnit).GetChild(0).gameObject);
            if(playerField.transform.GetChild(playerUnit).GetChild(0).GetComponent<Spawner>().HP <= 0)
            {
                LoopForCallback(0, enemyUnit, enemyField, playerField);
            }
        }
        coin ++;
    }




    private int CheckPlayerUnits(int playerUnit)
    {
        for(int i = playerUnit; i < playerField.transform.childCount; i++)
        {
            if (playerField.transform.GetChild(i).childCount > 0)
            {
                return i;
            }
        }
        return -1;
    }
    private int CheckEnemyUnits(int playerUnit)
    {
        for (int i = playerUnit; i >= 0 ; i--)
        {
            if (enemyField.transform.GetChild(i).childCount > 0) return i;
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
