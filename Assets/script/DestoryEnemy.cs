using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryEnemy : MonoBehaviour
{
    //敵破壊時に追加する時間
    public float additionalTime;
    private UIManager UIManager;

    /// <summary>
    /// 敵にロケットが当たった時の処理
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rocket"))
        {
            UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
            UIManager.AddTime(additionalTime);
            // ぶつかってきたオブジェクトを破壊する
            Destroy(other.gameObject);
            // このスクリプトがついているオブジェクトを破壊する
            Destroy(this.gameObject);
        }
    }
}