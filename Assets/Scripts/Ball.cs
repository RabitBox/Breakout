using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------
//--------------------------------------------------
public class Ball : MoveObject
{
#if true       // ボールのヒット時に　角度から射出角を決定する方法
    
    [SerializeField]
    protected float angle_limit_ = 60f;

    // Use this for initialization
    void Start()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
        move_speed_ = default_move_speed_;
        if (rigidbody_) rigidbody_.velocity = new Vector3(-1f, 1f) * move_speed_;
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        // フリッカーに当たった時の反射処理
        if (_collision.transform.tag == "Flicker")
        {
            // バーからボールへのベクトルを取得する
            var _target_vector = (this.transform.position - _collision.transform.position);

            // 反射する角度が正である事確認
            if (_target_vector.y > 0)
            {
                // アングルが制限を超えていないかを確認
                var _deglee = Vector3.Angle(    // 上を0とした角度を取得する
                    Vector3.up,                 // 角度の軸となるベクトル
                    _target_vector);            // 角度に変換したいベクトル

                // 角度が制限範囲内である場合
                if (_deglee < angle_limit_)
                {
                    // 最初に取得したベクトル方向に反射
                    this.rigidbody_.velocity = _target_vector.normalized * move_speed_;
                }
                // 制限を超えていた場合
                else
                {
                    var _radian = angle_limit_ * Mathf.Deg2Rad;     // ラジアン角を算出し
                    var _vector_x = Mathf.Sin(_radian);             // X方向のベクトル値
                    var _vector_y = Mathf.Cos(_radian);             // Y方向のベクトル値を算出
                    if (_target_vector.x < 0f) _vector_x *= -1f;    // ターゲットベクトルから左右の打ち出し方向を求める
                    this.rigidbody_.velocity = new Vector3(_vector_x, _vector_y) * move_speed_;
                }
            }
        }
    }
#else           // ボールのヒット時に　座標から射出角を決定する方法
	[SerializeField]
	float shoot_angle_1_ = 30f;
	[SerializeField]
	float shoot_angle_2_ = 60f;

	float flicker_size_ = 0f;

	// Use this for initialization
	void Start()
	{
		rigidbody_ = GetComponent<Rigidbody2D>();
		move_speed_ = default_move_speed_;
		if (rigidbody_) rigidbody_.velocity = new Vector3(-1f, 1f) * move_speed_;
	}

	private void OnCollisionEnter2D(Collision2D _collision)
	{
		// フリッカーに当たった時の反射処理
		if (_collision.transform.tag == "Flicker")
		{
			if(flicker_size_ == 0f)
			{
				flicker_size_ = _collision.gameObject.GetComponent<RectTransform>().sizeDelta.x / 2;
			}

			var _target_vector = (this.transform.position - _collision.transform.position);

			if (_target_vector.y > 0)
			{
				var _use_angle = ((Mathf.Abs(_target_vector.x) <= (flicker_size_ / 2)) ? shoot_angle_1_ : shoot_angle_2_) * Mathf.Deg2Rad;

				var _vector_x = (_target_vector.x < 0f) ? Mathf.Sin(_use_angle) * -1f : Mathf.Sin(_use_angle);
				var _vector_y = Mathf.Cos(_use_angle);

				this.rigidbody_.velocity = new Vector3(_vector_x, _vector_y) * move_speed_;
			}
		}
	}
#endif
}
