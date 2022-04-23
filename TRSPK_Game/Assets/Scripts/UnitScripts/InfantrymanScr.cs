using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class InfantrymanScr : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Attack;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Defence;
    public TextMeshProUGUI Cost;
    public TextMeshProUGUI Description;

    public HealthBarScript healthBar;
    public DefenceBarScript defBar;

    Infantryman inf = new Infantryman();
    ActionScript Action;


    int InfantrymanId;
    string InfantrymanName;
    int InfantrymanHitPoints;
    int InfantrymanAttack;
    int InfantrymanDefence;
    int InfantrymanCost;
    string InfantrymanDescription;
        
    private void Awake()
    {
        Action = GetComponent<ActionScript>();
        InfantrymanId = inf.Id;
        InfantrymanName = inf.Name;
        InfantrymanHitPoints = inf.HitPoints;
        InfantrymanAttack = inf.Attack;
        InfantrymanDefence = inf.Defence;
        InfantrymanCost = inf.Cost;
        GetComponent<Spawner>().Cost = InfantrymanCost;
        GetComponent<Spawner>().Attack = InfantrymanAttack;
        GetComponent<Spawner>().HP = InfantrymanHitPoints;
        Action.currentDefence = InfantrymanDefence;
        Action.currentHealth = InfantrymanHitPoints;

        InfantrymanDescription = "Buffes nearby Knights with some chance";

        healthBar.SetMaxHealth(InfantrymanHitPoints);
        defBar.SetMaxHealth(InfantrymanDefence);


    }
    private void Update()
    {
        Name.text = InfantrymanName.ToString();
        Attack.text = InfantrymanAttack.ToString();
        Health.text = InfantrymanHitPoints.ToString();
        Defence.text = InfantrymanDefence.ToString();
        Cost.text = InfantrymanCost.ToString();
        Description.text = InfantrymanDescription.ToString();

        
        
        

        healthBar.SetHealth(InfantrymanHitPoints);
        defBar.SetHealth(InfantrymanDefence);
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
    public void TakeDamage(int damage)
    {
        if (InfantrymanDefence > 0)
        {
            InfantrymanDefence = Action.currentDefence;
            GetComponent<Spawner>().Defence = InfantrymanDefence;
        }
        else
        {
            InfantrymanHitPoints = Action.currentHealth;
            GetComponent<Spawner>().HP = InfantrymanHitPoints;
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
