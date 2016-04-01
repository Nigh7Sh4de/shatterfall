using UnityEngine;
using System.Collections;

public class music : MonoBehaviour {

	public static music Instance;

	void Awake()
	{
		if(Instance){
			DestroyImmediate(gameObject);
		}else
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
	}
}
