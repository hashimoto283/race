using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timescript : MonoBehaviour
{
    public Text timeText;
    public float time = 60;
    public GameOver gameOver;


    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            StartCoroutine("GameOver");
        }
        if (time < 0) time = 0;
        //時間が0になるまで制限時間を表示
        timeText.text = ((int)time).ToString();
    }
    void GameOver()
    {
        gameOver.SendMessage("Lose");
        Time.timeScale = 0;
        if (Input.GetMouseButtonDown(0))
        {
        }
    }
}

