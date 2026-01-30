using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 300f;
    public float gravity = -9.8f;

    float yVelocity;
    float xRotation = 0f;

    CharacterController controller;
    Transform cam;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>().transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // ===== ESC to unlock cursor =====
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // ===== MOUSE LOOK =====
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // ===== MOVEMENT =====
        float x = Input.GetAxis("Horizontal"); // A / D
        float z = Input.GetAxis("Vertical");   // W / S

        if (controller.isGrounded && yVelocity < 0)
        {
            yVelocity = -2f; // keeps player grounded
        }

        yVelocity += gravity * Time.deltaTime;

        Vector3 move =
            transform.right * x +
            transform.forward * z +
            Vector3.up * yVelocity;

        controller.Move(move * speed * Time.deltaTime);
    }
}
