using UnityEngine;

public class ElevatorAutoDetected : MonoBehaviour
{
    public ElevatorDoor elevatorDoor_L;
    public ElevatorDoor elevatorDoor_R;
    public GameObject elevator_running;
    public GameObject elevator_arriving;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("setElevatorDoorAutoDetected", 10f);
    }

    private void setElevatorDoorAutoDetected()
    {
        elevatorDoor_L.autoDetected = true;
        elevatorDoor_R.autoDetected = true;
        elevator_arriving.SetActive(true);
        elevator_running.SetActive(false);
    }
}
