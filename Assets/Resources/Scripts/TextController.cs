using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public GameController gameController;

    public Text getReadyText;
    public Text startText;
    public Text countdownText;
    public Text pausedText;
    public Text gameOverText;

    public int countdownTime;

    // Start is called before the first frame update
    void Start()
    {
        getReadyText.enabled = true;
        startText.enabled = false;
        pausedText.enabled = false;
        countdownText.enabled = false;
        gameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private IEnumerator StartCountdown()
    {
        int countdown = countdownTime;
        while(countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;
        }

        yield return new WaitForSeconds(1f);

        gameController.StartGame();
        countdownText.enabled = false;
        
        yield break;


    }
}
