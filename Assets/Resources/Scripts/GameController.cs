using UnityEngine;

namespace Resources.Scripts
{
    public class GameController : MonoBehaviour
    {
        public TargetsStateController targetsStateController;
        public MenuController textController;

        public bool IsGameReady { get; set; }
        public bool IsGameStarted { get; set; }
        public bool IsGamePaused { get; set; }
        public bool IsGameOver { get; set; }

        private AudioSource audioSource;
        

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }


        private void Update()
        {
            HandleGameState();
        }

        public void StartGame()
        {
            Debug.Log("StartGame");
            IsGameStarted = true;
            Time.timeScale = 1;
            audioSource.Play();
            
        }

        public void GameOver()
        {
            IsGamePaused = false;
            IsGameReady = false;
            IsGameStarted = false;
            IsGameOver = true;
            Time.timeScale = 0;
        }

        private void HandleGameState()
        {
            if (!IsGameStarted && !IsGameReady && targetsStateController.TargetsFound())
            {
                Debug.Log("ReadyGame");
                IsGameReady = true;
                textController.SetGameReady();
            }

            if (IsGameReady && !IsGameStarted && (Input.touchCount >= 1 || Input.GetMouseButtonDown(0)))
            {
                textController.SetGameStart();
            }

            if (IsGameStarted && !IsGamePaused && !targetsStateController.TargetsFound())
            {
                Debug.Log("PauseGame");
                IsGamePaused = true;
                textController.SetGamePause();
                Time.timeScale = 0;
                audioSource.Pause();
            }

            if (IsGamePaused && targetsStateController.TargetsFound() &&
                (Input.touchCount >= 1 || Input.GetMouseButtonDown(0)))
            {
                Debug.Log("UnPauseGame");
                IsGamePaused = false;
                textController.SetGameStart();
                audioSource.UnPause();
            }
        }

    }
}
