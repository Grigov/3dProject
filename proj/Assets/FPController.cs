using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class FPController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private Transform cameraPivot;

    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = -9.8f;

    private CharacterController controller;
    private float verticalSpeed;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        HandleLook();
        HandleMovement();
    }
    private void HandleLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        Debug.Log(mouseX + " " + mouseY);
        transform.Rotate(Vector3.up * mouseX);
        float verticalRotation = -mouseY;
        float curentCameraAngel = cameraPivot.localEulerAngles.x;
        float newAngel = curentCameraAngel + verticalRotation;
        if (newAngel > 180) newAngel -= 360;
        newAngel = Mathf.Clamp(newAngel, -90, 90);
        cameraPivot.localEulerAngles = new Vector3(newAngel, 0, 0);
    }

    private void HandleMovement()
    {
        float speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        Vector3 move = transform.TransformDirection(input) * speed;

        if (controller.isGrounded && verticalSpeed < 0)
        {
            verticalSpeed = -2f;
        }
        verticalSpeed += gravity * Time.deltaTime;
        move.y = verticalSpeed;

        controller.Move(move * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            verticalSpeed = jumpForce;
        }

    }
}
