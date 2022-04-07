using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class spend15button : MonoBehaviour
{
    public Button spending;
    public void SpendMoney()
    {
        SpendMoneyEvent sme = new SpendMoneyEvent();
        sme.OnSpendMoney(15);
    }
}
