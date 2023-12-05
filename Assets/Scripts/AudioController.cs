using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource.Play();
    }

    private void Update()
    {
        if (GameObject.Find("RobotKyle").GetComponent<PlayerController>().gameOver)
        {
            audioSource.Stop();
        }
    }
}