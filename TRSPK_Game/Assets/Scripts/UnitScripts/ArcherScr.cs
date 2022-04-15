using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArcherScr:  MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    Archer arch = new Archer();
    int ArcherId ;
    string ArcherName ;
    int ArcherHitPoints ;
    int ArcherAttack ;
    int ArcherDefence ;
    int ArcherCost ;

    private void Start()
    {
        ArcherId = arch.Id;
        ArcherName = arch.Name;
        ArcherHitPoints = arch.HitPoints;
        ArcherAttack = arch.Attack;
        ArcherDefence = arch.Defence;
        ArcherCost = arch.Cost;
        GetComponent<Spawner>().Cost = ArcherCost;
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
}

