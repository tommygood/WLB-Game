using UnityEngine;

public class PostOrSaveCat : MonoBehaviour
{
    public TriggerDetector triggerDetector1;
    private bool isBossCalled = false;
    public DialogueManager dialogue_manager;

    public TriggerDetector catTrigger;

    private Stages stages;

    void Start()
    {
        stages = FindObjectOfType<Stages>(); // Find Stages in the scene
    }

    // Update is called once per frame
    void Update()
    {
      if (triggerDetector1.detectedObject != null && !isBossCalled) {
        Debug.Log("Post a poster to officer room.!!!!!!!!!!!!");
        isBossCalled = true;
        dialogue_manager.dialogues.Add(new DialogueManager.Dialogue {
            speaker = "Boss",
            sentences = new string[] { "Post a poster to officer room." }
        });
        dialogue_manager.StartConversation(false);
      }

      if (catTrigger.detectedObject != null) {
        Debug.Log("Save the Catttttttttttttttt");
        // FIXME: add the drop down animation
        if (stages != null) { 
          stages.FinishStage(8f);
        }
      }
    }

    public void Play() {
    }
}