using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacterSprite : MonoBehaviour
{
    public static ChangeCharacterSprite Instance;

    [SerializeField] private GameObject character;
    [SerializeField] private Sprite[] NessieSprites;
    [SerializeField] private Sprite[] MishaSprites;
    [SerializeField] private Sprite[] RitaSprites;
    [SerializeField] private Sprite[] EllieSprites;

    private void Awake()
    {
        Instance = this;
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void SetNessieSprite(int mood)
    {
        character.gameObject.GetComponent<SpriteRenderer>().sprite = NessieSprites[mood];
    }
    public void SetMishaSprite(int mood)
    {
        character.gameObject.GetComponent<SpriteRenderer>().sprite = MishaSprites[mood];
    }
    public void SetRitaSprite(int mood)
    {
        character.gameObject.GetComponent<SpriteRenderer>().sprite = RitaSprites[mood];
    }
    public void SetEllieSprite(int mood)
    {
        character.gameObject.GetComponent<SpriteRenderer>().sprite = EllieSprites[mood];
    }

    public void SetSpriteActive()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void SetSpriteInactive()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
