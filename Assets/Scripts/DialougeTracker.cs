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
    private NPC nextNPC;
    private int call;
    private int month;

    private void Start()
    {
        instance = this;
        currentNPC = NPC.Nessie;
        nextNPC = NPC.Nessie;
        month = 0;
        call = 0;
    }

    public String GetDialouge()
    {
        if (currentNPC != nextNPC)
        {
            currentNPC = nextNPC;
        }
        switch (currentNPC)
        {
            case NPC.Nessie:
                if (call == 1)
                {
                    nextNPC = NPC.Misha;
                    call = 0;
                } else
                {
                    call++;
                }
                return NessieDialogue[month].text;
            case NPC.Misha:
                if (call == 1)
                {
                    nextNPC = NPC.Rita;
                    call = 0;
                } else
                {
                    call++;
                }
                return MishaDialogue[month].text;
            case NPC.Rita:
                if (call == 1)
                {
                    nextNPC = NPC.Ellie;
                    call = 0;
                }
                else
                {
                    call++;
                }
                return RitaDialogue[month].text;
            case NPC.Ellie:
                if (call == 1)
                {
                    nextNPC = NPC.Nessie;
                    call = 0;
                    month++;
                    monthlyMoney.SetMonthlyMoney(moneyValuesSO.baseIncomeMonthly);
                    if (month > 12)
                    {
                        Debug.Log("Game Over");
                        return "";
                    }
                } else
                {
                    call++;
                }
                return EllieDialogue[month - 1 + call].text;
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
