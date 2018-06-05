using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//--------------------------------------------------
// スコア・残機を表示するUIの処理を行うクラス
//--------------------------------------------------
public class UIText : MonoBehaviour
{
	//--------------------------------------------------
	// Variables
	private Text target_text_;	// uGUIのコンポーネント
	[SerializeField]
	private string base_text_;  // 表示するベースとなるテキスト

	//--------------------------------------------------
	// Methods
	// Use this for initialization
	void Start () {
		target_text_ = this.GetComponent<Text>();
	}

	// 表示するUIテキストを更新する
	// argument->_value(-1)	: テキスト表示したい数値
	public void UpdateText(int _value = -1)
	{
		target_text_.text = base_text_;								// ベースとなるテキストを代入
		if (_value != -1) target_text_.text += _value.ToString();	// 数値を加算で追加
	}
}
