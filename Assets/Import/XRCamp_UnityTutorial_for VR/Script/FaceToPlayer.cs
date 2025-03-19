using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToPlayer : MonoBehaviour
{
    //[HelpBox("Let the gameobject (usually UI) face to 'Player' object", HelpBoxMessageType.Info)]
    public Transform Player;

    void Update()
    {
        if (Player != null)
        {
            Vector3 direction = Player.position - transform.position;
            direction.y = 0;
            Quaternion rotation = Quaternion.LookRotation(direction);

            transform.rotation = rotation;
        }
    }
}
