using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementControls : MonoBehaviour
{
    public float moveSpeed = 100f;
    private Vector2 moveDirection;
    private CharacterController controller;
    private InputActions controls;
    private Transform cameraTransform;

    private void Awake()
    {
        controls = new InputActions();
        controls.Player.Move.performed += ctx => moveDirection = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveDirection = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveDirection.x, moveDirection.y, 0f);
        move = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0) * move;
        controller.Move(move * moveSpeed * Time.fixedDeltaTime);
    }


}

