using UnityEngine;

public class PlayerDefault : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * 2.0f;
        transform.Rotate(0, mouseX, 0);
    }
}
