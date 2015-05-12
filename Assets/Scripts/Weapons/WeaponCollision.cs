using UnityEngine;
using System.Collections;

public class WeaponCollision : MonoBehaviour
{
	private GameObject firingShip;

	public GameObject FiringShip
	{
		get { return firingShip; }
		set { firingShip = value; }
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// don't blow up the ship that fired the weapon!
		if(other.gameObject == firingShip.gameObject) return;
		// if the weapon explodes on impact
		//if (gameObject.doesExplode)
		{
			// get an explosion from the pool
			GameObject explosion = OrdnanceManager.current.GetPooledObject("Explosion");
			//if the pooler has run out of explosions just return
			if (explosion == null) return;
			// set the position etc to the torp spawn point
			explosion.transform.position = gameObject.transform.position;
			//explosion.transform.rotation = weapon.transform.rotation;
			//### Could set velocity so explosion moves as the destroyed ship did ###
			//activate the explosion
			explosion.SetActive(true);
		}
		// set active to false to mimic destruction of the weapon
		gameObject.SetActive(false);
		//### Could set velocity so explosion moves as the destroyed ship did ###
	}
}
