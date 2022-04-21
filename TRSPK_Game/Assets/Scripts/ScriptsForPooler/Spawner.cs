using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ObjectPooler objectPooler;
    public string unitName;
    public int Cost;
    public int Attack;
    public int HP;
    public int Defence;
    public bool isInFight = false;
    
    //public int health;
    

    public void Awake()
    {
        objectPooler = GameObject.Find("ObjectPooler").GetComponent<ObjectPooler>();
        
    }

    public void Spawn()
    {
        CardScr card = GetComponent<CardScr>();
        objectPooler.SpawnFromPool(unitName, card.defaultPos, Quaternion.identity, card.parent);
    }
    /*public void Delete()
    {
        CardScr card = GetComponent<CardScr>();
    }*/
}
