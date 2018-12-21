using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour {

	// Use thisfor initialization
	public Animator camAnim;
    
    public void camShake()
	{
		camAnim.SetTrigger("shake");
            
    }

}
