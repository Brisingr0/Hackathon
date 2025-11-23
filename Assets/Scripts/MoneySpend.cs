using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneySpend : MonoBehaviour
{
    public TMP_InputField input;
    public GameObject EventMachine;
    private int numValue;
    public bool EditEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        input.gameObject.SetActive(false);
    }

    public int GetInput(string text)
    {
        Debug.Log(text);
        int InputNum = 0;
        if(int.TryParse(input.text, out numValue))
        {
            InputNum = numValue;
        }
        else
        {
            InputNum = 0;
        }

        //disappear input field
        DeleteInputField();

        //call set mood
        NewBehaviourScript mood = EventMachine.GetComponent<NewBehaviourScript>();
        mood.SetMood(numValue);

        return InputNum;
    }

    public void CallInputField()
    {
        input.gameObject.SetActive(true);
    }

    public void DeleteInputField()
    {
        input.gameObject.SetActive(false);
        EditEnd = true;
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
