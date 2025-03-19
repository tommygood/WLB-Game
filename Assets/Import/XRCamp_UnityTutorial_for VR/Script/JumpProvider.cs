using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpProvider : MonoBehaviour
{
    //[HelpBox("Provided jumping ability in VR Project.", HelpBoxMessageType.Info)]
    
    public LayerMask GroundLayerMask;
    public InputActionProperty JumpAction;
    public CharacterController character_Controller;
    public float JumpHeight = 1f;
    private float gravity = -9.8f;

    private bool isGrounded = false;
    private Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        if(JumpAction.action.WasPressedThisFrame() && (character_Controller.isGrounded || character_Controller.velocity.y == 0))
        {
            Jump();
        }

        movement.y += gravity* Time.deltaTime;
        character_Controller.Move(movement * Time.deltaTime);
    }

    private void Jump()
    {
        movement.y = Mathf.Sqrt(JumpHeight* -3.0f* gravity);
    }

    private void OnColliderEnter(Collision other)
    {
        if ((GroundLayerMask | (1 << other.gameObject.layer)) == GroundLayerMask)
        {
            isGrounded = true;
        
        }
    }

    private void OnColliderExit(Collision other)
    {
        if ((GroundLayerMask | (1 << other.gameObject.layer)) == GroundLayerMask)
        {
            isGrounded = false;
        }
    }
}
