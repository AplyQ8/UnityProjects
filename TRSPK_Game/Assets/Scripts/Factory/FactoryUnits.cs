using System;
using UnityEngine;
abstract public class FactoryUnits : MonoBehaviour
{
    public FactoryUnits()
    {
    }
    abstract public IUnit Create();
}
