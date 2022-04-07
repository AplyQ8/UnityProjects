using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour
{
    private int AmountOfMoney = 200;
    public Text AmountOfMoneyText;
    private void Start()
    {
        SpendMoneyEvent.SME += SpendMoney;
    }
    public void SpendMoney(object sender, SpendMoneyEventArgs e)
    {
        if (AmountOfMoney - e.Spent < 0)
        {
            return;
        }
        AmountOfMoney -= e.Spent;
        AmountOfMoneyText.text = $"{AmountOfMoney}";
    }
}

