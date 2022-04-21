using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

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
    int ArcherId ;
    string ArcherName ;
    int ArcherHitPoints ;
    int ArcherAttack ;
    int ArcherDefence ;
    int ArcherCost ;
    string ArcherDescription;

    private void Awake()
    {
        TakeDamageEvents.TDE += TakeDamage;
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

        ArcherHitPoints = GetComponent<Spawner>().HP;
        ArcherDefence = GetComponent<Spawner>().Defence;

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
    public void TakeDamage(object sender, TakeDamageEventsArgs e)
    {
        if (GetComponent<Spawner>().isInFight)
        {
            if (ArcherDefence > 0)
            {
                ArcherDefence -= e.Attack;
            }
            else
            {
                ArcherHitPoints -= e.Attack;
            }
        }
    }
}

