using UnityEngine;

public class Meeting : MonoBehaviour
{
    public PhoneMessageDisplay phone; // Reference to the PhoneMessageDisplay
    public float timeout = 10f;
    private Stages stages;
    public TriggerDetector triggerDetector1;
    public TriggerDetector triggerDetector2;
    private bool isBossCalled = false;
    private bool isGFCalled = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      stages = FindObjectOfType<Stages>(); // Find Stages in the scene
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = Camera.main.transform.position;
      Vector3 meetingRoomPos = new Vector3(0f, 1.5f, -5f);
      if (playerPosition == meetingRoomPos) {
        stages.FinishStage(3f);
        Debug.Log("Meeting Room task succeed.");
        this.enabled = false; // stop iterating the Update function
      }
      if (triggerDetector1.detectedObject != null && !isBossCalled) {
        if (phone != null && triggerDetector1.detectedObject.name == "Body")
        {
          phone.AddMessage("Boss", "boss_1");
          isBossCalled = true;
        }
      }

      if (triggerDetector2.detectedObject != null && !isGFCalled) {
        if (phone != null && triggerDetector2.detectedObject.name == "Body")
        {
          phone.AddMessage("GF", "gf_1", true);
          isGFCalled = true;
          stages.FinishStage(5f);
          Debug.Log("Meeting Room task succeed.");
        }
      }
    }

    public void Play() {
    }

    private void GFCall() {
      phone.AddMessage("GF", "hi, would you like to chatting with me ?");
    }
}