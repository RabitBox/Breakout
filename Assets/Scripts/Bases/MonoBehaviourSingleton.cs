using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------
// MonoBehaviourに対応したシングルトン実装基底クラス
// 最初からオブジェクトにアタッチされている事前提の設計
//--------------------------------------------------
public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviourSingleton<T>
{
	private static T instance_;
	public static T Instance
	{
		get
		{
			if (instance_ == null) instance_ = (T)FindObjectOfType(typeof(T));
			return instance_;
		}
	}
}
