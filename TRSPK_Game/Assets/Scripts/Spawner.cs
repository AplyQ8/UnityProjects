using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    public string unitName;
    

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    public void Spawn()
    {
        CardScr card = GetComponent<CardScr>();
        objectPooler.SpawnFromPool(unitName, card.defaultPos, Quaternion.identity, card.parent);
    }
}
