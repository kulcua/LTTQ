using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	Rigidbody2D rb;
	GameObject cat;
	Vector2 catDirection;
	float timeStamp;
	bool flyToCat;
	int coinsNumber;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (flyToCat)
		{
			catDirection = -(transform.position - cat.transform.position).normalized;
			rb.velocity = new Vector2(catDirection.x, catDirection.y) * 10f * (Time.time / timeStamp );
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals("CoinMagnet"))
		{
			timeStamp = Time.time;
			cat = GameObject.Find("TonTon");
			flyToCat = true;			
		}
		if (col.gameObject.tag=="Player")
		{
			Destroy(gameObject);	
		}
	}

	
}
