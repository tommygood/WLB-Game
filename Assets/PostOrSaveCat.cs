using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;


public class PostOrSaveCat : MonoBehaviour
{
    public TriggerDetector triggerDetector1;
    private bool isBossCalled = false;
    public DialogueManager dialogue_manager;
    public Transform xrOrigin;

    public TriggerDetector catTrigger;

    private Stages stages;
    public float targetY = 0f; // Final Y position
    public float dropSpeed = 0.5f;
    public float rotateSpeed = 30; // Rotation speed
    private bool saveCat = false;
    public GameObject blackscreen;
    public GameObject audio_fall_down;

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

      if (catTrigger.detectedObject != null && !saveCat) {
            saveCat = true;
        Debug.Log("Save the Catttttttttttttttt");
            if (xrOrigin != null)
            {
                StartCoroutine(DropDown());
            }
            // FIXME: add the drop down animation
            if (stages != null) { 
          stages.FinishStage(8f);
        }
      }
    }

    IEnumerator DropDown()
    {
        while (xrOrigin.position.y > targetY)
        {
            xrOrigin.position += new Vector3(0, -dropSpeed * Time.deltaTime, 0);
            xrOrigin.Rotate(0, rotateSpeed * Time.deltaTime, 0);
            if (xrOrigin.position.y <= targetY)
            {
                Debug.Log("touch the EARTHHHHHHHHHHHHHHHHHHHHHHH");
                audio_fall_down.SetActive(true);
                blackscreen.SetActive(true);
                Invoke("SetupNewScene", 6f);
            }
            yield return null; // Wait for next frame
        }
    }

    private void SetupNewScene()
    {
        SceneLoader.Instance.LoadNewScene("Assets/Custom/Jimmy/Scenes/LEVEL_01_SnowMountain.unity");
        SceneLoader.Instance.UnloadCurrentScene("Demo");
        SceneLoader.Instance.UnloadCurrentScene("City CUT");
        SceneLoader.Instance.UnloadCurrentScene("Level_01 CUT");
    }

    public void Play() {
    }
}