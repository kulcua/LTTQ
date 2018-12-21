using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitbutton : MonoBehaviour {

	// Use this for initialization
public void exit()
	{
		Application.Quit();
		Debug.Log("quit");
	}
}
