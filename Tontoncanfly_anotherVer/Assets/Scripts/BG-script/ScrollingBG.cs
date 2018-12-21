using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour {

	// Use this for initialization
	Material material;
	Vector2 offset;
	public int xvel;// yvel;
	private void Awake()
	{
		material = GetComponent<Renderer>().material;
	}
	void Start () {
		offset = new Vector2(xvel, 0);
	}
	
	// Update is called once per frame
	void Update () {
		material.mainTextureOffset += offset * Time.deltaTime;
	}
}
