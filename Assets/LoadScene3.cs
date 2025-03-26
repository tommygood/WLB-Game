using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class LoadScene3 : MonoBehaviour
{
    public TriggerDetector scene_load_trigger;
    public GameObject whitescreen;
    public Image myImage; // Assign in Inspector
    private float current_time = 0f;
    private bool start_count_time = false;
    public float image_transparency = 0.1f;

    void Start()
    {
        SetTransparency(image_transparency);
    }

    public void SetTransparency(float alpha)
    {
        Color newColor = myImage.color;
        newColor.a = alpha; // Set transparency (0 = fully transparent, 1 = opaque)
        myImage.color = newColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (scene_load_trigger.detectedObject != null)
        {
            whitescreen.SetActive(true);
            Invoke("SetupNewScene", 6f);
            start_count_time=true;
        }
        if (start_count_time)
        {
            current_time += Time.deltaTime;
            if (current_time >= 0.05f)
            {
                current_time = 0f;
                image_transparency += 0.1f;
                SetTransparency(image_transparency);
            }
        }
    }

    private void SetupNewScene()
    {
        SceneLoader.Instance.LoadNewScene("Assets/Custom/Jimmy/Scenes/Level_02.unity");
        SceneLoader.Instance.UnloadCurrentScene("Assets/Custom/Jimmy/Scenes/LEVEL_01_SnowMountain.unity");
    }
}
