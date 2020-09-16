using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager: MonoBehaviour
{
    public Text countdownText;
    private bool isCountdown;
    private float countdownTimer=3;
    public MoveScript moveScript;
    public Text timeText;
    public float time = 60;
    public GameOver gameOver;
    public Text scoreText;
    public Text scoreLabel;
    private bool isGameOver = false;
  
    void Start()
    {
        moveScript.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        countdownTimer -= Time.deltaTime;
        countdownText.text = ((int)countdownTimer).ToString();
        Debug.Log(countdownTimer);
        if(countdownTimer<0 && isCountdown == false)
        {
            Debug.Log(countdownTimer);
            countdownTimer = 0;
            countdownText.gameObject.SetActive(false);
            isCountdown = true;
            moveScript.gameObject.SetActive(true);
            Debug.Log(isCountdown);
        }

        if(isCountdown == false)
        {
            return;
        }
        time -= Time.deltaTime;

        if (time < 0 && isGameOver==false)
        {
            isGameOver = true;
            time = 0;
            StartCoroutine(GameOver());
        }
        //if (time < 0) time = 0;
        //時間が0になるまで制限時間を表示
        timeText.text = ((int)time).ToString();

        if(isGameOver==true)
        {
            if (Input.GetMouseButtonDown(0))
            {
               SceneManager.LoadScene("title");
            }
        }
    }

    IEnumerator GameOver()
    {
        gameOver.Lose();
        Time.timeScale = 0;
        DisplayScore();
        yield break;
    }
    void DisplayScore()
    {
        scoreLabel.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        scoreText.text = moveScript.CalculatRun().ToString("F2") + "M";
    }
    public void AddTime(float amountTime)
    {
        time += amountTime;
        Debug.Log(amountTime);
    }
}

