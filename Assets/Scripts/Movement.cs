using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Player height for ground detection
    float playerHeight = 2f;

    // Reference to the CameraShake script
    public CameraShake cameraShake;

    // Reference to the player's orientation
    [SerializeField] Transform orientation;

    // Movement parameters
    [Header("Movement")]
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float airMultiplier = 0.4f;
    float movementMultiplier = 10f;

    // Sprinting parameters
    [Header("Sprinting")]
    [SerializeField] float walkSpeed = 4f;
    [SerializeField] float sprintSpeed = 6f;
    [SerializeField] float acceleration = 10f;

    // Jumping parameters
    [Header("Jumping")]
    public float jumpForce = 5f;

    // Keybindings
    [Header("Keybinds")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;

    // Drag parameters
    [Header("Drag")]
    [SerializeField] float groundDrag = 6f;
    [SerializeField] float airDrag = 2f;

    // Movement input variables
    float horizontalMovement;
    float verticalMovement;

    // Ground detection parameters
    [Header("Ground Detection")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundDistance = 0.2f;
    public bool isGrounded { get; private set; }
    private bool isPlayerFrozen = false;
    private bool wasGroundedLastFrame = false;

    // Movement vectors
    Vector3 moveDirection;
    Vector3 slopeMoveDirection;

    // Rigidbody component
    Rigidbody rb;

    // RaycastHit for detecting slopes
    RaycastHit slopeHit;

    // Check if the player is on a slope
    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f))
        {
            if (slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    // Initialization
    private void Start()
    {
        // Get Rigidbody component and freeze rotation
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Input handling and other non-physics updates
    private void Update()
    {
        // Save the grounded state from the last frame
        wasGroundedLastFrame = isGrounded;

        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Handle player input
        MyInput();

        // Adjust drag based on grounded state
        ControlDrag();

        // Adjust speed based on input and grounded state
        ControlSpeed();

        // Trigger camera shake when the player lands
        if (isGrounded && !wasGroundedLastFrame)
        {
            print(wasGroundedLastFrame);
            cameraShake.StartShake();
        }

        // Check for jump input and perform jump
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }

        // Project movement direction onto the slope for better movement on slopes
        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);
    }

    // Handle player input
    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        // Calculate the movement direction based on orientation
        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
    }

    // Handle player jump
    void Jump()
    {
        if (isGrounded)
        {
            // Reset vertical velocity and apply jump force
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Adjust player speed based on input and sprinting state
    void ControlSpeed()
    {
        if (Input.GetKey(sprintKey) && isGrounded)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, sprintSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
        }
    }

    // Adjust player drag based on grounded state
    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    // Physics updates
    private void FixedUpdate()
    {
        // Move the player based on input and physics
        MovePlayer();
    }

    // Move the player based on input and physics
    void MovePlayer()
    {
        // If there is no movement input and the player is grounded
        if (horizontalMovement == 0f && verticalMovement == 0f)
        {
            if (!isPlayerFrozen && isGrounded)
            {
                // No input, freeze the player's position
                rb.velocity = Vector3.zero;
                isPlayerFrozen = true;
            }
        }
        else
        {
            // Movement input detected, unfreeze the player
            isPlayerFrozen = false;

            // Apply forces based on the player's state (grounded, on slope, or in the air)
            if (isGrounded && !OnSlope())
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
            }
            else if (isGrounded && OnSlope())
            {
                rb.AddForce(slopeMoveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
            }
            else if (!isGrounded)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
            }
        }
    }
}
