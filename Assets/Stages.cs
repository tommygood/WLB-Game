using UnityEngine;

public class Stages : MonoBehaviour
{
    public bool currentStageFinished = true; // Use 'bool' instead of 'boolean'
    private int currentStage = 0; // Track the current stage
    public BalanceBar balanceBar;
    public DialogueManager dialogue_manager;
    public Meeting meeting;

    // Start is called before the first frame update
    void Start()
    {
        Play(); // Start the first stage automatically
    }

    public void Play()
    {
        // Check if the current stage is finished and play the next stage
        if (currentStageFinished)
        {
          currentStageFinished = false; // Reset flag
          currentStage++; // Move to the next stage

          switch (currentStage)
          {
              case 1:
                  Stage_1();
                  break;
              case 2:
                  Stage_2();
                  break;
              default:
                  Debug.Log("All Stages Completed!");
                  break;
          }
        }
    }

    public void Stage_1()
    {
        Debug.Log("Stage 1 started!");
        dialogue_manager.StartConversation();
    }

    public void Stage_2()
    {
        Debug.Log("Stage 2 started!");
        meeting.gameObject.SetActive(true);
        meeting.Play();
    }

    public void FinishStage(float interval)
    {
      Invoke("setStageFinished", interval);
    }

    private void setStageFinished() {
      currentStageFinished = true; // Flag to proceed to the next stage
    }

    public void setBalanceBar(float val) {
      balanceBar.setBalanceBar(val);
    }
}