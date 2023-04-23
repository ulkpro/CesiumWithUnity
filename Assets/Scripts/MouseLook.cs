using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 10f;
    public Transform playerBody;
    float xRotation = 0f;

    private InputAction mouseAction;

    private void OnEnable()
    {
        mouseAction.Enable();
    }

    private void OnDisable()
    {
        mouseAction.Disable();
    }

    private void Awake()
    {
        mouseAction = new InputAction("mouse", InputActionType.PassThrough, "<Mouse>/delta");
        mouseAction.performed += context =>
        {
            float mouseX = context.ReadValue<Vector2>().x * mouseSensitivity * Time.deltaTime;
            float mouseY = context.ReadValue<Vector2>().y * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        };
    }
}
