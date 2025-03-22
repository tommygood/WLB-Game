using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AimPlayer : MonoBehaviour
{

    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform npcHead;
    [SerializeField] private Rig rig;
    [SerializeField] private float distance;
    [SerializeField] private float lerpNum = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(npcHead.position, playerCamera.position) <= distance )
        {
            rig.weight = Mathf.Lerp(rig.weight, 1, lerpNum);
        }
        else
            rig.weight = Mathf.Lerp(rig.weight, 0, lerpNum);
    }
}
