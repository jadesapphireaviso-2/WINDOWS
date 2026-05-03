using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;

    [Header("Mouse Look")]
    [SerializeField] float mouseSensitivity = 2f;
    float xRotation = 0f;

    [Header("Cameras")]
    [SerializeField] GameObject firstPersonCamera;
    [SerializeField] GameObject thirdPersonCamera;
    bool isFirstPerson = true;

    private void Start()
    {
        // lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // start in first person
        firstPersonCamera.SetActive(true);
        thirdPersonCamera.SetActive(false);
    }

    private void Update()
    {
        HandleMovement();
        HandleMouseLook();
        HandleCameraSwitch();
    }

    void HandleMovement()
    {
        // get WASD input
        float moveX = Keyboard.current.aKey.isPressed ? -1f :
                      Keyboard.current.dKey.isPressed ?  1f : 0f;
        float moveZ = Keyboard.current.wKey.isPressed ?  1f :
                      Keyboard.current.sKey.isPressed ? -1f : 0f;

        // move relative to where player is facing
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void HandleMouseLook()
    {
        // get mouse input
        float mouseX = Mouse.current.delta.x.ReadValue() * mouseSensitivity;
        float mouseY = Mouse.current.delta.y.ReadValue() * mouseSensitivity;

        // rotate player left and right
        transform.Rotate(Vector3.up * mouseX);

        // rotate camera up and down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); // stops over rotating
        firstPersonCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        thirdPersonCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void HandleCameraSwitch()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            isFirstPerson = !isFirstPerson;
            firstPersonCamera.SetActive(isFirstPerson);
            thirdPersonCamera.SetActive(!isFirstPerson);
        }
    }
}