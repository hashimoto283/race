using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemscript : MonoBehaviour
{
    Rigidbody rb;
    public int RocketCount;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player")
        {
            RocketCount++;
            Debug.Log("s");
            Destroy(gameObject);
        }
    }
}
