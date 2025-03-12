using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class Dialogue
    {
        public string speaker;
        [TextArea(2, 5)]
        public string[] sentences;
    }

    public TextMeshProUGUI dialogueText;  // Reference to the text UI
    public Button nextButton;             // Button to continue the conversation
    public GameObject canvas;

    public List<Dialogue> dialogues;      // List of dialogues
    private int currentDialogueIndex = 0;
    private int currentSentenceIndex = 0;

    void Start()
    {
      Debug.Log(dialogueText.fontSize);
        nextButton.onClick.AddListener(DisplayNextSentence);
        StartConversation();
    }

    public void StartConversation()
    {
        if (dialogues.Count > 0)
        {
            currentDialogueIndex = 0;
            currentSentenceIndex = 0;
            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if (currentDialogueIndex >= dialogues.Count)
        {
            EndConversation();
            return;
        }

        Dialogue currentDialogue = dialogues[currentDialogueIndex];

        if (currentSentenceIndex < currentDialogue.sentences.Length)
        {
            dialogueText.text = $"{currentDialogue.speaker}: {currentDialogue.sentences[currentSentenceIndex]}";
            currentSentenceIndex++;
        }
        else
        {
            currentDialogueIndex++;
            currentSentenceIndex = 0;
            DisplayNextSentence();
        }
    }

    public void EndConversation()
    {
        dialogueText.text = "";
        nextButton.gameObject.SetActive(false);
        canvas.SetActive(false);
        Debug.Log("End of Conversation");
    }
}