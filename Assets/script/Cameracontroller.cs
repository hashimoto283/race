using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("追従する対象")]
    public GameObject targetObj;
    private Vector3 targetPos;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        //自分が操作する車の位置を確認
        targetPos = targetObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //常に見やすい位置にカメラを固定する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;
    }
}
