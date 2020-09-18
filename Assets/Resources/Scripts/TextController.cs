using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Resources.Scripts
{
    public class TextController : MonoBehaviour
    {
        public GameController gameController;

        public Text getReadyText;
        public Text startText;
        public Text countdownText;
        public Text pausedText;
        public Text gameOverText;
        public Text scoreText;

        public int countdownTime;
        
        private void Start()
        {
            getReadyText.enabled = true;
            startText.enabled = false;
            pausedText.enabled = false;
            countdownText.enabled = false;
            gameOverText.enabled = false;
            scoreText.enabled = false;
        }

        public void SetGameReady()
        {
            getReadyText.enabled = false;
            startText.enabled = true;
            pausedText.enabled = false;
            countdownText.enabled = false;
        }

        public void SetGameStart()
        {
            getReadyText.enabled = false;
            startText.enabled = false;
            pausedText.enabled = false;
            countdownText.enabled = true;
            scoreText.enabled = true;
            StartCoroutine(StartCountdown());
        }

        public void SetGamePause()
        {
            getReadyText.enabled = false;
            startText.enabled = false;
            pausedText.enabled = true;
            countdownText.enabled = false;
        }

        public void SetGameOver()
        {
            getReadyText.enabled = false;
            startText.enabled = false;
            pausedText.enabled = false;
            countdownText.enabled = false;
            gameOverText.enabled = true;
        }

        public void SetScore(float score)
        {
            scoreText.text = "Score: " + score.ToString("F2");
        }

        private IEnumerator StartCountdown()
        {
            var countdown = countdownTime;
            while (countdown > 0)
            {
                countdownText.text = countdown.ToString();
                yield return new WaitForSeconds(1f);
                countdown--;
            }

            yield return new WaitForSeconds(1f);

            gameController.StartGame();
            countdownText.enabled = false;
        }
    }
}
