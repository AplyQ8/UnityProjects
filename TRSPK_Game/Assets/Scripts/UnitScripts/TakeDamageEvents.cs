using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TakeDamageEventsArgs : EventArgs
{
    public int Attack;
}
public class TakeDamageEvents
{
    public static event EventHandler<TakeDamageEventsArgs> TDE;

    public void TakeDamage(int Attack, GameObject gameObject)
    {
        TakeDamageEventsArgs d = new TakeDamageEventsArgs();
        d.Attack = Attack;
        TDE(this, d);
    }
}