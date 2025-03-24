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
    private Stages stages;
    private bool finishStage = true;

    void Start()
    {
        nextButton.onClick.AddListener(DisplayNextSentence);
        stages = FindObjectOfType<Stages>(); // Find Stages in the scene
    }

    public void StartConversation(bool finishStage = true)
    {
      this.finishStage = finishStage;
      // log the dialogues list
      Debug.Log("Dialogues: " + dialogues);
      for (int i = 0; i < dialogues.Count; i++) {
        Debug.Log("Dialogues[" + i + "]: " + dialogues[i].sentences);
      }

        if (dialogues.Count > 0)
        {
            DisplayNextSentence();
        }
    }
    
    public void DisplayNextSentenceInAudio() {
        if (currentDialogueIndex >= dialogues.Count)
        {
            EndConversation();
            return;
        }

        Dialogue currentDialogue = dialogues[currentDialogueIndex];

        if (currentSentenceIndex < currentDialogue.sentences.Length)
        {
            // Find the first object with the given tag
            GameObject targetObject = GameObject.FindGameObjectWithTag(currentDialogue.sentences[currentSentenceIndex]);

            if (targetObject != null)
            {
                // Do something with the found object
                Debug.Log("Found object: " + targetObject.name);
                targetObject.SetActive(true);
            }
            currentSentenceIndex++;
        }
        else
        {
            currentDialogueIndex++;
            currentSentenceIndex = 0;
            DisplayNextSentenceInAudio();
        }
    }

    public void DisplayNextSentence()
    {
        if (currentDialogueIndex >= dialogues.Count)
        {
            EndConversation();
            return;
        }
        if (canvas.activeSelf == false)
        {
            canvas.SetActive(true);
            nextButton.gameObject.SetActive(true);
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
        if (stages != null) {
          if (finishStage) {
            stages.FinishStage(3f);
          }
        }
    }
}