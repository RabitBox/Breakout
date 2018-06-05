using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------
// 
//--------------------------------------------------
public class Flicker : MoveObject
{
	//--------------------------------------------------
	// Variables
	private readonly Vector3 kNeutral_	= Vector3.zero;			// ニュートラル
	private readonly Vector3 kLeft_		= new Vector3(-1f, 0f);	// 左
	private readonly Vector3 kRight_	= new Vector3(1f, 0f);  // 右
	//private readonly float move_limit_	= 434f;

	//--------------------------------------------------
	// Functions
	// Use this for initialization
	void Start () {
		rigidbody_ = GetComponent<Rigidbody2D>();
		move_speed_ = default_move_speed_;
		
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody_.velocity = kNeutral_;    // 速度をリセット

		if (Input.GetKey(KeyCode.A))            // Aが押されていたら左へ
		{
			rigidbody_.velocity = kLeft_ * move_speed_;
		}
		else if (Input.GetKey(KeyCode.D))    // Dが押されていたら右へ
		{
			rigidbody_.velocity = kRight_ * move_speed_;
		}
		//Move();
	}

	// 移動処理
	void Move()
	{
		rigidbody_.velocity = kNeutral_;    // 速度をリセット

		if (Input.GetKey(KeyCode.A))            // Aが押されていたら左へ
		{
			rigidbody_.velocity = kLeft_ * move_speed_;
		}
		else if (Input.GetKey(KeyCode.D))    // Dが押されていたら右へ
		{
			rigidbody_.velocity = kRight_ * move_speed_;
		}
	}
}
