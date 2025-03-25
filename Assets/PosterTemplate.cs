using UnityEngine;

public class PosterTemplate : MonoBehaviour
{
    public Transform poster;
    public Transform template;
    private Stages stages;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stages = FindObjectOfType<Stages>(); // Find Stages in the scene
    }

    // Update is called once per frame
    void Update()
    {
        // detect the distance between the poster and the template
        float distance = Vector3.Distance(poster.position, template.position);
        // Debug.Log("Distance: " + distance);
        // if the distance is less than 0.1f
        if (distance < 0.2f)
        {
            // set the poster on the template
            poster.position = template.position;
            Rigidbody rb = poster.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            // set the poster rotation to the template rotation
            poster.rotation = template.rotation;
            if (template.gameObject.tag == "LastTemplate") {
                // FIXME: set the scene to midnight
                Debug.Log("Finish the poster stage !!!!!!!!!");
                 if (stages != null) { 
                    stages.FinishStage(8f);
                }
            }
        }
    }
}
