using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TumbleWeed : IUnit
{

    int TumbleWeedId = 6;
    string TumbleWeedName = "Tumbleweed";
    int TumbleWeedHitPoints = 100;
    int TumbleWeedAttack = 0;
    int TumbleWeedDefence = 100;
    int TumbleWeedCost = 70;
    public int Id { get { return TumbleWeedId; } set { TumbleWeedId = value; } }
    public string Name { get { return TumbleWeedName; } set { TumbleWeedName = value; } }
    public int HitPoints { get { return TumbleWeedHitPoints; } set { TumbleWeedHitPoints = value; } }
    public int Attack { get { return TumbleWeedAttack; } set { TumbleWeedAttack = value; } }
    public int Defence { get { return TumbleWeedDefence; } set { TumbleWeedDefence = value; } }
    public int Cost { get { return TumbleWeedCost; } set { TumbleWeedCost = value; } }
    
}
