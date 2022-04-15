using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Warrior : FactoryUnits
{
    public F_Warrior()
    {
    }
    public override IUnit Create()
    {
        return new Infantryman();
    }
}
