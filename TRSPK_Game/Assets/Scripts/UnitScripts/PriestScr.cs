using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class PriestScr : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Attack;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Defence;
    public TextMeshProUGUI Cost;
    public TextMeshProUGUI Description;

    public HealthBarScript healthBar;
    public DefenceBarScript defBar;

    Priest priest = new Priest();
    F_Priest fabric = new F_Priest();
    ActionScript Action;

    int PriestId;
    string PriestName;
    int PriestHitPoints;
    int PriestAttack;
    int PriestDefence;
    int PriestCost;
    string PriestDescription;

    private void Awake()
    {
        Action = GetComponent<ActionScript>();
        PriestId = priest.Id;
        PriestName = priest.Name;
        PriestHitPoints = priest.HitPoints;
        PriestAttack = priest.Attack;
        PriestDefence = priest.Defence;
        PriestCost = priest.Cost;
        GetComponent<Spawner>().Cost = PriestCost;
        GetComponent<Spawner>().Attack = PriestAttack;
        GetComponent<Spawner>().HP = PriestHitPoints;
        GetComponent<Spawner>().Defence = PriestDefence;
        Action.currentDefence = PriestDefence;
        Action.currentHealth = PriestHitPoints;

        PriestDescription = "Heal nearby units with some chance";

        healthBar.SetMaxHealth(PriestHitPoints);
        defBar.SetMaxHealth(PriestDefence);
    }

    private void Update()
    {
        Name.text = PriestName.ToString();
        Attack.text = PriestAttack.ToString();
        Health.text = PriestHitPoints.ToString();
        Defence.text = PriestDefence.ToString();
        Cost.text = PriestCost.ToString();
        Description.text = PriestDescription.ToString();
        PriestDefence = GetComponent<Spawner>().Defence;
        PriestHitPoints = GetComponent<Spawner>().HP;
        
        healthBar.SetHealth(PriestHitPoints);
        defBar.SetHealth(PriestDefence);
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
            sme.OnSpendMoney(PriestCost);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        LocalCostScript lc = GameObject.Find("LocalCost").GetComponent<LocalCostScript>();
        lc.cost = PriestCost;
    }
    public void TakeDamage(int damage)
    {
        if (PriestDefence > 0)
        {
            //PriestDefence = Action.currentDefence;
            PriestDefence -= damage;
            GetComponent<Spawner>().Defence = PriestDefence;
        }
        else
        {
            //PriestHitPoints = Action.currentHealth;
            PriestHitPoints -= damage;
            Action.currentHealth = PriestHitPoints;
            GetComponent<Spawner>().HP = PriestHitPoints;
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
    public void Ultimate(GameObject field, GameObject enemyField)
    {
        
    }
}
