using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager: MonoBehaviour
{
    //カウントダウン時のテキスト
    public Text countdownText;
    private bool isCountdown;
    //カウントダウンの秒数
    private float countdownTimer = 4;
    public Text GameOverText;
    public MoveScript moveScript;
    public Text timeText;
    public float time = 60;
    public UIManager gameOver;
    public Text scoreText;
    //スコア以外のテキスト
    public Text scoreLabel;
    private bool isGameOver = false;
    public Text bulletcountText;
    public RocketScript rocketScript;

    void Start()
    {
        GameOverText.GetComponent<Text>().enabled = false;
        moveScript.gameObject.SetActive(false);
        //残弾数表示
        DisplayBulletCount();
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
        Lose();
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

        //時間表示をアニメーション化させる
        Sequence sequence = DOTween.Sequence();
        sequence.Append(timeText.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.2f));
        sequence.AppendInterval(0.2f);
        sequence.Append(timeText.transform.DOScale(Vector3.one, 0.2f));
    }

    /// <summary>
    /// GameOver時の処理
    /// </summary>
    public void Lose()
    {
        //GameOver時にテキストを表示
        GameOverText.GetComponent<Text>().enabled = true;
    }
    
    /// <summary>
    /// 残弾数の表示を更新
    /// </summary>
    public void DisplayBulletCount(bool isAnime=false)
    {
        bulletcountText.text = rocketScript.RocketCount.ToString();
        //ロケットカウントが増えた時のみ
        if (isAnime == true)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(bulletcountText.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.2f));
            sequence.AppendInterval(0.2f);
            sequence.Append(bulletcountText.transform.DOScale(Vector3.one, 0.2f));
        }
    }
}

