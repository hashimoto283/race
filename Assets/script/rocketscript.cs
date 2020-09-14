using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public GameObject RocketPrefab;
    public float shotSpeed;
    private float timeBetweenShot=1f;
    public float timer;
    public int RocketCount;
    public ItemScript ItemScript;
  
    public void AddRocketCount(int amount)
    {
        Debug.Log(amount);
        RocketCount += amount;
    }

   
    public void Rocket(int count)
    {
        RocketCount += count;
        Debug.Log(count);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timer > timeBetweenShot)
        {
            if (RocketCount > 0)
            {
                timer = 0.0f;
                GameObject Rocket = Instantiate(RocketPrefab, transform.position, RocketPrefab.transform.rotation);
                Rigidbody RocketRb = Rocket.GetComponent<Rigidbody>();
                RocketRb.AddForce(transform.forward * shotSpeed);
                Destroy(Rocket, 3.0f);
                RocketCount--;
                Debug.Log("g");
            }
        }
    }
}
