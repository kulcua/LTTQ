using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shopscene : MonoBehaviour {

	// Use this for initialization
	public void gotoShop()
	{
		PlayerPrefs.SetInt("Money", playerscripts.coinsNumber);
		SceneManager.LoadScene("ShopScene");
	}
}
