using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    public float enemySpeed;
    void Update()
    {
        transform.Translate(new Vector3(0, 0, enemySpeed));
        if(transform.position.z < Camera.main.transform.position.z)
            {
            Destroy(gameObject);
            }
    }
}
