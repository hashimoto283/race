using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createScript : MonoBehaviour
{
    //public GameObject Enemy;
    //public GameObject barricade;
    public GameObject Ground1;
    public GameObject Ground2;
    public GameObject[] randomObjects;
    int border = 1000;
    float enemyBorder = 150;

    void Update()
    {
        if (transform.position.z > border)
        {
            CreateMap();
        }
        if(transform.position.z > enemyBorder)
        {
            CreateEnemy();
        }
    }
    void CreateMap()
    {
        if (Ground1.transform.position.z < border)
        {
            Debug.Log("Ground1");
            border += 2000;
            Vector3 temp = new Vector3(0, 0.05f, border);
            Ground1.transform.position = temp;
        }
        else if (Ground2.transform.position.z < border)
        {
            Debug.Log("Ground2");
            border += 2000;
            Vector3 temp = new Vector3(0, 0.05f, border);
            Ground2.transform.position = temp;
        }
    }
    void CreateEnemy()
    {
        int index = Random. Range(0, randomObjects.Length);
        Instantiate(randomObjects[index], new Vector3(Random.Range(-5f,5f), 0f, enemyBorder +150f), randomObjects[index].transform.rotation);
        enemyBorder += 150;
    }
}
