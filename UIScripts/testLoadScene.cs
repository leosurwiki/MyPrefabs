using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class testLoadScene : MonoBehaviour {



	public Level level;
	public int id;

	public void onClick ()
	{
//		Debug.Log ("test!");
//		Application.LoadLevel (id);

		if (level.UnLock) {
			Debug.Log("choose "+id);
			Application.LoadLevel (id);
		} else {
			Debug.Log("unlock");
		}

	}




}
