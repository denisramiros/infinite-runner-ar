using System;
using UnityEngine;

namespace Resources.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        
        [SerializeField]
        private GameController gameController;

        [SerializeField]
        private MenuController textController;

        private float score;
        private int runHash = Animator.StringToHash("Run");
        private int jumpHash = Animator.StringToHash("Jump");

        private void Start()
        {
            animator = GetComponent<Animator>();
            score = 0;
        }

        private void Update()
        {
            if (gameController.IsGameStarted && !gameController.IsGamePaused && !gameController.IsGameOver)
            {
                score += Time.deltaTime;
                textController.SetScore(score);
                animator.SetBool(runHash, true);
            }
            else
            {
                animator.SetBool(runHash, false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Collectible"))
            {
                score += 10;
                animator.SetTrigger(jumpHash);
                textController.SetScore(score);
                Destroy(other.gameObject);
            }
            else if (other.gameObject.CompareTag("Obstacle"))
            {
                animator.SetBool(runHash, false);
                gameController.GameOver();
            }
        }
    }
}
