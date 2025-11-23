using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonthlyMoney : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private float monthlyMoney;

    public void SetMonthlyMoney(float money)
    {
        monthlyMoney = money;
        text.text = '$' + monthlyMoney.ToString();
    }

    public void ChangeMonthlyMoney(float money)
    {
        monthlyMoney -= money;
        text.text = '$' + monthlyMoney.ToString();
    }

    public float GetMonthlyMoney()
    {
        return monthlyMoney;
    }
}
