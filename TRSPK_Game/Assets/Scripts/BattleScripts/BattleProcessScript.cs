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
            Duel(playerField.transform.GetChild(playerUnit).GetChild(0).gameObject, enemyField.transform.GetChild(enemyUnit).GetChild(0).gameObject);
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
        Debug.Log("Entered");
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
    private bool CheckField(GameObject field)
    {
        for(int i = 0; i < field.transform.childCount - 1; i ++)
        {
            if (field.transform.GetChild(i).childCount > 0) return true;
        }
        return false;
    }

    private void Duel(GameObject playerUnit, GameObject enemyUnit)
    {
        //int coin = rand.Next(0, 1);

        while (true)
        {
            /*TakeDamageEvents tde = new TakeDamageEvents();

            enemyUnit.GetComponent<Spawner>().isInFight = true;
            tde.TakeDamage(playerUnit.GetComponent<Spawner>().Attack, enemyUnit);
            enemyUnit.GetComponent<Spawner>().isInFight = false;
            if (enemyUnit.GetComponent<Spawner>().HP < 0) return;

            playerUnit.GetComponent<Spawner>().isInFight = true;
            tde.TakeDamage(enemyUnit.GetComponent<Spawner>().Attack, playerUnit);
            playerUnit.GetComponent<Spawner>().isInFight = false;
            if (playerUnit.GetComponent<Spawner>().HP < 0) return;*/

            if (enemyUnit.GetComponent<Spawner>().Defence > 0)
            {
                enemyUnit.GetComponent<Spawner>().Defence -= playerUnit.GetComponent<Spawner>().Attack;
            }
            else
            {
                enemyUnit.GetComponent<Spawner>().HP -= playerUnit.GetComponent<Spawner>().Attack;
            }
            if (enemyUnit.GetComponent<Spawner>().HP < 0) return;


            if (playerUnit.GetComponent<Spawner>().Defence > 0)
            {
                playerUnit.GetComponent<Spawner>().Defence -= enemyUnit.GetComponent<Spawner>().Attack;
            }
            else
            {
                playerUnit.GetComponent<Spawner>().HP -= enemyUnit.GetComponent<Spawner>().Attack;
            }
            if (playerUnit.GetComponent<Spawner>().HP < 0) return;
        }
        
    }

}

