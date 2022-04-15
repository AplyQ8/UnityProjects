using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    public string unitName;
    public int Cost;
    public int index;
    

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
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
