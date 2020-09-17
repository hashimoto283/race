using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager: MonoBehaviour
{
    //カウントダウン時のテキスト
    public Text countdownText;
    private bool isCountdown;
    //カウントダウンの秒数
    private float countdownTimer = 4;
    public MoveScript moveScript;
    public Text timeText;
    public float time = 60;
    public GameOver gameOver;
    public Text scoreText;
    //スコア以外のテキスト
    public Text scoreLabel;
    private bool isGameOver = false;
  
    void Start()
    {
        moveScript.gameObject.SetActive(false);
    }

    void Update()
    {
        //カウントダウンのタイマーが減るように
        countdownTimer -= Time.deltaTime;
        countdownText.text = ((int)countdownTimer).ToString();
        Debug.Log(countdownTimer);
        if(countdownTimer<0 && isCountdown == false)
        {
            Debug.Log(countdownTimer);
            countdownTimer = 0;
            //カウントダウンテキストを見えなくする
            countdownText.gameObject.SetActive(false);
            isCountdown = true;
            //プレイヤーが動けるように
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
            //時間切れでゲームオーバー
            isGameOver = true;
            time = 0;
            StartCoroutine(GameOver());
        }
        //時間が0になるまで制限時間を表示
        timeText.text = ((int)time).ToString();

        if(isGameOver==true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1.0f;
                //タイトルに戻れるように
                SceneManager.LoadScene("title");
            }
        }
    }

    /// <summary>
    /// ゲームオーバー時の処理
    /// </summary>
    /// <returns></returns>
    IEnumerator GameOver()
    {
        gameOver.Lose();
        Time.timeScale = 0;
        DisplayScore();
        yield break;
    }

    /// <summary>
    /// スコアの表示
    /// </summary>
    void DisplayScore()
    {
        scoreLabel.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        scoreText.text = moveScript.CalculatRun().ToString("F2") + "M";
    }

    /// <summary>
    /// 時間を追加する処理
    /// </summary>
    /// <param name="amountTime"></param>
    public void AddTime(float amountTime)
    {
        time += amountTime;
        Debug.Log(amountTime);
    }
}

