using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffectionLevels : MonoBehaviour
{
    public static AffectionLevels Instance;

    [SerializeField] private BackgroundsSO backgroundsSO;
    [SerializeField] private GameObject Background;
    [SerializeField] private Image bar;
    private int NessieLevel;
    private int MishaLevel;
    private int RitaLevel;
    private int EllieLevel;

    private void Awake()
    {
        Instance = this;
        NessieLevel = 4;
        MishaLevel = 4;
        RitaLevel = 4;
        EllieLevel = 4;
    }

    private void Update()
    {
        if (DialougeTracker.instance.IsEllie())
        {
            bar.fillAmount = NessieLevel / 10f;
        } else if (DialougeTracker.instance.IsMisha())
        {
            bar.fillAmount = MishaLevel / 10f;
        } else if (DialougeTracker.instance.IsRita())
        {
            bar.fillAmount = RitaLevel / 10f;
        } else if (DialougeTracker.instance.IsEllie())
        {
            bar.fillAmount = EllieLevel / 10f;
        }
    }

    public int GetNessieLevel()
    {
        return NessieLevel;
    }

    public void ChangeNessieLevelBy(int level)
    {
        NessieLevel += level;
        if (NessieLevel < 4)
        {
            Background.GetComponent<SpriteRenderer>().sprite = backgroundsSO.bridge;
        } else if (NessieLevel < 7) {
            Background.GetComponent<SpriteRenderer>().sprite = backgroundsSO.apartment;
        } else
        {
            Background.GetComponent<SpriteRenderer>().sprite = backgroundsSO.house;
        }
    }

    public int GetMishaLevel()
    {
        return MishaLevel;
    }

    public void ChangeMishaLevelBy(int level)
    {
        MishaLevel += level;
    }

    public int GetRitaLevel()
    {
        return RitaLevel;
    }

    public void ChangeRitaLevelBy(int level)
    {
        RitaLevel += RitaLevel;
    }

    public int GetEllieLevel()
    {
        return EllieLevel;
    }

    public void ChangeEllieLevelBy(int level)
    {
        EllieLevel += level;
    }
}
