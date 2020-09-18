using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("追従する対象")]
    public GameObject targetObj;
    private Vector3 targetPos;

    void Start()
    {
        //プレイヤーの位置情報を取得
        targetPos = targetObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーとの距離を計算し、カメラとプレイヤーとは常に一定を保った上で追従させる 
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;
    }
}
