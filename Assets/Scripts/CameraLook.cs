using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    PlayerMovement PMScript;
    [SerializeField] private Transform playerBody;
    [SerializeField] private float mouseSentisivity = 100f;
    private float xRotatino = 0f;

    //[Header("Free Mouse Movement")]
    // You can call this from an other script to let the mouse movement freely room the screen and not let it be stuck and invisible in the middle of the screen.
    // This is because its being used for the player rotation check.
    // This can be used for dialogue, pause menu and other similar things.
    //public bool freeMouseMovement = false;

    // Start is called before the first frame update
    void Start() {
        PMScript = FindAnyObjectByType<PlayerMovement>();
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PMScript.lockMovement) {
            Cursor.lockState = CursorLockMode.Locked;
            float mouseX = Input.GetAxis("Mouse X") * mouseSentisivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSentisivity * Time.deltaTime;

            xRotatino -= mouseY;
            xRotatino = Mathf.Clamp(xRotatino, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotatino, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        } else {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
