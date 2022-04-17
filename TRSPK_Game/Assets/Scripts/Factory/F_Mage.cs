using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class F_Mage : FactoryUnits
{
    public F_Mage()
    {
    }
    public override IUnit Create()
    {
        return new Mage();
    }
}
