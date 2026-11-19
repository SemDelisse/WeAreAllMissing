using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Scripts")]
    [SerializeField] private CharacterController controller;

    [Header("Lock Movement")]
    // You can call this from an other script to lock the walking movement and to turn off the gravity of the player.
    // This can be used for dialogue, pause menu and other similar things.
    public bool lockMovement = false;

    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (!lockMovement) {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0 && !lockMovement) {
                velocity.y = -2f;
            }

            controller.Move(move * speed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            LockMouse();
        } else {
            controller.Move(move * 0);
            velocity.y += 0;
            controller.Move(velocity * 0);
            UnlockMouse();
        }
    }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
