using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class TumbleweedScr : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Attack;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Defence;
    public TextMeshProUGUI Cost;
    public TextMeshProUGUI Description;

    public HealthBarScript healthBar;
    public DefenceBarScript defBar;

    TumbleWeed tw = new TumbleWeed();
    F_Tumbleweed fabric = new F_Tumbleweed();

    int TumbleWeedId;
    string TumbleWeedName;
    int TumbleWeedHitPoints;
    int TumbleWeedAttack;
    int TumbleWeedDefence;
    int TumbleWeedCost;
    string TumbleWeedDescription;

    private void Awake()
    {
        TakeDamageEvents.TDE += TakeDamage;
        TumbleWeedId = tw.Id;
        TumbleWeedName = tw.Name;
        TumbleWeedHitPoints = tw.HitPoints;
        TumbleWeedAttack = tw.Attack;
        TumbleWeedDefence = tw.Defence;
        TumbleWeedCost = tw.Cost;
        GetComponent<Spawner>().Cost = TumbleWeedCost;
        GetComponent<Spawner>().Attack = TumbleWeedAttack;
        GetComponent<Spawner>().HP = TumbleWeedHitPoints;
        GetComponent<Spawner>().Defence = TumbleWeedDefence;

        TumbleWeedDescription = "Heavy unit with no attack";

        healthBar.SetMaxHealth(TumbleWeedHitPoints);
        defBar.SetMaxHealth(TumbleWeedDefence);
    }

    private void Update()
    {
        Name.text = TumbleWeedName.ToString();
        Attack.text = TumbleWeedAttack.ToString();
        Health.text = TumbleWeedHitPoints.ToString();
        Defence.text = TumbleWeedDefence.ToString();
        Cost.text = TumbleWeedCost.ToString();
        Description.text = TumbleWeedDescription.ToString();

        TumbleWeedHitPoints = GetComponent<Spawner>().HP;
        TumbleWeedDefence = GetComponent<Spawner>().Defence;

        healthBar.SetHealth(TumbleWeedHitPoints);
        defBar.SetHealth(TumbleWeedDefence);

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
            sme.OnSpendMoney(TumbleWeedCost);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        LocalCostScript lc = GameObject.Find("LocalCost").GetComponent<LocalCostScript>();
        lc.cost = TumbleWeedCost;
    }
    public void TakeDamage(object sender, TakeDamageEventsArgs e)
    {
        if (GetComponent<Spawner>().isInFight)
        {
            if (TumbleWeedDefence > 0)
            {
                TumbleWeedDefence -= e.Attack;
            }
            else
            {
                TumbleWeedHitPoints -= e.Attack;
            }
        }
    }
}
