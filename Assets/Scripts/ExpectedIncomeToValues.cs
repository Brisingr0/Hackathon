using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpectedIncomeToValues : MonoBehaviour
{
    [SerializeField] private MoneyValuesSO moneyValuesSO;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private MonthlyMoney monthlyMoney;
    [SerializeField] private GameObject DialogueController;
    [SerializeField] private GameObject EventController;

    public void SetMoneyValues(float yearly)
    {
        moneyValuesSO.baseIncomeYearly = yearly;
        moneyValuesSO.baseIncomeMonthly = yearly / 12;
        monthlyMoney.SetMonthlyMoney(yearly / 12);
        moneyValuesSO.NessieNecessitiesAmount = (float) (moneyValuesSO.baseIncomeMonthly * 0.5);
        moneyValuesSO.RitaRetirementAmount = (float) (moneyValuesSO.baseIncomeMonthly * 0.2);
        moneyValuesSO.MishaLoanAmount = (float) (moneyValuesSO.baseIncomeMonthly * 0.2);
        moneyValuesSO.EllieEntertainmentAmount = (float)(moneyValuesSO.baseIncomeMonthly * 0.1);
        inputField.gameObject.SetActive(false);
        textMeshProUGUI.gameObject.SetActive(false);
        ChangeCharacterSprite.Instance.SetSpriteActive();
        DialogueController.SetActive(true);
        EventController.SetActive(true);
    }

    public void GetInputFieldValue()
    {
        string tmp = inputField.text;
        int yearly = int.Parse(tmp);
        SetMoneyValues(yearly);
    }
}
