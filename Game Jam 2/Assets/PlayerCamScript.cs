using UnityEngine;

public class PlayerCamScript : MonoBehaviour
{
    public Transform player;
    public float mouseSens = 100f;
    float cameraVerticalRotation = 0f;
    //bool lockedCursor = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxis("Mouse X") * mouseSens;
        float inputY = Input.GetAxis("Mouse Y") * mouseSens;

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        //transform.localRotation = Quaternion.Euler(cameraVerticalRotation, 0f, 0f);
        player.Rotate(Vector3.up * inputX);
    }
}
