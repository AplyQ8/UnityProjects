using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantryman : IUnit
{
    int InfantrymanId = 1;
    string InfantrymanName = "Warrior";
    int InfantrymanHitPoints = 100;
    int InfantrymanAttack = 120;
    int InfantrymanDefence = 1300;
    int InfantrymanCost = 10;


    public int Id { get { return InfantrymanId; } set { InfantrymanId = value; } }
    public string Name { get { return InfantrymanName; } set { InfantrymanName = value; } }
    public int HitPoints { get { return InfantrymanHitPoints; } set { InfantrymanHitPoints = value; } }
    public int Attack { get { return InfantrymanAttack; } set { InfantrymanAttack = value; } }
    public int Defence { get { return InfantrymanDefence; } set { InfantrymanDefence = value; } }
    public int Cost { get { return InfantrymanCost; } set { InfantrymanCost = value; } }
}
