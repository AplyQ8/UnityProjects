using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantryman : IUnit
{
    int InfantrymanId = 1;
    string InfantrymanName = "Warrior";
    int InfantrymanHitPoints = 20;
    int InfantrymanAttack = 10;
    int InfantrymanDefence = 25;
    int InfantrymanCost = 15;


    public int Id { get { return InfantrymanId; } set { InfantrymanId = value; } }
    public string Name { get { return InfantrymanName; } set { InfantrymanName = value; } }
    public int HitPoints { get { return InfantrymanHitPoints; } set { InfantrymanHitPoints = value; } }
    public int Attack { get { return InfantrymanAttack; } set { InfantrymanAttack = value; } }
    public int Defence { get { return InfantrymanDefence; } set { InfantrymanDefence = value; } }
    public int Cost { get { return InfantrymanCost; } set { InfantrymanCost = value; } }
}
