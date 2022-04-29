using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class BattleScript : MonoBehaviour
{
    public GameObject playerField;
    public GameObject enemyField;
    System.Random rand = new System.Random();
    public int coin;
    public List<Memento> eMementos;
    public List<Memento> pMementos;
    public int turnBackCount;
    public bool isDead;
    public GameObject pFieldParent;
    public GameObject eFieldParent;


    public void Awake()
    {
        eMementos = new List<Memento>();
        pMementos = new List<Memento>();
        playerField = GameObject.Find("Field");
        playerField.GetComponent<PlayerField>().field = GameObject.Find("Field");
        enemyField = GameObject.Find("Field(Clone)");
        enemyField.GetComponent<PlayerField>().field = GameObject.Find("Field(Clone)");
        coin = rand.Next(0, 2);
        if(coin == 1)
        {
            Debug.Log("First turn is after player!");
        }
        else
        {
            Debug.Log("First turn is after enemy!");
        }
        pFieldParent = GameObject.Find("PlayerSide");
        eFieldParent = GameObject.Find("EnemySide");
        

    }
    
    public void Ready()
    {
        playerField.GetComponent<PlayerField>().field = Instantiate(playerField, playerField.transform.position, playerField.transform.rotation, playerField.transform.parent);
        playerField.GetComponent<PlayerField>().field.SetActive(false);
        playerField.GetComponent<PlayerField>().SaveTo(pMementos);
        enemyField.GetComponent<PlayerField>().field = Instantiate(enemyField, enemyField.transform.position, enemyField.transform.rotation, enemyField.transform.parent);
        enemyField.GetComponent<PlayerField>().field.SetActive(false);
        enemyField.GetComponent<PlayerField>().SaveTo(eMementos);
    }

    public void Fight()
    {
        
        if(turnBackCount < GameObject.Find("TurnCounter").GetComponent<TurnCountScript>().turnCount)
        {
            pMementos[turnBackCount]._field.SetActive(false);
            eMementos[turnBackCount]._field.SetActive(false);
            // playerField = GameObject.Find("Field");
            // enemyField = GameObject.Find("Field(Clone");
            playerField.SetActive(true);
            enemyField.SetActive(true);
            pFieldParent.GetComponent<ScrollRect>().content = playerField.GetComponent<RectTransform>();
            eFieldParent.GetComponent<ScrollRect>().content = enemyField.GetComponent<RectTransform>();
        }
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
        GameObject.Find("TurnCounter").GetComponent<TurnCountScript>().turnCount++;
        turnBackCount = GameObject.Find("TurnCounter").GetComponent<TurnCountScript>().turnCount;
        
        
        
    }

    public void SaveToLists()
    {
        var tempObj = Instantiate(playerField, playerField.transform.position, playerField.transform.rotation, playerField.transform.parent);
        playerField.GetComponent<PlayerField>().field = tempObj;
        playerField.GetComponent<PlayerField>().SaveTo(pMementos);
        playerField.GetComponent<PlayerField>().field.SetActive(false);
        
        var tempObj1 = Instantiate(enemyField, enemyField.transform.position, enemyField.transform.rotation, enemyField.transform.parent);
        enemyField.GetComponent<PlayerField>().field = tempObj1;
        enemyField.GetComponent<PlayerField>().SaveTo(eMementos);
        enemyField.GetComponent<PlayerField>().field.SetActive(false);
    }
    public void Undo()
    {
        pMementos[turnBackCount]._field.SetActive(false);
        eMementos[turnBackCount]._field.SetActive(false);
        playerField.SetActive(false);
        enemyField.SetActive(false);
        turnBackCount -= 1;
        pMementos[turnBackCount]._field.SetActive(true);
        eMementos[turnBackCount]._field.SetActive(true);
        pFieldParent.GetComponent<ScrollRect>().content = pMementos[turnBackCount]._field.GetComponent<RectTransform>();
        eFieldParent.GetComponent<ScrollRect>().content = eMementos[turnBackCount]._field.GetComponent<RectTransform>();
        // playerField = pMementos[turnBackCount]._field;
        // enemyField = eMementos[turnBackCount]._field;
    }
    public void Redo()
    {
        pMementos[turnBackCount]._field.SetActive(false);
        eMementos[turnBackCount]._field.SetActive(false);
        playerField.SetActive(false);
        enemyField.SetActive(false);
        turnBackCount += 1;
        pMementos[turnBackCount]._field.SetActive(true);
        eMementos[turnBackCount]._field.SetActive(true);
        pFieldParent.GetComponent<ScrollRect>().content = pMementos[turnBackCount]._field.GetComponent<RectTransform>();
        eFieldParent.GetComponent<ScrollRect>().content = eMementos[turnBackCount]._field.GetComponent<RectTransform>();
        // playerField = pMementos[turnBackCount]._field;
        // enemyField = eMementos[turnBackCount]._field;
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
