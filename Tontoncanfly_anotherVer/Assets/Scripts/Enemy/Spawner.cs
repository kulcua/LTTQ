using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private GameObject spawner;

	void Start () {
		StartCoroutine(Spawnerr());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator Spawnerr()
	{
		yield return new WaitForSeconds(9);
		Vector3 temp = spawner.transform.position;
		temp.y = Random.Range(-3.29f, -1.9f);
        temp.x = Random.Range(5f, 11f); ;
		Instantiate(spawner, temp, Quaternion.identity);
		StartCoroutine(Spawnerr());
	}
}
