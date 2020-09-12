using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    [Header("追従する対象")]
    public GameObject targetObj;
    private Vector3 targetPos;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        targetPos = targetObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;
    }
}
