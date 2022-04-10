using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IDropHandler
{
    public int cellX;
    public int cellY;
    public bool isBusy = false;
    //public int localCost;
    

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("Dropped in cell ["+cellX+"]" + "["+cellY+"]");
        isBusy = true;
        //Debug.Log("Called from slot script");

       
    }
}
