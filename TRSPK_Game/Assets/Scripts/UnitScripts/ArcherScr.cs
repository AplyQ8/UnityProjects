using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections.Generic;

public class ArcherScr:  MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Attack;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Defence;
    public TextMeshProUGUI Cost;
    public TextMeshProUGUI Description;

    public HealthBarScript healthBar;
    public DefenceBarScript defBar;

    Archer arch = new Archer();
    ActionScript Action;

    int ArcherId ;
    string ArcherName ;
    int ArcherHitPoints ;
    int ArcherAttack ;
    int ArcherDefence ;
    int ArcherCost ;
    string ArcherDescription;

    private void Awake()
    {
        Action = GetComponent<ActionScript>();
        
        ArcherId = arch.Id;
        ArcherName = arch.Name;
        ArcherHitPoints = arch.HitPoints;
        ArcherAttack = arch.Attack;
        ArcherDefence = arch.Defence;
        ArcherCost = arch.Cost;
        GetComponent<Spawner>().Cost = ArcherCost;
        GetComponent<Spawner>().Attack = ArcherAttack;
        GetComponent<Spawner>().HP = ArcherHitPoints;
        GetComponent<Spawner>().Defence = ArcherDefence;
        
        Action.currentDefence = ArcherDefence;
        Action.currentHealth = ArcherHitPoints;

        ArcherDescription = "Shoots another random unit with some chance";

        healthBar.SetMaxHealth(ArcherHitPoints);
        defBar.SetMaxHealth(ArcherDefence);
    }
    private void Update()
    {
        Name.text = ArcherName.ToString();
        Attack.text = ArcherAttack.ToString();
        Health.text = ArcherHitPoints.ToString();
        Defence.text = ArcherDefence.ToString();
        Cost.text = ArcherCost.ToString();
        Description.text = ArcherDescription.ToString();
        ArcherDefence = GetComponent<Spawner>().Defence;
        ArcherHitPoints = GetComponent<Spawner>().HP;
        healthBar.SetHealth(ArcherHitPoints);
        defBar.SetHealth(ArcherDefence);
    }


    F_Archer fabric = new F_Archer();

    
    public void OnEndDrag(PointerEventData eventData)
    {
        //ArrayUnits units = new ArrayUnits();
        
        CardScr card = GetComponent<CardScr>();
        if (card.isDropped)
        {
            SlotScript slot = GetComponentInParent<SlotScript>();
            GameObject.Find("Array").GetComponent<ArrayUnits>().units[slot.cellX, slot.cellY] = fabric.Create();
            //units.units[slot.cellX, slot.cellY] = fabric.Create();
            SpendMoneyEvent sme = new SpendMoneyEvent();
            sme.OnSpendMoney(ArcherCost);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        LocalCostScript lc = GameObject.Find("LocalCost").GetComponent<LocalCostScript>();
        lc.cost = ArcherCost;
    }
    public void TakeDamage(int damage)
    {
        if (ArcherDefence > 0)
        {
            //ArcherDefence = Action.currentDefence;
            ArcherDefence -= damage;
            GetComponent<Spawner>().Defence = ArcherDefence;
            
        }
        else
        {
            //ArcherHitPoints = Action.currentHealth;
            ArcherHitPoints -= damage;
            Action.currentHealth = ArcherHitPoints;
            GetComponent<Spawner>().HP = ArcherHitPoints;
        }
    }

    private void OnEnable() {
        Action.Damage += TakeDamage;
        Action.Killed += Kill;
        Action.SpecAction += Ultimate;
        
    }
    private void OnDisable() {
        Action.Damage -= TakeDamage;
        Action.Killed -= Kill;
        Action.SpecAction -= Ultimate;
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    public void Ultimate(GameObject field, GameObject enemyField)
    {
        System.Random rand = new System.Random();
        int coin = rand.Next(0, 101);
        if(coin > 50)
        {
            List<GameObject> units = new List<GameObject>();
            for(int i = 0; i < enemyField.transform.childCount; i++)
            {
                if(enemyField.transform.GetChild(i).transform.childCount > 0)
                {
                    units.Add(enemyField.transform.GetChild(i).GetChild(0).gameObject);
                }
            }
            GameObject unit = units[rand.Next(0, units.Count)];
            ActionScript enemyAction = unit.GetComponent<ActionScript>();
            enemyAction?.TakeDamage(ArcherAttack);
            Debug.Log($"Archers action was activated and dealed {ArcherAttack} damage a {unit.GetComponent<Spawner>().unitName}");

            units.Clear();
        }
    }
}

