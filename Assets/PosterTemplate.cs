using UnityEngine;

public class PosterTemplate : MonoBehaviour
{
    public Transform poster;
    public Transform template;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            Debug.Log("Poster is in the right place");
            Debug.Log("template.position: " + template.position);
            Debug.Log("poster.position: " + poster.position);
            // set the poster on the template
            poster.position = template.position;
            // set the poster rotation to the template rotation
            poster.rotation = template.rotation;
        }
    }
}
