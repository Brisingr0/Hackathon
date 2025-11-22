using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    enum Mood
    {
        good,
        neutral,
        bad,
    }

    [SerializeField] MoneyValuesSO moneyValuesSO;
    private Mood mood;

    public void SetMood(float money)
    {
        if (DialougeTracker.instance.IsNessie())
        {
            if (money/moneyValuesSO.NessieNecessitiesAmount >= .99)
            {
                mood = Mood.good;
            } else if (money/moneyValuesSO.NessieNecessitiesAmount < .99)
            {
                mood = Mood.bad;
            }
        }
        else if(DialougeTracker.instance.IsMisha())
        {
            if (money / moneyValuesSO.MishaLoanAmount > 1.05)
            {
                mood = Mood.good;
            }
            else if (money / moneyValuesSO.MishaLoanAmount < .95)
            {
                mood = Mood.bad;
            }
            else
            {
                mood = Mood.neutral;
            }
        }
        else if (DialougeTracker.instance.IsRita())
        {
            if (money / moneyValuesSO.RitaRetirementAmount > 1.05)
            {
                mood = Mood.good;
            }
            else if (money / moneyValuesSO.MishaLoanAmount < .95)
            {
                mood = Mood.bad;
            }
            else
            {
                mood = Mood.neutral;
            }
        }
        else if (DialougeTracker.instance.IsEllie())
        {
            if (money / moneyValuesSO.EllieEntertainmentAmount > 1.05)
            {
                mood = Mood.good;
            }
            else if (money / moneyValuesSO.EllieEntertainmentAmount < .95)
            {
                mood = Mood.bad;
            }
            else
            {
                mood = Mood.neutral;
            }
        }
    }

    public bool IsGoodMood()
    {
        return mood == Mood.good;
    }

    public bool IsNeutralMood()
    {
        return mood == Mood.neutral;
    }

    public bool IsBadMood()
    {
        return mood == Mood.bad;
    }
}
