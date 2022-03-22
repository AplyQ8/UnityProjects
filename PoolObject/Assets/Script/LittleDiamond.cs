using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleDiamond : MonoBehaviour, IPooledObject
{
    public float upForce = 1f;
    public float sideForce = .1f;

    public void OnObjectSpawn()
    {
        float xForce = Random.Range(-sideForce, sideForce); //задаем рандомное направление полета алмаза
        float yForce = Random.Range(upForce / 2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        Vector3 force = new Vector3(xForce, yForce, zForce);

        GetComponent<Rigidbody>().velocity = force;  //передаем эта направление rigidBody
    }
}
