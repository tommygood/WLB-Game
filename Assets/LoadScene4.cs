using UnityEngine;

public class LoadScene4 : MonoBehaviour
{
    public TriggerDetector scene_load_trigger;
    public GameObject whitescreen;

    // Update is called once per frame
    void Update()
    {
        if (scene_load_trigger.detectedObject.tag == "Player")
        {
            whitescreen.SetActive(true);
            Invoke("SetupNewScene", 2f);
        }
    }

    private void SetupNewScene()
    {
        SceneLoader.Instance.LoadNewScene("Assets/Custom/Jimmy/Scenes/LEVEL_02_SnowMountain 1.unity");
        SceneLoader.Instance.UnloadCurrentScene("Assets/Custom/Jimmy/Scenes/Level_02.unity");
    }
}
