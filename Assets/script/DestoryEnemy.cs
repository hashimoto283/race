using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryEnemy : MonoBehaviour
{
    public float additionalTime;
    public TimeScript timeScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rocket"))
        {
            // このスクリプトがついているオブジェクトを破壊する（thisは省略が可能）
            Destroy(this.gameObject);
            timeScript.AddTime(additionalTime);
            // ぶつかってきたオブジェクトを破壊する
            Destroy(other.gameObject);
        }
    }
}