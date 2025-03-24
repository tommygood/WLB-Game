using UnityEngine;

public class SpinDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform Door;
    public float max_rotation_degree = 80f;
    private float start_z;
    private float last_z;
    private float door_x;
    private float door_y;
    void Start()
    {
        start_z = transform.position.z;
        last_z = start_z;
        door_x = Door.rotation.x;
        door_y = Door.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        // open full door while z interval over 0.35
        if (transform.position.z != last_z) {
            
            float rotate_degree = (float)(max_rotation_degree * ((transform.position.z - start_z) / 0.35));
            Debug.Log("Start opening the working door ~~~~~~~~~~~~~~");
            Debug.Log(rotate_degree);
            Door.rotation = Quaternion.Euler(Door.rotation.x, Door.rotation.y+rotate_degree, Door.rotation.z);
            last_z = transform.position.z;
        }
    }
}
