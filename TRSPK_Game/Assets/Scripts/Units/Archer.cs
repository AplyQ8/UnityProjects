using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : IUnit
{
    int ArcherId = 2;
    string ArcherName = "Archer";
    int ArcherHitPoints = 100;
    int ArcherAttack = 120;
    int ArcherDefence = 1300;
    int ArcherCost = 15;
    public int Id { get { return ArcherId; } set { ArcherId = value; } }
    public string Name { get { return ArcherName; } set { ArcherName = value; } }
    public int HitPoints { get { return ArcherHitPoints; } set { ArcherHitPoints = value; } }
    public int Attack { get { return ArcherAttack; } set { ArcherAttack = value; } }
    public int Defence { get { return ArcherDefence; } set { ArcherDefence = value; } }
    public int Cost { get { return ArcherCost; } set { ArcherCost = value; } }
}
