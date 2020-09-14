using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private int addCount = 1;
    public int additionalcount;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player")
        {
            col.transform.Find("ShotRocket").GetComponent<RocketScript>().AddRocketCount(addCount);
            Debug.Log("addCount");
            Destroy(gameObject);
        }
    }
}
