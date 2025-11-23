using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneySpend : MonoBehaviour
{
    [SerializeField] private MonthlyMoney monthlyMoney;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    public TMP_InputField input;
    public GameObject EventMachine;
    private float numValue;
    public bool EditEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        input.gameObject.SetActive(false);
    }

    public void GetInput(string text)
    {
        float InputNum = 0;
        if(float.TryParse(input.text, out numValue))
        {
            if (monthlyMoney.GetMonthlyMoney() - numValue < 0)
            {
                textMeshProUGUI.gameObject.SetActive(true);
                return;
            }
            InputNum = numValue;
        }
        else
        {
            InputNum = 0;
        }
        textMeshProUGUI.gameObject.SetActive(false);
        monthlyMoney.ChangeMonthlyMoney(InputNum);


        //call set mood
        NewBehaviourScript mood = EventMachine.GetComponent<NewBehaviourScript>();
        mood.SetMood(numValue);

        //disappear input field
        DeleteInputField();
    }

    public void CallInputField()
    {
        input.gameObject.SetActive(true);
    }

    public void DeleteInputField()
    {
        EditEnd = true;
        input.gameObject.SetActive(false);
    }
}
