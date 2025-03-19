using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticInteractable : MonoBehaviour
{
    //[HelpBox("Haptic for one hand. You can add this script for each hand controller.", HelpBoxMessageType.Info)]

    public XRBaseController Controller;
    public float Duration = 0.5f, Intansity = 0.5f;

    public void HapticActiveOnce()
    {
        Controller.SendHapticImpulse(Intansity, Duration);
    }
}
