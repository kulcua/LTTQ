using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_spawner : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private GameObject spawner;
	public int second;
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
		yield return new WaitForSeconds(second);
		Vector3 temp = spawner.transform.position;
		temp.y = Random.Range(-0.6f, 2.8f);
		temp.x = Random.Range(-8f, 8f);
		Instantiate(spawner, temp, Quaternion.identity);
		StartCoroutine(Spawnerr());
	}
}
