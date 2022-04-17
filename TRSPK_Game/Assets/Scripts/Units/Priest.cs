using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Priest : IUnit
{
    int HealerId = 4;
    string HealerName = "Priest";
    int HealerHitPoints = 35;
    int HealerAttack = 20;
    int HealerDefence = 15;
    int HealerCost = 30;
    public int Id { get { return HealerId; } set { HealerId = value; } }
    public string Name { get { return HealerName; } set { HealerName = value; } }
    public int HitPoints { get { return HealerHitPoints; } set { HealerHitPoints = value; } }
    public int Attack { get { return HealerAttack; } set { HealerAttack = value; } }
    public int Defence { get { return HealerDefence; } set { HealerDefence = value; } }
    public int Cost { get { return HealerCost; } set { HealerCost = value; } }

    
}
