using UnityEngine;
using System.Collections;

public class NukeScript : WeaponScript
{
	public Vector2 force;
	public float radius;
	private float timer;
	private bool isExploding = false;
	public float count;

	private bool inUse = false;
	private Vector3 location;
	
	public GameObject explosion;

	public float Timer
	{
		get
		{
			return timer;
		}
		set
		{
			timer = value;
		}
	}
	
	public bool IsExploding
	{
		get 
		{
			return isExploding;
		}
		set
		{
			isExploding = true;
		}
	}
	public bool InUse
	{
		get
		{
			return inUse;
		}
		set{
			inUse = true;
		}
	}
	void Awake()
	{
		location.Set(0,0,0);
	}
	void Update()
	{
		print ("time is " + Time.time);
		if (Time.time > timer && isExploding == false)
		{
			Explode();
			this.gameObject.SetActive (false);
		}
	}

	void Explode()
	{
		isExploding = true;
		timer = 0f;

		print("Exploding");
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
		
		foreach (Collider2D c in colliders)
		{
			if (c.attachedRigidbody == null) continue;
			
			c.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
		}
		
		Instantiate(explosion, transform.position, Quaternion.identity);
	}
}
