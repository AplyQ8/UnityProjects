using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : IUnit
{
    int ArcherId = 2;
    string ArcherName = "Archer";
    int ArcherHitPoints = 25;
    int ArcherAttack = 30;
    int ArcherDefence = 15;
    int ArcherCost = 20;
    public int Id { get { return ArcherId; } set { ArcherId = value; } }
    public string Name { get { return ArcherName; } set { ArcherName = value; } }
    public int HitPoints { get { return ArcherHitPoints; } set { ArcherHitPoints = value; } }
    public int Attack { get { return ArcherAttack; } set { ArcherAttack = value; } }
    public int Defence { get { return ArcherDefence; } set { ArcherDefence = value; } }
    public int Cost { get { return ArcherCost; } set { ArcherCost = value; } }
}
