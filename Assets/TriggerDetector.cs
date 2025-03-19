using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public GameObject detectedObject; // Stores the object that enters the trigger

    private void OnTriggerEnter(Collider other)
    {
      detectedObject = other.gameObject; // Store the object
      Debug.Log("Stored Object: " + detectedObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == detectedObject)
        {
            Debug.Log("Object Left: " + detectedObject.name);
            detectedObject = null; // Clear the reference when the object leaves
        }
    }
}