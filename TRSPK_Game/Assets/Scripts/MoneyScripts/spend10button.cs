using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class spend10button : MonoBehaviour
{
    public Button spending10;
    public void SpendMoney()
    {
        SpendMoneyEvent sme = new SpendMoneyEvent();
        sme.OnSpendMoney(10);
    }
}
