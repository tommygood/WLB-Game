using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils; // ✅ Required for XROrigin


public class LiftPlatform : MonoBehaviour
{
    public float liftHeight = 3f; // How high the platform lifts the player
    public float liftSpeed = 2f; // Speed of lifting the player
    private float stay_time = 0f;
    public float lift_or_down = 0f; // 1 for lift, -1 for down
    public Transform platformTransform;
    private bool isPlayerOnPlatform = false;
    private bool isUp = false;

    private void OnTriggerEnter(Collider other)
    {
      Debug.Log("LiftPlatform: OnTriggerEnter");
      stay_time = 0f;
      isPlayerOnPlatform = false;
    }

    private void OnTriggerExit(Collider other)
    {
      Debug.Log("LiftPlatform: OnTriggerExit");
      stay_time = 0f;
      isPlayerOnPlatform = false;
    }

    private void OnTriggerStay(Collider other)
    {
      stay_time += Time.deltaTime;
      if (stay_time > 5f && !isPlayerOnPlatform) {
        XROrigin xrOrigin = FindObjectOfType<XROrigin>();
        Debug.Log("LiftPlatform: xrOrigin.transform.position.y: " + xrOrigin.transform.position.y);
        Debug.Log(0.02279997f < lift_or_down);
        if (!isUp) {
          StartCoroutine(LiftPlayer(xrOrigin.transform));
        }
        else {
          StartCoroutine(DownPlayer(xrOrigin.transform));
        }
        isPlayerOnPlatform = true;
        isUp = !isUp;
      }
    }

    // down the player
    private System.Collections.IEnumerator DownPlayer(Transform playerTransform)
    {
        Vector3 startPosition = playerTransform.position;
        Vector3 targetPosition = startPosition + new Vector3(0, -liftHeight, 0);

        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            playerTransform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime * liftSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        playerTransform.position = targetPosition; // Ensure it reaches exact position
        platformTransform.position = new Vector3(platformTransform.position.x, platformTransform.position.y - 3.03f, platformTransform.position.z);
    }

    private System.Collections.IEnumerator LiftPlayer(Transform playerTransform)
    {
      Debug.Log("LiftPlaye: " + playerTransform.position.y);
        Vector3 startPosition = playerTransform.position;
        Vector3 targetPosition = startPosition + new Vector3(0, liftHeight, 0);

        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            playerTransform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime * liftSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

      
        playerTransform.position = targetPosition; // Ensure it reaches exact position
        platformTransform.position = new Vector3(platformTransform.position.x, platformTransform.position.y + 3.03f, platformTransform.position.z);
      Debug.Log("LiftPlayer: playerTransform.position.y: " + playerTransform.position.y);
    }
}