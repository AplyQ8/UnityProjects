using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    //public Gradient gradient;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        //gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    private void Update()
    {
        if (GetComponentInParent<CardScr>().isDropped)
            GetComponent<CanvasGroup>().alpha = 1f;
    }
}
