using UnityEngine;
using UnityEngine.XR;

public class ElevatorDoor : MonoBehaviour
{
    public enum DoorType { Left, Right } // To identify door side
    public DoorType doorSide; // Assign in the Inspector

    public float detectionRange = 2f; // Player detection range
    public float doorSpeed = 1f; // Speed of movement
    public float openDistance = 2f; // How far the door moves

    public bool autoDetected = false;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isPlayerNear;
    private bool isPlayerBehind;

    void Start()
    {
        // Save original closed position
        closedPosition = transform.position;

        // Set open position based on door type
        if (doorSide == DoorType.Left)
        {
            openPosition = closedPosition + transform.right * -openDistance; // Move left door left
        }
        else
        {
            openPosition = closedPosition + transform.right * openDistance; // Move right door right
        }
    }

    void Update()
    {
        if (autoDetected) {

            // Detect VR player's head position
            if (Camera.main != null)
            {
                Vector3 playerPos = Camera.main.transform.position;
                float distance = Vector3.Distance(playerPos, transform.position);
                isPlayerNear = distance < detectionRange;
            }
            Debug.Log("is player near");
            Debug.Log(isPlayerNear);

            // Move doors based on player proximity
            transform.position = Vector3.Lerp(transform.position, isPlayerNear ? openPosition : closedPosition, Time.deltaTime * doorSpeed);
        }
    }
}