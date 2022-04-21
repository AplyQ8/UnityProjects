using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneScript : MonoBehaviour
{
    private void Start()
    {
        GameObject newField = Instantiate(GameObject.Find("Field"));
        
        //newField.SetActive(false);
        newField.transform.SetParent(GameObject.Find("Canvas").transform);
        newField.transform.position = new Vector2(1000, 1000);
    }
}
