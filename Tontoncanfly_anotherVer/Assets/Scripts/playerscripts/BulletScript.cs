using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	public float velX = 5f;
	//float velY = 0f;
	Rigidbody2D rb;
    public float speed = 20f;
    private shake shakee;
    public GameObject blood;
    private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
        shakee = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<shake>();
	}
	private void Update()
	{
        if(velX>0)
        rb.velocity =transform.right* speed;
        else
        rb.velocity =- transform.right* speed;
        Destroy(gameObject, 3f);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("crab")|| collision.gameObject.tag.Equals("flyingCrab")|| collision.gameObject.tag == "yellowCrab" || collision.gameObject.tag.Equals("boss"))
        {
            shakee.camShake();
			ScoreScript.scorevalue += 10;
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
