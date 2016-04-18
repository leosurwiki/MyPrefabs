using UnityEngine;
using System.Collections;

public class SceneEvent : MonoBehaviour {

	//当前关卡
	public Level level;

	public void OnClick()
	{
		string s = level.name;
		string s1 = s.Substring (0, s.Length - 1);
		string s2 = s.Substring (s.Length - 1);
		int temp=int.Parse (s2) + 1;
		Debug.Log (s1+temp);
		LevelSystem.SetLevels (s1+temp, true);


	}
}
