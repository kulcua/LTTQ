using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour {

	// Use this for initialization
	// Use this for initialization
	[SerializeField]
	private GameObject spawner;

	void Start()
	{
		StartCoroutine(Spawnerr());
	}

	// Update is called once per frame
	void Update()
	{

	}
	IEnumerator Spawnerr()
	{
		yield return new WaitForSeconds(3);
		Vector3 temp = spawner.transform.position;
		temp.y = -2.757863f;
		temp.x = 11f;
		Instantiate(spawner, temp, Quaternion.identity);
		StartCoroutine(Spawnerr());
	}
}
