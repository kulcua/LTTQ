using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTonTon : MonoBehaviour {

    // Use this for initialization
    public GameObject target;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(target!=null)
        transform.position = new Vector2(target.transform.position.x, target.transform.position.y);
	}
}
