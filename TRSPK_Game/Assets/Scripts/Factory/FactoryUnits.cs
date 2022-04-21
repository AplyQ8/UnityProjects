using System;
using UnityEngine;
abstract public class FactoryUnits
{
    public FactoryUnits()
    {
    }
    abstract public IUnit Create();
}
