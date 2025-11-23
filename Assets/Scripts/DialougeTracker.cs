using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTracker : MonoBehaviour
{
    public static DialougeTracker instance;

    enum NPC
    {
        Nessie,
        Misha,
        Rita,
        Ellie,
    }

    [SerializeField] private TextAsset[] NessieDialogue;
    [SerializeField] private TextAsset[] MishaDialogue;
    [SerializeField] private TextAsset[] RitaDialogue;
    [SerializeField] private TextAsset[] EllieDialogue;
    [SerializeField] private MonthlyMoney monthlyMoney;
    [SerializeField] private MoneyValuesSO moneyValuesSO;
    private NPC currentNPC;
    private int month;

    private void Start()
    {
        instance = this;
        currentNPC = NPC.Nessie;
        month = 0;
    }

    public String GetDialouge()
    {
        switch (currentNPC)
        {
            case NPC.Nessie:
                currentNPC = NPC.Misha;
                return NessieDialogue[month].text;
            case NPC.Misha:
                currentNPC = NPC.Rita;
                return MishaDialogue[month].text;
            case NPC.Rita:
                currentNPC = NPC.Ellie;
                return RitaDialogue[month].text;
            case NPC.Ellie:
                currentNPC = NPC.Nessie;
                month++;
                monthlyMoney.SetMonthlyMoney(moneyValuesSO.baseIncomeMonthly);
                if (month > 12) {
                    Debug.Log("Game Over");
                    return "";
                }
                return EllieDialogue[month--].text;
        }

        return "";
    }

    public bool IsNessie()
    {
        return currentNPC == NPC.Nessie;
    }

    public bool IsMisha()
    {
        return currentNPC == NPC.Misha;
    }

    public bool IsRita()
    {
        return currentNPC == NPC.Rita;
    }

    public bool IsEllie()
    {
        return currentNPC == NPC.Ellie;
    }
}
