using System;
using UnityEngine;

namespace Resources.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private GameController gameController;

        [SerializeField]
        private MenuController textController;

        private float score;

        private void Start()
        {
            score = 0;
        }

        private void Update()
        {
            if (gameController.IsGameStarted && !gameController.IsGamePaused && !gameController.IsGameOver)
            {
                score += Time.deltaTime;
                textController.SetScore(score);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Collectible"))
            {
                score += 10;
                textController.SetScore(score);
                Destroy(other.gameObject);
            }
            else if (other.gameObject.CompareTag("Obstacle"))
            {
                gameController.GameOver();
            }
        }
    }
}
