using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI NPCname;
    public TMP_InputField input;

    public TextAsset textFile;

    public List<string> inputSection = new List<string>();
    public List<string> branchSection = new List<string> ();
    private List<string> lines = new List<string>();

    public float textSpeed;
    public GameObject EventMachine;
    private int index;
    private bool inputFinish = false;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;

        LoadLines();
        lines = inputSection;
        StartDialogue();
    }

    void LoadLines()
    {
        DialougeTracker tracker = EventMachine.GetComponent<DialougeTracker>();

        string[] rawLines = tracker.GetDialouge().Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.None);
        bool reachedBranch = false;

        foreach (string l in rawLines)
        {
            string line = l.Trim();

            if (line == "&" ||  line == "!" || line == "#")
            {
                reachedBranch = true;
                continue;
            }
            
            if(!reachedBranch && !string.IsNullOrWhiteSpace(line))
            {
                inputSection.Add(line);
            }
        }
     }

    void LoadBranch(char BlockType)
    {
        DialougeTracker tracker = EventMachine.GetComponent<DialougeTracker>();
        string[] raw = tracker.GetDialouge().Split(new[] {"\r\n", "\n"}, System.StringSplitOptions.None);
        bool inBlock = false;

        foreach (string l in raw)
        {
            string line = l.Trim();
            if(line == BlockType.ToString())
            {
                inBlock = !inBlock;
                continue;
            }

            if(inBlock)
            {
                branchSection.Add(line);
            }
        }

        lines = branchSection;
        index = 0;
        StartCoroutine(TypeLine());
    }

    void Update()
    {
        MoneySpend inputField = EventMachine.GetComponent<MoneySpend>();

        if (Input.GetMouseButtonDown(0) && !input.gameObject.activeSelf)
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

    char returnMood()
    {
        NewBehaviourScript mood = EventMachine.GetComponent<NewBehaviourScript>();
        if(mood.IsGoodMood())
        {
            return '&';
        }
        else if(mood.IsNeutralMood())
        {
            return '!';
        }
        return '#';
    }

        void StartDialogue()
        {
            index = 0;
            StartCoroutine(TypeLine());
        }

    void NextLine()
    {
        if (index < lines.Count - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else if(inputFinish)
        {
            Debug.Log(this.returnMood());
            LoadBranch(this.returnMood());
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

        IEnumerator TypeLine()
        {
            MoneySpend inputField = EventMachine.GetComponent<MoneySpend>();
            if(index < 0 || index >= lines.Count)
            {
                yield break;
            }

            if (lines[index].Contains("*input*"))
            {
                inputField.CallInputField();
            lines[index] = "";
                inputFinish = true;
                yield break;
            }

            foreach (char c in lines[index])
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
    
}
