using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class F_Priest : FactoryUnits
{
    public F_Priest()
    {
    }
    public override IUnit Create()
    {
        return new Priest();
    }
}
