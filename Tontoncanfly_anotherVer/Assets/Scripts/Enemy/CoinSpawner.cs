using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

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
		yield return new WaitForSeconds(6.5f);
		Vector3 temp = spawner.transform.position;
		temp.y = Random.Range(1f, 2.8f);
		temp.x = Random.Range(9f, 11f);
		Instantiate(spawner, temp, Quaternion.identity);
		StartCoroutine(Spawnerr());
	}
}
