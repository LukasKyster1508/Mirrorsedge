using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Rotation intensity of the shake
    public float shakeRotationIntensity = 5f;

    // Duration of the shake
    public float shakeDuration = 0.5f;

    // Internal variables
    private Transform playerTransform;
    private Quaternion originalRotation;
    private float shakeTimer = 0f;
    private Vector3 rotationOffset;

    private void Start()
    {
        // Find the player's transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Save the original rotation of the camera
        originalRotation = transform.rotation;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            // Apply random rotations within a range
            float randomX = Random.Range(-1f, 1f) * shakeRotationIntensity;
            float randomY = Random.Range(-1f, 1f) * shakeRotationIntensity;
            float randomZ = Random.Range(-1f, 1f) * shakeRotationIntensity;

            // Accumulate the rotation offset
            rotationOffset = new Vector3(randomX, randomY, randomZ) * shakeRotationIntensity;

            // Apply the rotation offset to the camera's local rotation
            transform.localRotation = originalRotation * Quaternion.Euler(rotationOffset);

            // Reduce the shake timer
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Reset the rotation offset when the shake is complete
            rotationOffset = Vector3.zero;
            transform.localRotation = originalRotation;
        }
    }

    // Call this method to trigger the camera shake
    public void StartShake()
    {
        // Set the shake timer to the specified duration
        shakeTimer = shakeDuration;
    }
}
