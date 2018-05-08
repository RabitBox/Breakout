using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------
// ブロックマネージャ
// 現在ゲーム内にあるブロックを管理する
//--------------------------------------------------
public class BlockManager : MonoBehaviourSingleton<BlockManager>
{
	//--------------------------------------------------
	// Variables
	private List<GameObject> blocks_;

	//--------------------------------------------------
	// Functions
	// Use this for initialization
	void Start ()
	{
		blocks_ = new List<GameObject>();
	}

	// 有効なブロックが残っているかをチェックする
	public bool CheckEnable()
	{
		foreach (var _object in blocks_)
		{
			if(_object.activeSelf)
			{
				return true;	// 有効なものが残っていた
			}
		}
		return false;			// 残っていなかった
	}

	// リストを空にする
	public void Clean()
	{
		foreach(var _object in blocks_)
		{
			Destroy(_object);	// リストで管理されているオブジェクトをインスペクタから消す
		}

		blocks_.Clear();		// リストを空にする
	}
}
