using UnityEngine;
using System.Collections;

public class BoltScript : WeaponScript {

	override protected void OnEnable()
	{
		base.OnEnable();
		//move the bolt while it is active
		//GetComponent<Rigidbody2D>().velocity =  transform.right * speed * facingRight; 
	}
	
	override protected void OnDisable()
	{
		base.OnDisable();
		//when the bolt is used make sure another invoke isn't in the queue
		CancelInvoke();
	}
	// Bolt has gone of the screen
	void OnBecameInvisible()
	{
		gameObject.SetActive(false);
	}
	new public int FacingRight
	{
		set {facingRight = value;}
	}

}
