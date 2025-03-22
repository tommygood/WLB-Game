using UnityEngine;
using UnityEngine.Playables;

public class NPCTimelineTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    [SerializeField] PlayableDirector NPCTimeline;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") {
            Debug.Log(other.name);
            NPCTimeline.Play();
        }
    }
}
