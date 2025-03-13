using UnityEngine;

public class Meeting : MonoBehaviour
{
    public PhoneMessageDisplay phone; // Reference to the PhoneMessageDisplay
    public float timeout = 10f;
    private Stages stages;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      if (timeout <= 0) {
        // task failed
        stages = FindObjectOfType<Stages>(); // Find Stages in the scene
        stages.FinishStage(3f);
        Debug.Log("Meeting Room task failed.");
        stages.setBalanceBar(-0.3f);
        this.enabled = false; // stop iterating the Update function
      }
      else {
        Vector3 playerPosition = Camera.main.transform.position;
        Vector3 meetingRoomPos = new Vector3(0f, 1.5f, -5f);
        if (playerPosition == meetingRoomPos) {
          stages.FinishStage(3f);
          Debug.Log("Meeting Room task succeed.");
          this.enabled = false; // stop iterating the Update function
        }
      }
      timeout -= Time.deltaTime;
    }

    public void Play() {
      // This task asks player arrive at the meeting room in a limited time
      if (phone != null)
        {
            phone.AddMessage("Boss", "hello, plz come to the office to join a meet in a minute.");
            Invoke("GFCall", 5f);
        }
    }

    private void GFCall() {
      phone.AddMessage("GF", "hi, would you like to chatting with me ?");
    }
}
