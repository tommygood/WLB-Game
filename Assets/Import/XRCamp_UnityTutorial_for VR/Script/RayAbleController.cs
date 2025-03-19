using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayAbleController : MonoBehaviour
{
    //[HelpBox("You can add this script for hind the ray automaticly.", HelpBoxMessageType.Info)]

    public InputActionProperty LeftAction, RightAction;
    public GameObject LeftRay, RightRay;

    // Update is called once per frame
    void Update()
    {
        LeftRay.SetActive(LeftAction.action.ReadValue<float>() > 0.1f);
        RightRay.SetActive(RightAction.action.ReadValue<float>() > 0.1f);
    }
}

