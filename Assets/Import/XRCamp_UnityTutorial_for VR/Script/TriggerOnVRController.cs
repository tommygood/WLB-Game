using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[System.Serializable]
public class InputActionEventPair
{
    public InputActionProperty InputAction;
    //public GameEvent GameEvent;
    public UnityEvent UnityEvent;
}

public class TriggerOnVRController : MonoBehaviour
{
    //[HelpBox("You can set which button triggers which event and function by adding more inputActionEventPairs.", HelpBoxMessageType.Info)]

    public List<InputActionEventPair> inputActionEventPairs;

    void Update()
    {
        foreach (var pair in inputActionEventPairs)
        {
            if (pair.InputAction.action.WasPressedThisFrame())
            {
                //pair.GameEvent?.Raise();
                pair.UnityEvent?.Invoke();
            }
        }
    }
}
