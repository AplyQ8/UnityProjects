using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

class BattleProcessScript: MonoBehaviour
{
    public GameObject playerField;
    public GameObject enemyField;
    public GameObject grave;
    System.Random rand = new System.Random();

    public bool isOver = false;

    public void Start()
    {
        playerField = GameObject.Find("Field");
        enemyField = GameObject.Find("Field(Clone)");
        grave = GameObject.Find("DeadUnits");
    }

    public void StartFighting()
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
            Debug.Log("No units on Player field!");
            return;
        }

        while (true)
        {
            int coin = rand.Next(0, 1);
            switch (coin)
            {
                case 1:
                    Duel(playerField.transform.GetChild(playerUnit).GetChild(0).gameObject, enemyField.transform.GetChild(enemyUnit).GetChild(0).gameObject);
                    break;
                case 0:
                    Duel(enemyField.transform.GetChild(enemyUnit).GetChild(0).gameObject, playerField.transform.GetChild(playerUnit).GetChild(0).gameObject);
                    break;
                
            }
            
            //Thread.Sleep(5000);
            if(playerField.transform.GetChild(playerUnit).GetChild(0).GetComponent<Spawner>().HP < 0)
            {
                playerField.transform.GetChild(playerUnit).GetChild(0).gameObject.SetActive(false);
                playerField.transform.GetChild(playerUnit).GetChild(0).SetParent(grave.transform);
                
                playerUnit = CheckPlayerUnits(playerUnit);
                if (playerUnit == -1)
                {
                    Debug.Log("No units on Player field!");
                    return;
                }
                //вызвать для enemy Спец. действия
            }
            if (enemyField.transform.GetChild(enemyUnit).GetChild(0).GetComponent<Spawner>().HP < 0)
            {
                enemyField.transform.GetChild(enemyUnit).GetChild(0).gameObject.SetActive(false);
                enemyField.transform.GetChild(enemyUnit).GetChild(0).SetParent(grave.transform);
                
                enemyUnit = CheckEnemyUnits(enemyUnit);
                if (enemyUnit == -1)
                {
                    Debug.Log("No units on Enemy field!");
                    return;
                }
                //вызвать для Player Спец. действия
            }

        }
    }

    private int CheckPlayerUnits(int playerUnit)
    {
        //Debug.Log("Entered");
        for(int i = playerUnit; i < playerField.transform.childCount; i++)
        {

            if (playerField.transform.GetChild(i).childCount > 0)
            {
                
                return i;
            }
            //Debug.Log("Slot " + playerField.transform.GetChild(i).GetComponent<SlotScript>().cellX + " " + playerField.transform.GetChild(i).GetComponent<SlotScript>().cellY + " is empty");
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
        //int coin = rand.Next(0, 1);

        while (true)
        {
            
            ActionScript actionFirst = enemyUnit.GetComponent<ActionScript>();
            actionFirst?.TakeDamage(playerUnit.GetComponent<Spawner>().Attack);
            if(actionFirst.currentHealth <= 0) return;


            ActionScript actionSecond = playerUnit.GetComponent<ActionScript>();
            actionSecond?.TakeDamage(enemyUnit.GetComponent<Spawner>().Attack);
            if(actionSecond.currentHealth <= 0) return;
        }
        
    }

}

