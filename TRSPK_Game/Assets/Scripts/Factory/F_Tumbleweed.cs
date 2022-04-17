using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class F_Tumbleweed : FactoryUnits
{
    public F_Tumbleweed()
    {
    }
    public override IUnit Create()
    {
        return new TumbleWeed();
    }
}
