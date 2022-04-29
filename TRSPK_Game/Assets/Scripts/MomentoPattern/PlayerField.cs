using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerField : MonoBehaviour
{
    
    public GameObject field;

    public void SaveTo(IList<Memento> collection)
    {
        collection.Add(new Memento(field));
        Debug.Log("Saved! Count: " + collection.Count);

    }
    public void RestoreState(Memento state, GameObject FIELD) // передавать текущие field'ы, присваивать State field'ам parent& position переданных
    {
        //this.canvas = state.Canvas;
        //this.canvas.SetActive(true);
        // field = state._field;
        // field.SetActive(true);
        // Debug.Log("Field was replaced");
        FIELD = state._field;

    }
    
}
