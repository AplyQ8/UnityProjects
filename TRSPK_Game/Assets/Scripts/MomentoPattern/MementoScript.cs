using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memento
{
    public GameObject playerField;
    public GameObject enemyField;

    public Memento(GameObject _pField, GameObject _eField)
    {
        playerField = _pField;
        enemyField = _eField;
    }

    public GameObject Player
    {
        get => this.playerField;
    }
    public GameObject Enemy
    {
        get => this.enemyField;
    }
    
}
