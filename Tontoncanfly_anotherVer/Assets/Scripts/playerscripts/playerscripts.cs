using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerscripts : MonoBehaviour
{

	public float moveSpeed = 3f;
	float velX;
	float velY;
	bool facingRight = true;
	Rigidbody2D myRigid;
	Animator anim;
	bool isRunning = false;
	public float jumpForce = 500f;
	public LayerMask theGround;
	public Transform groundCheck;
	bool onGround = false;
	public GameObject bullettoRight,bullettoRight1,bullettoRight2,bullettoRight3, gameOvertext, restartBt, blood,shopBt,panel;
	Vector2 bulletPos;
	public float fireRate = 0.5f;
	float nextFire = 0.0f;
	public static int switchWeapon =0;

	public GameObject heart1, heart2, heart3;
	public int playerHealth = 3;
	int playerLayer, enemyPlayer;
	bool coroutineAllowed = true;
	Color color;
	Renderer rend;

	[SerializeField]
	Text coinCounter;

	[SerializeField]
	GameObject coinMagnet;
	public static playerscripts instance;
	public static  int coinsNumber;

	private void Start()
	{
		myRigid = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		gameOvertext.SetActive(false);
		restartBt.SetActive(false);
		shopBt.SetActive(false);
		panel.SetActive(false);
		playerLayer = this.gameObject.layer;
		enemyPlayer = LayerMask.NameToLayer("enemy");
		Physics2D.IgnoreLayerCollision(playerLayer, enemyPlayer, false);
		heart1 = GameObject.Find("heart1");
		heart2 = GameObject.Find("heart2");
		heart3 = GameObject.Find("heart3");
		heart1.gameObject.SetActive(true);
		heart2.gameObject.SetActive(true);
		heart3.gameObject.SetActive(true);
		rend = GetComponent<Renderer>();
		color = rend.material.color;
	}

	private void Update()
	{
		velX = Input.GetAxisRaw("Horizontal");
		coinCounter.text = coinsNumber.ToString();
		coinMagnet.transform.position = new Vector2(transform.position.x, transform.position.y);
		velY = myRigid.velocity.y;
		myRigid.velocity = new Vector2(velX * moveSpeed, velY);
		if (velX != 0)
			isRunning = true;
		else
			isRunning = false;
		anim.SetBool("isRunning", isRunning);
		onGround = Physics2D.Linecast(transform.position, groundCheck.position, theGround);
		anim.SetBool("onGround", onGround);
		if (onGround && Input.GetKey(KeyCode.UpArrow))
		{
			SoundManager.playSound("Jump");
			velY = 0f;
			myRigid.AddForce(new Vector2(0, jumpForce));

		}

		if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
		{

			SoundManager.playSound("Shooting");
			nextFire = Time.time + fireRate;
			fire();
		}
	}

	private void LateUpdate()
	{
		Vector3 localScale = transform.localScale;
		if (velX > 0)
			facingRight = true;
		else if (velX < 0)
			facingRight = false;
		if (facingRight && localScale.x < 0 || !facingRight && localScale.x > 0)
			localScale.x *= -1;
		transform.localScale = localScale;
	}

	void fire()
	{
		bulletPos = transform.position;
		if (facingRight)
		{
			bulletPos += new Vector2(+1f, -0.43f);
			switch(switchWeapon)
			{
				case 0:
					{
						Instantiate(bullettoRight, bulletPos, Quaternion.identity);
						break;
					}
				case 1:
					{
						Instantiate(bullettoRight1, bulletPos, Quaternion.identity);
						break;
					}
				case 2:
					{
						Instantiate(bullettoRight2, bulletPos, Quaternion.identity);
						break;
					}
				case 3:
					{
						Instantiate(bullettoRight3, bulletPos, Quaternion.identity);
						break;
					}

			}
				
				   

		}
		
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "flyingCrab" || collision.gameObject.tag == "crab" || collision.gameObject.tag == "yellowCrab"|| collision.gameObject.tag == "boss")
		{
			playerHealth -= 1;
			switch (playerHealth)
			{
				case 2:
					{
						heart3.gameObject.SetActive(false);
						if (coroutineAllowed)
							StartCoroutine("Immortal");
						break;
					}
				case 1:
					{
						heart2.gameObject.SetActive(false);
						if (coroutineAllowed)
							StartCoroutine("Immortal");
						break;
					}
				case 0:
					{
						heart1.gameObject.SetActive(false);
						if (coroutineAllowed)
							StartCoroutine("Immortal");
						break;
					}

			}
			if (playerHealth < 0)
			{
				SoundManager.playSound("Die");
				gameOvertext.SetActive(true);
				restartBt.SetActive(true);
				shopBt.SetActive(true);
				panel.SetActive(true);
				Instantiate(blood, transform.position, Quaternion.identity);
				//coinsNumber = PlayerPrefs.GetInt("Money");
				//Destroy(collision.gameObject);
				Destroy(gameObject);
			}
			if (GamePlayController.instance != null)
			{
				GamePlayController.instance._TonDiedShowPanel(ScoreScript.scorevalue);
			}

		}
	}
	IEnumerator Immortal()
	{
		coroutineAllowed = false;
		Physics2D.IgnoreLayerCollision(playerLayer, enemyPlayer, true);
		color.a = 0.5f;
		rend.material.color = color;
		yield return new WaitForSeconds(0.2f);
		Physics2D.IgnoreLayerCollision(playerLayer, enemyPlayer, false);
		color.a = 1f;
		rend.material.color = color;
		coroutineAllowed = true;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("coin"))
		{
			coinsNumber += 1;
			
		}
		if(col.gameObject.tag=="boss")
		{
			playerHealth -= 1;
			switch (playerHealth)
			{
				case 2:
					{
						heart3.gameObject.SetActive(false);
						if (coroutineAllowed)
							StartCoroutine("Immortal");
						break;
					}
				case 1:
					{
						heart2.gameObject.SetActive(false);
						if (coroutineAllowed)
							StartCoroutine("Immortal");
						break;
					}
				case 0:
					{
						heart1.gameObject.SetActive(false);
						if (coroutineAllowed)
							StartCoroutine("Immortal");
						break;
					}

			}
			if (playerHealth < 0)
			{
				SoundManager.playSound("Die");
				gameOvertext.SetActive(true);
				restartBt.SetActive(true);
				shopBt.SetActive(true);
				panel.SetActive(true);
				Instantiate(blood, transform.position, Quaternion.identity);
				//Destroy(collision.gameObject);
				Destroy(gameObject);
				//coinsNumber=PlayerPrefs.GetInt("Money");
			}
			if (GamePlayController.instance != null)
			{
				GamePlayController.instance._TonDiedShowPanel(ScoreScript.scorevalue);
			}
		}
	}

}
