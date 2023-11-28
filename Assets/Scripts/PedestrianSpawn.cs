using UnityEngine;

public class PedestrianSpawn : MonoBehaviour
{
    public GameObject walkingObjectPrefab;
    public int numberOfObjects = 20;
    public float moveSpeed = 2f;
    public float spawnRadius = 10f; // Adjust this radius as needed
    public GameObject player; // Reference to the existing player object

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player reference not set in WalkingObjectsSpawner!");
            return;
        }

        SpawnWalkingObjects();
    }

    void SpawnWalkingObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Ensure the spawn positions are within the radius around the player
            Vector3 randomSpawnOffset = Random.insideUnitSphere * spawnRadius;
            Vector3 spawnPosition = player.transform.position + randomSpawnOffset;

            Quaternion spawnRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            GameObject walkingObject = Instantiate(walkingObjectPrefab, spawnPosition, spawnRotation);
            walkingObject.GetComponent<WalkingObject>().SetMoveSpeed(moveSpeed);
        }
    }
}
