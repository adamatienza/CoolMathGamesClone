using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTilePrefab;   // Reference to the ground tile prefab
    public Transform player;              // Reference to the player
    public int initialTiles = 6;          // Number of tiles to spawn at the start
    public float tileLength = 5f;        // Distance between tiles
    public float gapChance = 0.2f;        // Chance to skip a tile (make a gap)

    private float nextSpawnX = 0f;        // X position of the next tile
    private bool lastTileWasGap = false;  // Used to prevent two gaps in a row

    void Start()
    {
        // Spawn initial ground tiles
        for (int i = 0; i < initialTiles; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        // Check if the player is close enough to spawn a new tile
        if (player.position.x > nextSpawnX - (tileLength * initialTiles / 2))
        {
            SpawnTile();
        }
    }

    void SpawnTile()
    {
        bool makeGap = Random.value < gapChance;

        // Prevent two gaps in a row
        if (lastTileWasGap)
        {
            makeGap = false;
        }

        if (!makeGap)
        {
            Vector3 spawnPosition = new Vector3(nextSpawnX, 0, 0);
            Instantiate(groundTilePrefab, spawnPosition, Quaternion.identity);
            lastTileWasGap = false;
        }
        else
        {
            lastTileWasGap = true;
        }

        nextSpawnX += tileLength;
    }
}
