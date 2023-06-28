using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CurencyScript : MonoBehaviour
{
    public int Money = 1000;
    public int MoneyGain = 10;
    public TextMeshProUGUI MoneyText;
    

    void Update()
    {
        MoneyText.text = "Money:" +Money.ToString();
        if (Input.GetKeyDown(KeyCode.K))
        {
            addMoney();
        }
    }

    public void addMoney()
    {
        Money += MoneyGain;
    }
}
