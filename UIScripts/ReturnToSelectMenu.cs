using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ReturnToSelectMenu : MonoBehaviour {

	public void onClick(int id)
	{
		Debug.Log (Application.levelCount-1);
		Application.LoadLevel (Application.levelCount-1);
	}
}
