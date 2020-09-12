﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movescript : MonoBehaviour
{
	float speed = 0f;
    public float movePower = 0.2f;
	public float maxSpeed = 100f;
	public float carSpeed = 3f;
	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if (Input.GetKey("up"))
		{
			Accel(); //アクセル
		}
		if (Input.GetKey("right"))
		{
			Right(); //右移動
		}
		if (Input.GetKey("left"))
		{
			Left(); //左移動
		}
		//減速
		speed -= 1f;
		//最低速度
		if (speed < 0)
		{
			speed = 0f;
		}
	}

	void Accel()
	{
		speed += carSpeed;
		speed = Mathf.Clamp(speed, 0, maxSpeed);
		rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
	}

	void Right()
	{
		if (transform.position.x <= 5f)
		{
			Vector3 temp = new Vector3(transform.position.x + movePower, transform.position.y, transform.position.z);
			transform.position = temp;
		}
	}

	public void Left()
	{
		if (transform.position.x >= -5f)
		{
			Vector3 temp = new Vector3(transform.position.x - movePower, transform.position.y, transform.position.z);
			transform.position = temp;
		}
	}
	void OnCollisionEnter(Collision col)
    {
		if(col.gameObject.tag == "Enemy")
        {
			speed = 0;
        }
    }
}