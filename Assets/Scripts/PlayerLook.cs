using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // Reference to the Wall_Run script for accessing tilt information
    [Header("References")]
    [SerializeField] Wall_Run wallRun;

    // Sensitivity for mouse movement on the X and Y axes
    [SerializeField] private float sensX = 100f;
    [SerializeField] private float sensY = 100f;

    // Reference to the camera and orientation transforms
    [SerializeField] Transform cam = null;
    [SerializeField] Transform orientation = null;

    // Variables to store mouse input
    float mouseX;
    float mouseY;

    // Multiplier for mouse sensitivity
    float multiplier = 0.01f;

    // Variables to store rotation values
    float xRotation;
    float yRotation;

    // Initialization
    private void Start()
    {
        // Lock the cursor and hide it at the start of the game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // Get mouse input
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        // Update rotation values based on mouse input and sensitivity
        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        // Clamp the vertical rotation to avoid flipping
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply rotations to the camera and orientation transforms
        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, wallRun.tilt);
        orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
