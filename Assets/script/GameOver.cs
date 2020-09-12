using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    public void Lose()
    {
        this.gameObject.GetComponent<Text>().enabled = true;
    }
}
