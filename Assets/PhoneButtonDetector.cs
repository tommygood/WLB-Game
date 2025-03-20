using UnityEngine;

public class PhoneButtonDetector : MonoBehaviour
{
    public PhoneMessageDisplay phone_message_display; // Stores the object that enters the trigger
    public bool stopDetection = true; // Stops detection when true

    private void OnTriggerExit(Collider other)
    {
      if (stopDetection) return; // Stop detection if true

      // Debug.Log("PhoneButtonDetector: OnTriggerExit !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" + other.gameObject.name);
      phone_message_display.isExpanded = true;
    }
}