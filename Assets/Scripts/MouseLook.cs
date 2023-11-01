using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    PlayerInputManager inputManager;
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        inputManager = PlayerInputManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = inputManager.GetPlayerMouse().x * mouseSensitivity * Time.deltaTime;
        float mouseY = inputManager.GetPlayerMouse().y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
