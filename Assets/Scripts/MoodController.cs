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
                AffectionLevels.Instance.ChangeNessieLevelBy(1);
                ChangeCharacterSprite.Instance.SetEllieSprite(2);
            } else if (money/moneyValuesSO.NessieNecessitiesAmount < .99)
            {
                mood = Mood.bad;
                AffectionLevels.Instance.ChangeNessieLevelBy(-1);
                ChangeCharacterSprite.Instance.SetEllieSprite(0);
            }
        }
        else if(DialougeTracker.instance.IsMisha())
        {
            if (money / moneyValuesSO.MishaLoanAmount > 1.05)
            {
                mood = Mood.good;
                AffectionLevels.Instance.ChangeMishaLevelBy(1);
                ChangeCharacterSprite.Instance.SetMishaSprite(2);
            }
            else if (money / moneyValuesSO.MishaLoanAmount < .95)
            {
                mood = Mood.bad;
                AffectionLevels.Instance.ChangeMishaLevelBy(-1);
                ChangeCharacterSprite.Instance.SetMishaSprite(0);
            }
            else
            {
                mood = Mood.neutral;
                ChangeCharacterSprite.Instance.SetMishaSprite(1);
            }
        }
        else if (DialougeTracker.instance.IsRita())
        {
            if (money / moneyValuesSO.RitaRetirementAmount > 1.05)
            {
                mood = Mood.good;
                AffectionLevels.Instance.ChangeRitaLevelBy(1);
                ChangeCharacterSprite.Instance.SetRitaSprite(2);
            }
            else if (money / moneyValuesSO.MishaLoanAmount < .95)
            {
                mood = Mood.bad;
                AffectionLevels.Instance.ChangeRitaLevelBy(-1);
                ChangeCharacterSprite.Instance.SetRitaSprite(0);
            }
            else
            {
                mood = Mood.neutral;
                ChangeCharacterSprite.Instance.SetRitaSprite(1);
            }
        }
        else if (DialougeTracker.instance.IsEllie())
        {
            if (money / moneyValuesSO.EllieEntertainmentAmount > 1.05)
            {
                mood = Mood.good;
                AffectionLevels.Instance.ChangeEllieLevelBy(1);
                ChangeCharacterSprite.Instance.SetEllieSprite(2);
            }
            else if (money / moneyValuesSO.EllieEntertainmentAmount < .95)
            {
                mood = Mood.bad;
                AffectionLevels.Instance.ChangeEllieLevelBy(-1);
                ChangeCharacterSprite.Instance.SetEllieSprite(0);
            }
            else
            {
                mood = Mood.neutral;
                ChangeCharacterSprite.Instance.SetEllieSprite(1);
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
