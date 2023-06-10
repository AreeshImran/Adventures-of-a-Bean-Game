using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueMech : MonoBehaviour
{
    public static DialogueMech Instance { get; set; }
    public GameObject textPanel;
    public List<string> dialogueTexts = new List<string>();
    public string npcName;

    Button nextButton;
    TMP_Text talkingText, nameText;
    int textIndex;

    void Awake()
    {
        nextButton = textPanel.transform.Find("Next").GetComponent<Button>();

        talkingText = textPanel.transform.Find("Text").GetComponent<TMP_Text>();

        nameText = textPanel.transform.Find("Name").GetChild(0).GetComponent<TMP_Text>();

        textPanel.SetActive(false);

        nextButton.onClick.AddListener(delegate { ContinueText(); });
        
        if (Instance != null && Instance != this){
            Destroy(gameObject);
        }
        else{
            Instance = this;
        }
    }


    public void NewDialogue(string[] texts, string npcName){
        textIndex = 0;

        dialogueTexts = new List<string>();
        foreach(string text in texts)
        {
            dialogueTexts.Add(text);
        }

        this.npcName = npcName;

        Debug.Log(dialogueTexts.Count);
        dialogueCreation();
    }

    public void dialogueCreation(){
        talkingText.text = dialogueTexts[textIndex];
        nameText.text = npcName;
        textPanel.SetActive(true);

    }

    public void ContinueText(){
        if (dialogueTexts.Count-1 > textIndex){
            textIndex++;
            talkingText.text = dialogueTexts[textIndex];
        }
        else{
            textPanel.SetActive(false);
        }
    }
}
