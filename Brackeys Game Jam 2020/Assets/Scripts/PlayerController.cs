using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed;
	private float movementx = 0f, movementy;
	Rigidbody2D rb;
	public GameObject bulletToLeft, bulletToRight;
	Vector2 bulletPos;
	public float fireRate = 1f;
	float nextFire = 0.0f;
	public GameObject bulletPosition;
	bool facingRight = true;

	public int maxHealth = 100;
	public int currentHealth;
	


	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		currentHealth = maxHealth;
	
		
	}

	// Update is called once per frame
	void Update()
	{
		Move();
		
		
	}

	private void FixedUpdate()
	{
		Flip();
		CdFire();
	}

	void Move()
	{
		movementx = Input.GetAxis("Horizontal");
		movementy = Input.GetAxis("Vertical");
		transform.Translate(movementx *Time.deltaTime, movementy * Time.deltaTime, 0);
		
		if (movementx > 0f)
		{
			facingRight = true;
			rb.velocity = new Vector2(movementx * speed, rb.velocity.y);
			
		}
		else if (movementx < 0f)
		{
			facingRight = false;
			rb.velocity = new Vector2(movementx * speed, rb.velocity.y);
			
		}
		

	}

	void Flip()
	{
		if (movementx != 0)
			rb.transform.localScale = new Vector2(Mathf.Sign(movementx) *
				Mathf.Abs(transform.localScale.x),
				Mathf.Abs(transform.localScale.y));
	}

	void Fire()
	{
		bulletPos = transform.position;
		if (facingRight)
		{
			bulletPos += new Vector2(0.148f, -0.500f);
			Instantiate(bulletToRight, bulletPos, Quaternion.identity);
		}
		/*else
		{
			bulletPos += new Vector2(0.160f, -0.500f);
			Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
		}*/
	}

	void CdFire()
	{
		if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Fire();
		}
	}





}

