using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Knight : IUnit
{
    int KnightId = 5;
    string KnightName = "Knight";
    int KnightHitPoints = 70;
    int KnightAttack = 55;
    int KnightDefence = 70;
    int KnightCost = 60;
    public int Id { get { return KnightId; } set { KnightId = value; } }
    public string Name { get { return KnightName; } set { KnightName = value; } }
    public int HitPoints { get { return KnightHitPoints; } set { KnightHitPoints = value; } }
    public int Attack { get { return KnightAttack; } set { KnightAttack = value; } }
    public int Defence { get { return KnightDefence; } set { KnightDefence = value; } }
    public int Cost { get { return KnightCost; } set { KnightCost = value; } }

}
