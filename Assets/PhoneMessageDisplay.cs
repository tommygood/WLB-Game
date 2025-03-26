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
    private List<string> messageList_Boss = new List<string>(); // Stores all messages
    private List<string> messageList_GF = new List<string>(); // Stores all messages
    public bool isExpanded = false;

    public PhoneButtonDetector phoneButtonDetector_Boss;
    public PhoneButtonDetector phoneButtonDetector_GF;

    public ElevatorDoor elevatorDoor_L;
    public ElevatorDoor elevatorDoor_R;
    public GameObject elevator_running;
    public GameObject elevator_arriving;
    public GameObject audio_phone_ring;

    private string text = "NULL";

    private bool autoDetected = false;
    private GameObject audio;

    void Start()
    {
        // UpdateDisplay(); // Ensure UI is updated at the start
    }

    public void Update()
    {
        if (isExpanded) {
          ShowFullMessage("");
            // Find the first object with the given tag
            if (this.text == "NULL")
            {
                return;
            }
            audio_phone_ring.SetActive(false);
            GameObject targetObject = GameObject.FindGameObjectWithTag(this.text);
            audio = targetObject;

          if (targetObject != null)
          {
              // Do something with the found object
              Debug.Log("Found object: " + targetObject.name);
              AudioSource audioSource = targetObject.GetComponent<AudioSource> ();
              audioSource.Play();
          }
          else {
            Debug.Log("audio object not found !!!!!!!!:" + this.text);
          }
          isExpanded = false;
          phoneButtonDetector_Boss.stopDetection = true;
          phoneButtonDetector_GF.stopDetection = true;
          if (this.autoDetected) {
            Invoke("setElevatorDoorAutoDetected", 10f);
            Invoke("DisableAudio", 13f);
            this.autoDetected = false;
          }
        }
    }

    private void DisableAudio()
    {
        if (audio != null)
        {
            audio.SetActive(false);
            audio = null;
        }
    }

    private void setElevatorDoorAutoDetected()
    {
        elevatorDoor_L.autoDetected = true;
        elevatorDoor_R.autoDetected = true;
        elevator_arriving.SetActive(true);
        elevator_running.SetActive(false);
    }

    // Function to add a message from other scripts
    public void AddMessage(string character, string message, bool autoDetected = false)
    {
      if (message == "NULL") {
        return;
      }
      if (character == "Boss") {
        // Add message to the list
        Debug.Log("adding the message to Boss queue" + message);
        messageList_Boss.Add(autoDetected.ToString() + "@" + character + "@" + message + "@");

        // Remove the oldest message if maxMessages is exceeded
        if (messageList_Boss.Count > maxMessages)
        {
            messageList_Boss.RemoveAt(0);
        }
        button_1.image.color = Color.red; // Change to any color
        audio_phone_ring.SetActive(true);
      }
      else if (character == "GF") {
        // Add message to the list
        messageList_GF.Add(autoDetected.ToString() + "@" + character + "@" + message + "@");

        // Remove the oldest message if maxMessages is exceeded
        if (messageList_GF.Count > maxMessages)
        {
            messageList_GF.RemoveAt(0);
        }
         button_2.image.color = Color.red; // Change to any color
      }

        // Update the UI
        UpdateDisplay(character);
    }

    // Function to update the UI with messages
    private void UpdateDisplay(string character)
    {
      if (character == "Boss") {
        setButton(messageList_Boss, button_1, button_1_text);
      }
      else if (character == "GF") {
        setButton(messageList_GF, button_2, button_2_text);
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
      this.autoDetected = s[(s.Length-1)-3] == "True";
      string character = s[(s.Length-1)-2];
      string text = s[(s.Length-1)-1];
      button_text.text = character; // Display messages with line breaks
      phoneButtonDetector_Boss.stopDetection = false;
      phoneButtonDetector_GF.stopDetection = false;
      this.text = text;
      Debug.Log("phone start!" + text);
      // button.onClick.RemoveAllListeners();
      // button.onClick.AddListener(() => ShowFullMessage(text));
    }

    // Function to replace the button with full text
    private void ShowFullMessage(string fullMessage)
    {
      if (fullMessage == "NULL") {
        return;
      }
        textExpansion.text = fullMessage;
        Invoke("ClearTextExpansion", 7);   
    }

    public void ClearTextExpansion() {
      textExpansion.text = "";
      button_1.image.color = Color.gray;
      button_1.GetComponentInChildren<TMP_Text>().text = "";
      button_2.image.color = Color.gray;
      button_2.GetComponentInChildren<TMP_Text>().text = "";
    }
}