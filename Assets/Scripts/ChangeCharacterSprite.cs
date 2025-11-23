using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeCharacterSprite : MonoBehaviour
{
    public static ChangeCharacterSprite Instance;

    [SerializeField] private GameObject character;
    [SerializeField] private Sprite[] NessieSprites;
    [SerializeField] private Sprite[] MishaSprites;
    [SerializeField] private Sprite[] RitaSprites;
    [SerializeField] private Sprite[] EllieSprites;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private MoneyValuesSO moneyValuesSO;

    private void Awake()
    {
        Instance = this;
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void SetNessieSprite(int mood)
    {
        textMeshProUGUI.text = "Suggested amount: $" + moneyValuesSO.NessieNecessitiesAmount;
        character.gameObject.GetComponent<SpriteRenderer>().sprite = NessieSprites[mood];
    }
    public void SetMishaSprite(int mood)
    {
        textMeshProUGUI.text = "Suggested amount: $" + moneyValuesSO.MishaLoanAmount;
        character.gameObject.GetComponent<SpriteRenderer>().sprite = MishaSprites[mood];
    }
    public void SetRitaSprite(int mood)
    {
        textMeshProUGUI.text = "Suggested amount: $" + moneyValuesSO.RitaRetirementAmount;
        character.gameObject.GetComponent<SpriteRenderer>().sprite = RitaSprites[mood];
    }
    public void SetEllieSprite(int mood)
    {
        textMeshProUGUI.text = "Suggested amount: $" + moneyValuesSO.EllieEntertainmentAmount;
        character.gameObject.GetComponent<SpriteRenderer>().sprite = EllieSprites[mood];
    }

    public void SetSpriteActive()
    {
        textMeshProUGUI.text = "Suggested amount: $" + moneyValuesSO.NessieNecessitiesAmount;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void SetSpriteInactive()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
