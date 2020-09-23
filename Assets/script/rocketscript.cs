using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public GameObject RocketPrefab;
    //ロケットのスピード
    public float shotSpeed;
    //ロケットの次弾装填時間
    private float timeBetweenShot=1f;
    public float timer;
    //ロケットの撃てるカウント
    public int RocketCount;
    public UIManager uiManager;

    /// <summary>
    ///　ロケットカウントを増やす処理
    /// </summary>
    /// <param name="amount"></param>
    public void AddRocketCount(int amount)
    {
        Debug.Log(amount);
        RocketCount += amount;
        //残弾数を表示
        uiManager.DisplayBulletCount(true);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timer > timeBetweenShot)
        {　
            //ロケットカウントがあるとき
            if (RocketCount > 0)
            {
                //連射出来ないようにタイマーリセット
                timer = 0.0f;
                //ロケット生成
                GameObject Rocket = Instantiate(RocketPrefab, transform.position, RocketPrefab.transform.rotation);
                Rigidbody RocketRb = Rocket.GetComponent<Rigidbody>();
             　//まっすぐ飛ぶように力を加える
                RocketRb.AddForce(transform.forward * shotSpeed);
                //3秒後に破壊
                Destroy(Rocket, 3.0f);
                //ロケットカウントも減る
                RocketCount--;
                //残弾数の表示を更新
                uiManager.DisplayBulletCount();
            }
        }
    }
}
