using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_control : MonoBehaviour {

	// Use this for initialization
	
	public float moveSpeed = 3f;
	Transform left, right;
	Vector3 localScale;
	bool movingRight = true;
	Rigidbody2D rb;
	public GameObject blood;
    private shake shakee;

    void Start () {
		localScale = transform.localScale;
		rb = GetComponent<Rigidbody2D>();
		right = GameObject.Find("right").GetComponent<Transform>();
		left = GameObject.Find("left").GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > right.position.x)
			movingRight =false;
		if (transform.position.x < left.position.x)
			movingRight = true;
		if (movingRight)
			moveRight();
		else
			moveLeft();
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

	



}
