using UnityEngine;

public class FilesBalance : MonoBehaviour
{
    public float random_radius = 45f;

    public GameObject file;
    public Transform file1;
    public Transform file2;
    public Transform file3;
    public Transform file4;

    public TriggerDetector grabber1;
    public TriggerDetector grabber2;
    public TriggerDetector grabber3;
    public TriggerDetector grabber4;
    private bool start_grab = false;
    private Transform left_hand = null;
    private Transform right_hand = null;
    private float random_range;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        random_range = RandomRange();
    }

    // Update is called once per frame
    void Update()
    {
        // check if one of grabber is grabbed by player
        if (grabber1.detectedObject != null || grabber2.detectedObject != null || grabber3 != null || grabber4 != null) {
            // start make the file move little left or right randomly
            if (grabber1.detectedObject != null) {
                if (grabber1.detectedObject.name == "Left Controller") {
                    left_hand = grabber1.detectedObject.transform;
                }
            }
            if (grabber2.detectedObject != null) {
                if (grabber2.detectedObject.name == "Left Controller") {
                    left_hand = grabber2.detectedObject.transform;
                }
            }
            if (grabber3.detectedObject != null) {
                if (grabber3.detectedObject.name == "Left Controller") {
                    left_hand = grabber3.detectedObject.transform;
                }
            }
            if (grabber4.detectedObject != null) {
                if (grabber4.detectedObject.name == "Left Controller") {
                    left_hand = grabber4.detectedObject.transform;
                }
            }
            if (left_hand != null) {
                Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Grab the file:");
                start_grab = true;
            }
            // file1.position = Vector3.MoveTowards(file1.position.x+random_range, grabber1.position.y+)
        }
        if (start_grab) {
            this.Invoke("activateFile", 3.0f);
            start_grab = false;
            // file1.Rotate(Vector3.right , random_range * Time.deltaTime);
        }
    }

    void activateFile() {
        Rigidbody rb = file.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
    }

    void MoveFile(Transform file, float random_range) {
    }

    float RandomRange() {
        return Random.Range(-random_radius, random_radius);
    }
}
