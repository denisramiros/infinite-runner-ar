using System.Collections.Generic;
using UnityEngine;

namespace Resources.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private GameController gameController;

        [SerializeField]
        private Transform[] spawnPoints;

        [SerializeField]
        private GameObject[] obstacles;

        [SerializeField]
        private GameObject[] collectibles;

        [SerializeField]
        private float delay = 0.5f;

        [SerializeField]
        [Range(0, 100)]
        private int chanceOfCollectible = 10;

        private float _lastTime;

        private void Update()
        {
            if (gameController.IsGameStarted && !gameController.IsGamePaused && !gameController.IsGameOver &&
                Time.time - _lastTime > delay)
            {
                var pickCollectibleOrObstacle = Random.Range(0, 100);
                Spawn(pickCollectibleOrObstacle < chanceOfCollectible ? collectibles : obstacles);
            }
        }

        private void Spawn(IReadOnlyList<GameObject> objectType)
        {
            _lastTime = Time.time;

            var spawnPosition = RandomSpawnPoint();
            var pickObstacle = Random.Range(0, objectType.Count);
            Instantiate(objectType[pickObstacle], spawnPosition, Quaternion.Euler(0, 180f, 0), transform);
        }

        private Vector3 RandomSpawnPoint()
        {
            var randInt = Random.Range(0, spawnPoints.Length);
            return spawnPoints[randInt].position;
        }
    }
}
