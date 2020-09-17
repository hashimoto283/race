using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    
    //敵のスピード
    public float enemySpeed;
    void Update()
    {
        //Z軸（プレイヤーと同じ）に進む
        transform.Translate(new Vector3(0, 0, enemySpeed));
        //プレイヤーよりZ軸が追い抜かされると破壊されるように
        if(transform.position.z < Camera.main.transform.position.z)
        {
          Destroy(gameObject);
        }
    }
}
