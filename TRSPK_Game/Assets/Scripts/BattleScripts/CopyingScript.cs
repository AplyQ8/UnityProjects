using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyingScript : MonoBehaviour
{
    public string pField;
    public GameObject ActiveSide;
    private void Start()
    {
        GameObject playerField = GameObject.Find(pField);
        //GameObject playerSide = GameObject.Find("PlayerSide");
        if(playerField)
        {
            playerField.GetComponent<Transform>().transform.SetParent(ActiveSide.GetComponent<Transform>());
            playerField.GetComponent<Transform>().transform.position = ActiveSide.GetComponent<Transform>().transform.position;
            ActiveSide.GetComponent<ScrollRect>().content = playerField.GetComponent<RectTransform>();

        }
        else
        {
            Debug.LogWarning("Object have not found");
        }
    }
}
