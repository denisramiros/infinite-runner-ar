using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Resources.Scripts
{
    public class MenuController : MonoBehaviour
    {
        public GameController gameController;
        public GameObject canvasGameObject;
        public int countdownTime;

        [Header("Get ready")]
        public GameObject gettingReadyPanel;

        [Header("Start")]
        public GameObject startPanel;

        [Header("In Game")]
        public GameObject gamePanel;
        public Text countdownText;
        public Text inGameScoreText;

        [Header("Pause")]
        public GameObject pausePanel;

        [Header("Game over")]
        public GameObject gameOverPanel;
        public Text gameOverScoreText;
        
        float score;


        private void Start()
        {
            //disable all menu panels at the beginning
            foreach (Transform t in canvasGameObject.transform)
            {
                t.gameObject.SetActive(false);
            }
            gettingReadyPanel.SetActive(true);
        }


        public void SetGameReady()
        {
            gettingReadyPanel.SetActive(false);
            startPanel.SetActive(true);
        }

        public void SetGameStart()
        {
            pausePanel.SetActive(false);
            startPanel.SetActive(false);
            gamePanel.SetActive(true);
            StartCoroutine(StartCountdown());
        }

        public void SetGamePause()
        {
            gamePanel.SetActive(false);
            pausePanel.SetActive(true);
        }

        public void SetGameOver()
        {
            gamePanel.SetActive(false);
            gameOverPanel.SetActive(true);
            gameOverScoreText.text = score.ToString("F2");
        }

        public void SetScore(float score)
        {
            this.score = score;
            inGameScoreText.text = score.ToString("F2");
        }

        //called when clicking anywhere over GameOver menu panel
        public void Restart()
        {
            SceneManager.LoadScene("Game");
        }

        private IEnumerator StartCountdown()
        {
            countdownText.gameObject.SetActive(true);
            var countdown = countdownTime;
            while (countdown > 0)
            {
                countdownText.text = countdown.ToString();
                yield return new WaitForSeconds(1f);
                countdown--;
            }

            yield return new WaitForSeconds(1f);

            countdownText.gameObject.SetActive(false);
            gameController.StartGame();
           
        }
    }
}
