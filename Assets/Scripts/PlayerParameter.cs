using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameter : MonoBehaviourSingleton<PlayerParameter>
{
	//--------------------------------------------------
	// Variables
	[SerializeField]
	private int default_left_;		// 初期残機
	private int left_player_;		// 残機
	private int score_;				// スコア
}
