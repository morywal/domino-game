using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        // Speed of horizontal camera movement (W, A, S, D)
    public float lookSensitivity = 2f;  // Sensitivity for mouse look
    public float verticalSpeed = 2f;    // Separate slower speed for vertical movement (up/down)

    private float xRotation = 0f;       // Track camera's X rotation

    void Update()
    {
        MoveCamera();
        RotateCamera();
    }

    void MoveCamera()
    {
        // Get movement input for horizontal movement
        float moveX = Input.GetAxis("Horizontal");  // A, D keys or arrow keys
        float moveZ = Input.GetAxis("Vertical");    // W, S keys or arrow keys

        // Horizontal movement relative to camera's forward and right directions
        Vector3 horizontalMove = transform.right * moveX + transform.forward * moveZ;

        // Apply horizontal movement (affected by moveSpeed)
        transform.position += horizontalMove * moveSpeed * Time.deltaTime;

        // Separate vertical movement (space for up, shift for down)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += Vector3.down * verticalSpeed * Time.deltaTime;  // Move down
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * verticalSpeed * Time.deltaTime;    // Move up
        }
    }

    void RotateCamera()
    {
        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        // Rotate the camera vertically (up/down) by modifying the X rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Limit vertical rotation to avoid flipping

        // Apply the rotations to the camera
        transform.localRotation = Quaternion.Euler(xRotation, transform.localEulerAngles.y, 0f);
        transform.Rotate(Vector3.up * mouseX);  // Rotate the camera horizontally (left/right)
    }
}
