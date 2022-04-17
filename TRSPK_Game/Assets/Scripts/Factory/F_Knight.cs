using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class F_Knight : FactoryUnits
{
    public F_Knight()
    {
    }
    public override IUnit Create()
    {
        return new Knight();
    }
}
