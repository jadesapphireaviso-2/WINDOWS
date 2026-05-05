using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    //TESTING CODE
    
    

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

        
        firstPersonCamera.SetActive(true);
        thirdPersonCamera.SetActive(false);

        //testing codes
        // TEMP - press K to activate key for testing
        if (Keyboard.current.kKey.wasPressedThisFrame)
            FindFirstObjectByType<Key>().ActivateKey();
    }

    private void Update()
    {
        HandleMovement();
        HandleMouseLook();
        HandleCameraSwitch();
    }

    void HandleMovement()
    {
    
        float moveX = Keyboard.current.aKey.isPressed ? -1f :
                      Keyboard.current.dKey.isPressed ?  1f : 0f;
        float moveZ = Keyboard.current.wKey.isPressed ?  1f :
                      Keyboard.current.sKey.isPressed ? -1f : 0f;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void HandleMouseLook()
    {
        //for mouse input
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