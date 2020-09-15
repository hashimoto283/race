using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager: MonoBehaviour
{
    public MoveScript moveScript;
    public Text timeText;
    public float time = 60;
    public GameOver gameOver;
    public Text scoreText;
    public Text scoreLabel;
    private bool isGameOver = false;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            StartCoroutine(GameOver());
        }
        if (time < 0) time = 0;
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
        isGameOver = true;
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

