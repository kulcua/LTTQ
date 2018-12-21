using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_control : MonoBehaviour {

	// Use this for initialization
	public GameObject enemy;
	float ranX;
	Vector2 wheretoSpawn;
	public float spawnRate = 2f;
	float nextSpawn = 0.0f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	if(Time.time>nextSpawn)
		{
			nextSpawn = Time.time + spawnRate;
			ranX = Random.Range(-8.4f, 8.4f);
			wheretoSpawn = new Vector2(ranX, transform.position.y);
			Instantiate(enemy, wheretoSpawn, Quaternion.identity);

		}
	}
}
