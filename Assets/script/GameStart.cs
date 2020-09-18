using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    /// <summary>
    /// ボタンを押した時にレースシーンに遷移
    /// </summary>
    public void OnStartButtonClicked()
    {
      SceneManager.LoadScene("race");
    }
}
