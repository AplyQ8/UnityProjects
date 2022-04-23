using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionScript : MonoBehaviour
{
    public event Action<int> Damage = delegate { };
    public event Action Killed = delegate { };
    public event Action<GameObject, GameObject> SpecAction = delegate { };

    public int currentHealth;
    public int currentDefence;

    public void TakeDamage(int damage)
    {
        
        if(currentDefence > 0)
        {
            currentDefence -= damage;
        }
        else
        {
            currentHealth -= damage;
        }
        Damage.Invoke(damage);
        
        if(currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Killed.Invoke();
    }
    public void Ultimate(GameObject field, GameObject enemyField)
    {
        SpecAction.Invoke(field, enemyField);
    }

}
