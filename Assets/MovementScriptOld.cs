using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScriptOld : MonoBehaviour
{
    public CharacterController controller;
    private float speed = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Keyboard keyboard = Keyboard.current;

        float x = keyboard.dKey.ReadValue() - keyboard.aKey.ReadValue();
        float z = keyboard.wKey.ReadValue() - keyboard.sKey.ReadValue();

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

    }
}
