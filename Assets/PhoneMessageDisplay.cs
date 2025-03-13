using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class PhoneMessageDisplay : MonoBehaviour
{
    public TextMeshProUGUI button_1_text; // The UI Text component that displays messages
    public TextMeshProUGUI button_2_text; // The UI Text component that displays messages
    public TextMeshProUGUI textExpansion;
    public Button button_1;
    public Button button_2;
    public int maxMessages = 20; // Limit the number of messages displayed
    private List<string> messageList = new List<string>(); // Stores all messages

    void Start()
    {
        // UpdateDisplay(); // Ensure UI is updated at the start
    }

    // Function to add a message from other scripts
    public void AddMessage(string character, string message)
    {
        // Add message to the list
        messageList.Add(character + "@" + message + "@");

        // Remove the oldest message if maxMessages is exceeded
        if (messageList.Count > maxMessages)
        {
            messageList.RemoveAt(0);
        }

        // Update the UI
        UpdateDisplay();
    }

    // Function to update the UI with messages
    private void UpdateDisplay()
    {
      if (button_1_text.text == "") {
        setButton(messageList, button_1, button_1_text);
      }
      else if (button_2_text.text == "") {
        setButton(messageList, button_2, button_2_text);
      }
      else {
        Debug.Log("Warn: there are no empty button.");
      }
    }

    private void setButton(List<string> messageList, Button button, TextMeshProUGUI button_text) {
      string[] s = (string.Join("", messageList)).Split("@");
      if (s.Length < 3) {
        Debug.Log("length of messageList must over 3");
        return;
      }
      string character = s[(s.Length-1)-2];
      string text = s[(s.Length-1)-1];
      button_text.text = character; // Display messages with line breaks
      button.onClick.RemoveAllListeners();
      button.onClick.AddListener(() => ShowFullMessage(text));
    }

    // Function to replace the button with full text
    private void ShowFullMessage(string fullMessage)
    {
        textExpansion.text = fullMessage;
        Invoke("ClearTextExpansion", 3);   
    }

    public void ClearTextExpansion() {
      textExpansion.text = "";
    }
}