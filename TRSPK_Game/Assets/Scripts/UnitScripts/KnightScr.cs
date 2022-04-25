using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class KnightScr : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Attack;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Defence;
    public TextMeshProUGUI Cost;
    public TextMeshProUGUI Description;

    public HealthBarScript healthBar;
    public DefenceBarScript defBar;

    Knight knight = new Knight();
    F_Knight fabric = new F_Knight();
    ActionScript Action;

    int KnightId;
    string KnightName;
    int KnightHitPoints;
    int KnightAttack;
    int KnightDefence;
    int KnightCost;
    string KnightDescription;

    private void Awake()
    {
        Action = GetComponent<ActionScript>();
        KnightId = knight.Id;
        KnightName = knight.Name;
        KnightHitPoints = knight.HitPoints;
        KnightAttack = knight.Attack;
        KnightDefence = knight.Defence;
        KnightCost = knight.Cost;
        GetComponent<Spawner>().Cost = KnightCost;
        GetComponent<Spawner>().Attack = KnightAttack;
        GetComponent<Spawner>().HP = KnightHitPoints;
        GetComponent<Spawner>().Defence = KnightDefence;
        
        Action.currentDefence = KnightDefence;
        Action.currentHealth = KnightHitPoints;

        KnightDescription = "Can be buffed by nearby warriors";

        healthBar.SetMaxHealth(KnightHitPoints);
        defBar.SetMaxHealth(KnightDefence);
    }

    private void Update()
    {
        Name.text = KnightName.ToString();
        Attack.text = KnightAttack.ToString();
        Health.text = KnightHitPoints.ToString();
        Defence.text = KnightDefence.ToString();
        Cost.text = KnightCost.ToString();
        Description.text = KnightDescription.ToString();
        KnightDefence = GetComponent<Spawner>().Defence;
        KnightHitPoints = GetComponent<Spawner>().HP;
        healthBar.SetHealth(KnightHitPoints);
        defBar.SetHealth(KnightDefence);

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
            sme.OnSpendMoney(KnightCost);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        LocalCostScript lc = GameObject.Find("LocalCost").GetComponent<LocalCostScript>();
        lc.cost = KnightCost;
    }
    public void TakeDamage(int damage)
    {
        if (KnightDefence > 0)
        {
            //KnightDefence = Action.currentDefence;
            KnightDefence -= damage;
            GetComponent<Spawner>().Defence = KnightDefence;
        }
        else
        {
            //KnightHitPoints = Action.currentHealth;
            KnightHitPoints -= damage;
            Action.currentHealth = KnightHitPoints;
            GetComponent<Spawner>().HP = KnightHitPoints;
        }
    }
    private void OnEnable() {
        Action.Damage += TakeDamage;
        Action.Killed += Kill;
    }
    private void OnDisable() {
        Action.Damage -= TakeDamage;
        Action.Killed -= Kill;
    }
    public void Kill()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
