using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour {

	//int isRifleSold = 0;
	public static int changeB;
	public Text moneyAmountText;
	public Text bulletPrice1;
	public Text bulletPrice2;
	public Text bulletPrice3;
	public Button bt1;
	public Button bt2;
	public Button bt3;


	//public GameObject buyButton;

	// Use this for initialization
	void Start()
	{
		//buyButton.SetActive(false);

	}

	// Update is called once per frame
	void Update()
	{
		moneyAmountText.text = "Money: " + playerscripts.coinsNumber + "$";
		if (playerscripts.coinsNumber < 3)
		{
			bt1.interactable = false;
			bt2.interactable = false;
			bt3.interactable = false;
		}
		else if(playerscripts.coinsNumber==3)
		{
			bt1.interactable = true;
			bt2.interactable = false;
			bt3.interactable = false;
		}
		else if(playerscripts.coinsNumber == 4)
		{
			bt1.interactable = true;
			bt2.interactable = true;
			bt3.interactable = false;
		}
		else if (playerscripts.coinsNumber >= 5)
		{
			bt1.interactable = true;
			bt2.interactable = true;
			bt3.interactable = true;
		}
		if (bulletPrice1.text == "Sold!")
		{
			bt2.interactable = false;
			bt3.interactable = false;
		}
		if (bulletPrice2.text == "Sold!")
		{
			bt1.interactable = false;
			bt3.interactable = false;
		}
		if (bulletPrice3.text == "Sold!")
		{
			bt2.interactable = false;
			bt1.interactable = false;
		}
	}

	public void buyBullet1()
	{

		if (playerscripts.coinsNumber >= 3)
		{
			playerscripts.coinsNumber -= 3;
			//PlayerPrefs.SetInt("IsRifleSold", 1);
			bulletPrice1.text = "Sold!";
			playerscripts.switchWeapon = 1;
			
		}
		else
			bulletPrice1.text = "Can't buy!";
		
	}

	public void buyBullet2()
	{
		if (playerscripts.coinsNumber >= 4)
		{
			playerscripts.coinsNumber -= 4;
			//PlayerPrefs.SetInt("IsRifleSold", 1);
			bulletPrice2.text = "Sold!";
			playerscripts.switchWeapon = 2;
			
		}
		else
			bulletPrice2.text = "Can't buy!";

	}

	public void buyBullet3()
	{
		if (playerscripts.coinsNumber >= 5)
		{
			playerscripts.coinsNumber -= 5;
			//PlayerPrefs.SetInt("IsRifleSold", 1);
			bulletPrice3.text = "Sold!";
			playerscripts.switchWeapon = 3;
			
			//buyButton.SetActive(false);			
		}
		else
			bulletPrice3.text = "Can't buy!";

	}

	public void exitShop()
	{
		PlayerPrefs.SetInt("Money", playerscripts.coinsNumber);
		SceneManager.LoadScene("SampleScene");
		
	}
	//public void gotoShop()
	//{
	//	PlayerPrefs.SetInt("Money", playerscripts.coinsNumber);
	//	SceneManager.LoadScene("ShopScene");
	//}
}
