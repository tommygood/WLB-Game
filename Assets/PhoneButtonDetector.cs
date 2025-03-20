using UnityEngine;

public class PhoneButtonDetector : MonoBehaviour
{
    public PhoneMessageDisplay phone_message_display; // Stores the object that enters the trigger
    public bool stopDetection = false; // Stops detection when true

    private void OnTriggerExit(Collider other)
    {
      if (stopDetection) return; // Stop detection if true

      Debug.Log("PhoneButtonDetector: OnTriggerExit");
      phone_message_display.isExpanded = true;
    }
}