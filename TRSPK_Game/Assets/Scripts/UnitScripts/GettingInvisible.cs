using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingInvisible : MonoBehaviour
{
   
    
    // Update is called once per frame
    void Update()
    {
        CardScr card = GetComponentInParent<CardScr>();
        if(card.isDropped)
        {
            GetComponent<CanvasGroup>().alpha = .0f;
        }
    }
}
