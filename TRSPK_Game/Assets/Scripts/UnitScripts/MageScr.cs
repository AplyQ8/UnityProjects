using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class MageScr : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Attack;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Defence;
    public TextMeshProUGUI Cost;
    public TextMeshProUGUI Description;

    public HealthBarScript healthBar;
    public DefenceBarScript defBar;

    Mage mage = new Mage();
    F_Mage fabric = new F_Mage();

    int MageId;
    string MageName;
    int MageHitPoints;
    int MageAttack;
    int MageDefence;
    int MageCost;
    string MageDescription;

    private void Awake()
    {
        TakeDamageEvents.TDE += TakeDamage;
        MageId = mage.Id;
        MageName = mage.Name;
        MageHitPoints = mage.HitPoints;
        MageAttack = mage.Attack;
        MageDefence = mage.Defence;
        MageCost = mage.Cost;
        GetComponent<Spawner>().Cost = MageCost;
        GetComponent<Spawner>().Attack = MageAttack;
        GetComponent<Spawner>().HP = MageHitPoints;
        GetComponent<Spawner>().Defence = MageDefence;

        MageDescription = "Clone nearby units with some chance";

        healthBar.SetMaxHealth(MageHitPoints);
        defBar.SetMaxHealth(MageDefence);
    }

    private void Update()
    {
        Name.text = MageName.ToString();
        Attack.text = MageAttack.ToString();
        Health.text = MageHitPoints.ToString();
        Defence.text = MageDefence.ToString();
        Cost.text = MageCost.ToString();
        Description.text = MageDescription.ToString();

        MageHitPoints = GetComponent<Spawner>().HP;
        MageDefence = GetComponent<Spawner>().Defence;

        healthBar.SetHealth(MageHitPoints);
        defBar.SetHealth(MageDefence);
    }

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
            sme.OnSpendMoney(MageCost);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        LocalCostScript lc = GameObject.Find("LocalCost").GetComponent<LocalCostScript>();
        lc.cost = MageCost;
    }
    public void TakeDamage(object sender, TakeDamageEventsArgs e)
    {
        if (GetComponent<Spawner>().isInFight)
        {
            if (MageDefence > 0)
            {
                MageDefence -= e.Attack;
            }
            else
            {
                MageHitPoints -= e.Attack;
            }
        }
    }
}
