using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class closeButton : MonoBehaviour {
	//private ModalPanel modalPanel;
	//private DisplayManager displayManager;

	public GameObject modalPanelObject1;
	public GameObject modalPanelObject2;


	private UnityAction myCloseAction;

	void Awake () {
	}

	//  Send to the Modal Panel to set up the Buttons and Functions to call
	public void TestYNC () {
		modalPanelObject1.SetActive (false);
		modalPanelObject2.SetActive (true);
	
	}


}