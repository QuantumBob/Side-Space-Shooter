using UnityEngine;
using System.Collections;

public class BombScript : WeaponScript {

	override protected void OnEnable()
	{
		base.OnEnable();
		//move the bomb while it is active
		//GetComponent<Rigidbody2D>().velocity = new Vector2(-1,0);//transform.forward * speed; 
		//call the explode bomb method after 3 sec
		Invoke ("ExplodeBomb", 3f);
	}

	override protected void OnDisable()
	{
		base.OnDisable();
		//wnen the bomb is exploded make sure another invoke isn't in the queue
		CancelInvoke();
	}
	// bomb has gone of the screen
	void OnBecameInvisible()
	{
		gameObject.SetActive(false);
	}

	void ExplodeBomb()
	{
		//do bomb like stuff first

		//after the bomb explodes set it to inactive
		gameObject.SetActive(false);
	}
}
