using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coinPrefab; // Assign the coin prefab in the Unity Editor
    public float turnSpeed = 90f;
    public float respawnRange = 20f; // Range for respawning coins

    private void OnTriggerEnter(Collider other)
    {
        // Check that the object we collided with is the Ball
        if (other.gameObject.name != "Player")
        {
            return;
        }

        // Add to the player's score
        GameManager.inst.IncrementScore();

        // Destroy this coin object
        Destroy(gameObject);

        // Respawn a new coin
        RespawnCoin();
    }

    void RespawnCoin()
    {
        GameObject newCoin = Instantiate(coinPrefab);
        Vector3 randomPosition = transform.position + Random.insideUnitSphere * respawnRange;
        newCoin.transform.position = new Vector3(randomPosition.x, transform.position.y, randomPosition.z);
    }

    private void Start()
    {
        // Spawn initial coins
        SpawnCoins();
    }

    void SpawnCoins()
    {
        int coinsToSpawn = 30;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(-20f, 20f),
            Random.Range(-4.5f, -4f),
            Random.Range(-19f, 19f)
            );
        return point;
    }

    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
