using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerCamera; // Assign XR Rig's Camera (Main Camera)
    public float distance = 0.5f; // Distance in front of player
    public float heightOffset = -0.3f; // Slightly below eye level

    void Update()
    {
        if (playerCamera == null) return;

        // Position the panel in front of the player's view
        Vector3 targetPosition = playerCamera.position + playerCamera.forward * distance;
        targetPosition.y += heightOffset; // Adjust height
        transform.position = targetPosition;

        // Rotate the panel to face the player
        transform.LookAt(playerCamera);
        transform.Rotate(0, 180, 0); // Flip it to face forward
    }
}