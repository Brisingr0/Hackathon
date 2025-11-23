using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI NPCname;
    public TextAsset textFile;
    public List<string> lines = new List<string>();
    public float textSpeed;
    public GameObject EventMachine;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;

        LoadLines();
        StartDialogue();
    }

    void LoadLines()
    {
        DialougeTracker tracker = EventMachine.GetComponent<DialougeTracker>();
        string[] rawLines = tracker.GetDialouge().Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.None);
        foreach (string line in rawLines)
        {
            if(line.Contains(":"))
            {
                string[] parts = line.Split(":");
                NPCname.text = parts[0].Trim();
                lines.Add(parts[1].Trim());
            }
            else
            {
                lines.Add(line.Trim());
            }
        }
     }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

        void StartDialogue()
        {
            index = 0;
            StartCoroutine(TypeLine());
        }

        void NextLine()
        {
        if (index < lines.Count)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        IEnumerator TypeLine()
        {
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
}
