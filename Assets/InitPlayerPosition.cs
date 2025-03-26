using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UIElements;

public class InitPlayerPosition : MonoBehaviour
{
    public XROrigin xr_origin; // Assign in Inspector

    void Start()
    {
        SetXROriginPosition(new Vector3(18.158f, 0.55f, -8.85f), Quaternion.Euler(0, 521.909f, 0)); // Example: Set position to (0, 1.5, 0)
    }

    public void SetXROriginPosition(Vector3 position, Quaternion rotation)
    {
        if (xr_origin != null)
        {
            xr_origin.transform.position = position;  // Set position
            xr_origin.transform.rotation = rotation;  // Set rotation
        }
        else
        {
            Debug.LogError("XROrigin is not assigned in the Inspector!");
        }
    }
}