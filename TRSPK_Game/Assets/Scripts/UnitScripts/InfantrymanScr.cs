using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class InfantrymanScr : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    Infantryman inf = new Infantryman();
    int InfantrymanId;
    string InfantrymanName;
    int InfantrymanHitPoints;
    int InfantrymanAttack;
    int InfantrymanDefence;
    int InfantrymanCost;
        
    private void Start()
    {
        InfantrymanId = inf.Id;
        InfantrymanName = inf.Name;
        InfantrymanHitPoints = inf.HitPoints;
        InfantrymanAttack = inf.Attack;
        InfantrymanDefence = inf.Defence;
        InfantrymanCost = inf.Cost;
        GetComponent<Spawner>().Cost = InfantrymanCost;
    }


    F_Warrior fabric = new F_Warrior();

    

    public void OnEndDrag(PointerEventData eventData)
    {

        CardScr card = GetComponent<CardScr>();
        //ArrayUnits units = new ArrayUnits();
        //Debug.Log("Called From UnitScript");

        if (card.isDropped)
        {
            SlotScript slot = GetComponentInParent<SlotScript>();
            GameObject.Find("Array").GetComponent<ArrayUnits>().units[slot.cellX, slot.cellY] = fabric.Create();
            //units.units[slot.cellX, slot.cellY] = fabric.Create();

            SpendMoneyEvent sme = new SpendMoneyEvent();
            sme.OnSpendMoney(InfantrymanCost);
            
            
        }
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        LocalCostScript lc = GameObject.Find("LocalCost").GetComponent<LocalCostScript>();
        lc.cost = InfantrymanCost;
    }
}
