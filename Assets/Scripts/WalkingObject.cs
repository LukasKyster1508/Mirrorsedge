using UnityEngine;

public class WalkingObject : MonoBehaviour
{
    private float moveSpeed;
    private Vector3 moveDirection;
    private bool isFreakingOut = false;
    private float freakOutStartTime;
    public float freakOutDuration = 10f; // Total duration of the freak-out
    public float shakeIntensity = 0.1f; // Initial intensity of the shaking
    public float shakeIncreaseRate = 0.1f; // Rate at which the shaking intensity increases

    void Start()
    {
        // Set a random initial movement direction
        moveDirection = Random.onUnitSphere;
        moveDirection.y = 0; // Keep the movement in the horizontal plane
    }

    void Update()
    {
        if (isFreakingOut)
        {
            FreakOut();
        }
        else
        {
            Move();
        }
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    void Move()
    {
        // Move in the current direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Change direction at random intervals
        if (Random.Range(0f, 1f) < 0.02f)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        // Set a new random direction
        moveDirection = Random.onUnitSphere;
        moveDirection.y = 0; // Keep the movement in the horizontal plane
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Collision with player detected, start freaking out
            StartFreakOut();
        }
    }

    void StartFreakOut()
    {
        isFreakingOut = true;
        freakOutStartTime = Time.time;
    }

    void FreakOut()
    {
        // Implement the freak-out behavior here
        float elapsedTime = Time.time - freakOutStartTime;

        // Shake the object
        float shakeAmount = Mathf.Lerp(0, shakeIntensity, elapsedTime / freakOutDuration);
        transform.position = new Vector3(
            transform.position.x + Random.Range(-shakeAmount, shakeAmount),
            transform.position.y + Random.Range(-shakeAmount, shakeAmount),
            transform.position.z + Random.Range(-shakeAmount, shakeAmount)
        );

        // Increase the shake intensity over time
        shakeIntensity += shakeIncreaseRate * Time.deltaTime;

        // Destroy the object after the specified duration
        if (elapsedTime >= freakOutDuration)
        {
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        // Spawn a new walking object in the same position
        GameObject newWalkingObject = Instantiate(gameObject, transform.position, transform.rotation);
        newWalkingObject.GetComponent<WalkingObject>().SetMoveSpeed(moveSpeed);

        // Destroy the current object
        Destroy(gameObject);
    }
}
