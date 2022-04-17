using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mage : IUnit
{
    int MageId = 3;
    string MageName = "Mage";
    int MageHitPoints = 55;
    int MageAttack = 50;
    int MageDefence = 55;
    int MageCost = 60;
    public int Id { get { return MageId; } set { MageId = value; } }
    public string Name { get { return MageName; } set { MageName = value; } }
    public int HitPoints { get { return MageHitPoints; } set { MageHitPoints = value; } }
    public int Attack { get { return MageAttack; } set { MageAttack = value; } }
    public int Defence { get { return MageDefence; } set { MageDefence = value; } }
    public int Cost { get { return MageCost; } set { MageCost = value; } }

    
}
