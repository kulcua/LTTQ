using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	// Use this for initialization
	public float moveSpeed = 3f;
	Transform left, right;
	Vector3 localScale;
	bool movingRight = true;
	Rigidbody2D rb;
	public GameObject blood;
	private shake shakee;
	[SerializeField]
	public  GameObject bullet;

	float fireRate;
	float nextFire;

	void Start()
	{
		localScale = transform.localScale;
		rb = GetComponent<Rigidbody2D>();
		right = GameObject.Find("right").GetComponent<Transform>();
		left = GameObject.Find("left").GetComponent<Transform>();
		fireRate = 1f;
		nextFire = Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.x > right.position.x)
			movingRight = false;
		if (transform.position.x < left.position.x)
			movingRight = true;
		if (movingRight)
			moveRight();
		else
			moveLeft();
		CheckIfTimeToFire();
	}

	void moveRight()
	{
		movingRight = true;
		localScale.x = 1;
		transform.localScale = localScale;
		rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
	}

	void moveLeft()
	{
		movingRight = false;
		localScale.x = -1;
		transform.localScale = localScale;
		rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
	}

	void CheckIfTimeToFire()
	{
		if (Time.time > nextFire)
		{
			Instantiate(bullet, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;
		}

	}



}
