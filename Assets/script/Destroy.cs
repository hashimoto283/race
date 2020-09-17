using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    
    /// <summary>
    /// 敵の車以外のオブジェクトがロケットに当たったときの処理
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rocket"))
        {
            // このスクリプトがついているオブジェクトを破壊する
            Destroy(this.gameObject);

            // ぶつかってきたオブジェクトを破壊する
            Destroy(other.gameObject);
        }
    }
}