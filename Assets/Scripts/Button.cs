using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private AudioClip doorOpen;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OpenDoor()
    {
        AudioManager.instance.PlaySFX(doorOpen);
        Debug.Log("The door is opened!");
        door.SetActive(!door.activeSelf);
    }
}
