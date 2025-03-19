using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMoveByKeyboard : MonoBehaviour
{
    //[HelpBox("Provided basic keyboard moving when debuging VR Project.", HelpBoxMessageType.Info)]

    public bool isActive = true;
    public float moveSpeed = 5f;
    private CharacterController character_Controller;

    void Start()
    {
        character_Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        moveDirection = transform.TransformDirection(moveDirection);

        Vector3 moveAmount = moveDirection * moveSpeed * Time.deltaTime;

        character_Controller.Move(moveAmount);
    }
}
