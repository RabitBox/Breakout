using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------
// 移動処理を行うオブジェクトの基底クラス
//--------------------------------------------------
public class MoveObject : MonoBehaviour
{
	//--------------------------------------------------
	// Variables
	[SerializeField]
	protected float default_move_speed_;    // 初期移動速度
	[SerializeField]
	protected float move_speed_;            // 移動速度

	protected Rigidbody2D rigidbody_;		// リジッドボディ
}
