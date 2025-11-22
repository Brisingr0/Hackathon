using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTracker : MonoBehaviour
{
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
    private NPC currentNPC;
    private int month;

    private void Start()
    {
        NessieDialogue = new TextAsset[12];
        MishaDialogue = new TextAsset[12];
        RitaDialogue = new TextAsset[12];
        EllieDialogue = new TextAsset[12];
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
                if (month > 12) {
                    Debug.Log("Game Over");
                    return "";
                }
                return EllieDialogue[month--].text;
        }

        return "";
    }


}
