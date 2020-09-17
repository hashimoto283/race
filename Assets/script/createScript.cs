using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScript : MonoBehaviour
{
    //走るコース
    public GameObject Ground1;
    public GameObject Ground2;
    //ランダムに生成する敵とアイテムの配列
    public GameObject[] randomObjects;
    int border = 1000;
    float enemyBorder = 100;

    void Update()
    {
        if (transform.position.z > border)
        {
            CreateMap();
        }
        if(transform.position.z > enemyBorder)
        {
            CreateEnemy();
        }
    }

    /// <summary>
    /// コースを無限に生成する処理
    /// </summary>
    void CreateMap()
    {
        //グラウンド１のボーダーを超えた時にグラウンド2の先にグラウンド１を生成
        if (Ground1.transform.position.z < border)
        {
            Debug.Log("Ground1");
            border += 2000;
            Vector3 temp = new Vector3(0, 0.05f, border);
            Ground1.transform.position = temp;
        }
        //グラウンド2のボーダーを超えた時にグラウンド1の先にグラウンド2を生成
        else if (Ground2.transform.position.z < border)
        {
            Debug.Log("Ground2");
            border += 2000;
            Vector3 temp = new Vector3(0, 0.05f, border);
            Ground2.transform.position = temp;
        }
    }

    /// <summary>
    /// ランダムで敵を生成する処理
    /// </summary>
    void CreateEnemy()
    {
        int index = Random. Range(0, randomObjects.Length);
        //コースの横幅で自分の車の100f先でランダムに生成する
        Instantiate(randomObjects[index], new Vector3(Random.Range(-5f,5f), randomObjects[index].transform.position.y, enemyBorder +100f), randomObjects[index].transform.rotation);
        enemyBorder += 100;
    }
}
