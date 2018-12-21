﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabbb : MonoBehaviour {

	// Use this for initialization
	public float speed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_movement();
	}

	void _movement()
	{
		Vector3 temp = transform.position;
		temp.x -= speed * Time.deltaTime;
		transform.position = temp;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "destroy")
			Destroy(gameObject);

	}
}
