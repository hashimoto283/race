using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
	private float startPos;
	float speed = 0f;
    public float movePower = 0.2f;
	public float maxSpeed = 100f;
	public float carSpeed = 3f;
	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		startPos = transform.position.z;
		Debug.Log(startPos);
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
		//アクセル踏まないと減速
		speed -= 1f;
		//最低速度
		if (speed < 0)
		{
			speed = 0f;
		}
	}

	/// <summary>
	/// ↑を押した時の処理
	/// </summary>
	void Accel()
	{　
		speed += carSpeed;
		//制限時速をmaxSpeedまでに限定
		speed = Mathf.Clamp(speed, 0, maxSpeed);
		//speedの力を加える方向
		rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
	}

	/// <summary>
	/// →を押した時の処理
	/// </summary>
	void Right()
	{
		if (transform.position.x <= 5f)
		{　　//プレイヤーの現在地からmovePowerを加えて→に移動する
			Vector3 temp = new Vector3(transform.position.x + movePower, transform.position.y, transform.position.z);
			transform.position = temp;
		}
	}

	/// <summary>
	/// ←を押した時の処理
	/// </summary>
	public void Left()
	{
		if (transform.position.x >= -5f)
		{
			//プレイヤーの現在地からmovePowerで←に移動する
			Vector3 temp = new Vector3(transform.position.x - movePower, transform.position.y, transform.position.z);
			transform.position = temp;
		}
	}

	/// <summary>
	/// 敵に触れた時の処理
	/// </summary>
	/// <param name="col"></param>
	void OnCollisionEnter(Collision col)
    {
		if(col.gameObject.tag == "Enemy")
        {
			//敵に触れた時スピードを０に
			speed = 0;
        }
    }

	/// <summary>
	/// 走った距離を計測する処理
	/// </summary>
	/// <returns></returns>
    public float CalculatRun()
    {
		//プレイヤーの現在地からスタートポジションを引く
		return transform.position.z - startPos;
    }
}