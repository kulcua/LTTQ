using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_boss : MonoBehaviour {

	// Use this for initialization
	float moveSpeed = 7f;

	Rigidbody2D rb;
	playerscripts target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindObjectOfType<playerscripts>();
		if (target != null)
		{
			moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		} 
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		Destroy(gameObject, 1f);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		Destroy(gameObject);		
	}

}
