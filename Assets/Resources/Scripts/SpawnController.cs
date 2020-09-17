using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameController gameController;

    public GameObject[] obstaclesPrefabs;
    public GameObject[] collectiblesPrefabs;
    public float obstaclesSpeed = 2f;
    public float chanceCollectible = 0;

    public float spawnRate = 2f;
    private float nextSpawn = 0f;

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    private float[] xSpawnLines;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.IsGameStarted && !gameController.IsGamePaused && !gameController.IsGameOver && Time.time > nextSpawn)
        {
            CalculateLines();

            float pick = Random.Range(0, 100);
            GameObject prefab;
            Vector3 spawnPoint = new Vector3(xSpawnLines[Random.Range(0, xSpawnLines.Length)], transform.localPosition.y, Random.Range(zMin, zMax));
            if (pick < chanceCollectible)
            {
                prefab = collectiblesPrefabs[Random.Range(0, collectiblesPrefabs.Length)];
            }
            else
            {
                prefab = obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)];
            }

            GameObject clone = Instantiate(prefab);
            clone.transform.parent = transform;
            clone.transform.localPosition = spawnPoint;
            clone.transform.localRotation = Quaternion.identity;
            clone.GetComponent<ObstacleController>().speed = obstaclesSpeed;

            nextSpawn = Time.time + spawnRate;
        }
    }

    private void CalculateLines()
    {
        xSpawnLines = new float[3];
        xSpawnLines[0] = (xMin + Mathf.Abs(xMin - xMax) * 1 / 6);
        xSpawnLines[1] = (xMin + Mathf.Abs(xMin - xMax) * 1 / 2);
        xSpawnLines[2] = (xMin + Mathf.Abs(xMin - xMax) * 5 / 6);
    }
}
