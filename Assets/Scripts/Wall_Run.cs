using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Run : MonoBehaviour
{
    // Orientation for movement
    [Header("Movement")]
    [SerializeField] private Transform orientation;

    // Wall detection parameters
    [Header("Detection")]
    [SerializeField] private float wallDistance = .5f;
    [SerializeField] private float minimumJumpHeight = 1.5f;

    // Wall running parameters
    [Header("Wall Running")]
    [SerializeField] private float wallRunGravity;
    [SerializeField] private float wallRunJumpForce;

    // Camera parameters
    [Header("Camera")]
    [SerializeField] private Camera cam;
    [SerializeField] private float fov;
    [SerializeField] private float wallRunfov;
    [SerializeField] private float wallRunfovTime;
    [SerializeField] private float camTilt;
    [SerializeField] private float camTiltTime;

    // Property to get the tilt value
    public float tilt { get; private set; }

    // Variables to track if there is a wall on the left or right
    private bool wallLeft = false;
    private bool wallRight = false;

    // RaycastHit objects for left and right wall detection
    RaycastHit leftWallHit;
    RaycastHit rightWallHit;

    // Reference to the Rigidbody component
    private Rigidbody rb;

    // Check if the player can wall run (not too close to the ground)
    bool CanWallRun()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minimumJumpHeight);
    }

    // Initialization
    private void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    // Check for walls on the left and right
    void CheckWall()
    {
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallHit, wallDistance);
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, wallDistance);
    }

    // Update is called once per frame
    private void Update()
    {
        // Check for walls
        CheckWall();

        // If conditions allow, start wall run
        if (CanWallRun())
        {
            if (wallLeft)
            {
                StartWallRun();
                Debug.Log("wall running on the left");
            }
            else if (wallRight)
            {
                StartWallRun();
                Debug.Log("wall running on the right");
            }
            else
            {
                // Stop wall run if no wall detected
                StopWallRun();
            }
        }
        else
        {
            // Stop wall run if not meeting conditions
            StopWallRun();
        }
    }

    // Start wall run behavior
    void StartWallRun()
    {
        // Disable gravity during wall run
        rb.useGravity = false;

        // Apply downward force for wall run
        rb.AddForce(Vector3.down * wallRunGravity, ForceMode.Force);

        // Adjust camera field of view during wall run
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, wallRunfov, wallRunfovTime * Time.deltaTime);

        // Tilt the camera based on the wall side
        if (wallLeft)
            tilt = Mathf.Lerp(tilt, -camTilt, camTiltTime * Time.deltaTime);
        else if (wallRight)
            tilt = Mathf.Lerp(tilt, camTilt, camTiltTime * Time.deltaTime);

        // Jump off the wall if Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (wallLeft)
            {
                Vector3 wallRunJumpDirection = transform.up + leftWallHit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(wallRunJumpDirection * wallRunJumpForce * 100, ForceMode.Force);
            }
            else if (wallRight)
            {
                Vector3 wallRunJumpDirection = transform.up + rightWallHit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(wallRunJumpDirection * wallRunJumpForce * 100, ForceMode.Force);
            }
        }
    }

    // Stop wall run behavior
    void StopWallRun()
    {
        // Enable gravity after wall run
        rb.useGravity = true;

        // Reset camera field of view and tilt to default values
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, wallRunfovTime * Time.deltaTime);
        tilt = Mathf.Lerp(tilt, 0, camTiltTime * Time.deltaTime);
    }
}
