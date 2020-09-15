using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryEnemy : MonoBehaviour
{
    public float additionalTime;
    private UIManager UIManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rocket"))
        {
            UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
            UIManager.AddTime(additionalTime);
            // ぶつかってきたオブジェクトを破壊する
            Destroy(other.gameObject);
            // このスクリプトがついているオブジェクトを破壊する（thisは省略が可能）
            Destroy(this.gameObject);
        }
    }
}