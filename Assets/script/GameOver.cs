using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Text>().enabled = false;
    }

    public void Lose()
    {
        //GameOver時にテキストを表示
        this.gameObject.GetComponent<Text>().enabled = true;
    }
}
