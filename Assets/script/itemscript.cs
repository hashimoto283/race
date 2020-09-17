using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    //アイテムボックスを触れると撃てるロケットのカウント
    private int addCount = 1;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 触れた時にロケットを撃てるようにする
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionEnter(Collision col)
    {
        //プレイヤーが当たったとき
        if (col.gameObject.tag == "Player")
        {
   　　　　 //AddRocketCount呼び出し
            col.transform.Find("ShotRocket").GetComponent<RocketScript>().AddRocketCount(addCount);
            Debug.Log("addCount");
            //取ったらゲームオブジェクトを破壊する
            Destroy(gameObject);
        }
    }
}
