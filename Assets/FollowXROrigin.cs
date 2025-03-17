using UnityEngine;

public class FollowXROrigin : MonoBehaviour
{
    public Transform xrOrigin; // Assign XR Origin in Inspector
    public float yOffset = -0.1f; // Adjust to match player height

    void Update()
    {
        if (xrOrigin != null)
        {
            // Match XR Origin position but keep the Y offset
            transform.position = new Vector3(xrOrigin.position.x, xrOrigin.position.y + yOffset, xrOrigin.position.z);
            transform.rotation = xrOrigin.rotation; // Match rotation
        }
    }
}