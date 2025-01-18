using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float sensitivity = 2.0f;

    private float rotationX = 0f;
    private Transform playerCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>().transform;
        Cursor.lockState = CursorLockMode.Locked; // lock cursor to screen center
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // --- Handle Movement ---
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(moveX, 0, moveZ);

        // --- Handle Mouse Look ---
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate the player horizontally (yaw)
        Vector3 playerRotation = transform.rotation.eulerAngles;
        playerRotation.y += mouseX; // Modify only the Y-axis
        transform.rotation = Quaternion.Euler(playerRotation);

        Debug.Log("Player Yaw (Y-axis): " + transform.rotation.eulerAngles.y);

        // Vertical rotation (pitch) applied to the camera
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Restrict pitch rotation
        playerCamera.localRotation = Quaternion.Euler(rotationX, 0, 0);

        Debug.Log("Camera Pitch (X-axis): " + rotationX);
    }
}
