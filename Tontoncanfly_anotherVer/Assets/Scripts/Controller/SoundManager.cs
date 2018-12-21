using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	// Use this for initialization
	public static AudioClip jump, die, shoot;
	static AudioSource audioScr;
	private void Start()
	{
		jump = Resources.Load<AudioClip>("Jump");
		die = Resources.Load<AudioClip>("Die");
		shoot = Resources.Load<AudioClip>("Shooting");
		audioScr = GetComponent<AudioSource> ();
	}

	public static void playSound(string clip)
	{
		switch(clip)
		{
			case "Jump":
				{
					audioScr.PlayOneShot(jump);
					break;
				}
			case "Die":
				{
					audioScr.PlayOneShot(die);
					break;
				}
			case "Shooting":
				{
					audioScr.PlayOneShot(shoot);
					break;
				}

		}
	}


}
