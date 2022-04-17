using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class F_Archer : FactoryUnits
{
    public F_Archer()
    {
    }
    public override IUnit Create()
    {
        return new Archer();
    }
}

