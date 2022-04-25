using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCanvasScript : MonoBehaviour
{
    public GameObject canvas;

    public void SaveTo(IList<Memento> collection)
    {
        collection.Add(new Memento(this.canvas));
        Debug.Log("Saved! Count: "+collection.Count);
        
    }
    public void RestoreState(Memento state)
    {
        //this.canvas = state.Canvas;
        //this.canvas.SetActive(true);
        canvas.GetComponent<Canvas>().enabled= false;
        state.canvas.GetComponent<Canvas>().enabled = true;
    }
}
