using UnityEngine;

public class AudioStopper : MonoBehaviour
{
    public AudioSource audioSource;
    private bool stop_once_in_update = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.Stop();
    }

    private void Update()
    {
        if (!stop_once_in_update)
        {
            audioSource.Stop();
            stop_once_in_update=true;
        }
    }
}
