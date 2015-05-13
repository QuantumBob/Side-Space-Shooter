using UnityEngine;
using System.Collections;

public class TorpedoScript : WeaponScript
{
	override protected void OnEnable()
	{
		base.OnEnable();
		//start the torpedo moving as soon as it appears
		//GetComponent<Rigidbody2D>().velocity = transform.right * speed * facingRight; 
	}
	
	override protected void OnDisable()
	{
		base.OnDisable();
		//wnen the torpedo is exploded make sure another invoke isn't in the queue
		CancelInvoke();
	}
	// torpedo has gone of the screen
	void OnBecameInvisible()
	{
		gameObject.SetActive(false);
	}
}
