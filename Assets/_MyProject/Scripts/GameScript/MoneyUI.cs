using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyTxt;
    void Start()
    {
        
    }
    void Update()
    {
        if(PlayerStats.money>=0)
        {
            moneyTxt.text = "$ " + PlayerStats.money.ToString();
        }
    }
}
