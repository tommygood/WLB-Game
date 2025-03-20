using UnityEngine;

public class ComputerController : MonoBehaviour
{
  public TriggerDetector bootDetector;
  public GameObject screen;
  private bool isBootCalled = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (true) // FIXME: check if primary button is pressed
      {
        if (bootDetector.detectedObject != null) {
          Debug.Log("Computer is booting up.");
          isBootCalled = !isBootCalled;
        }
      }
      if (isBootCalled) {
        screen.SetActive(true);
      }
    }
}
