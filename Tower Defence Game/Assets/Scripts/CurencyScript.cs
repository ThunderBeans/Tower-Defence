using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CurencyScript : MonoBehaviour
{
    public int Money;
    public int MoneyGain = 10;
    public TextMeshProUGUI MoneyText;
    

    void Update()
    {
        MoneyText.text = Money.ToString();
    }

    public void addMoney()
    {
        Money += MoneyGain;
    }
}
