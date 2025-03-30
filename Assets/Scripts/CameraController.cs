using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;  // Store camera offset

    void Start()
    {
        // Offset to keep the camera behind the player
        offset = new Vector3(-5f, 5f, 0);  // Adjust Y & Z to your need
    }

    void LateUpdate() // Use LateUpdate() for smooth camera following
    {
        transform.position = player.transform.position + offset;
    }
}
