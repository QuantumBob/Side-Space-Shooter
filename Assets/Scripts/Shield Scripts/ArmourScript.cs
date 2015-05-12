using UnityEngine;
using System.Collections;

public class ArmourScript : MonoBehaviour, IDamagable
{
	public int armourStrength = 0;
	
	// Use this for initialization
	void Start ()
	{
		if (armourStrength > 0)
			this.gameObject.SetActive(true);
		else
			gameObject.SetActive(false);
	}
	// implemented from IDamagable
	public void HitByWeapon()
	{
		armourStrength -= 1;
		if (armourStrength <= 0 )
		{
			// get an explosion from the pool
			GameObject explosion = OrdnanceManager.current.GetPooledObject("Explosion");
			//if the pooler has run out of explosions just return
			if (explosion == null) return;
			// set the position etc to the torp spawn point
			explosion.transform.position = gameObject.transform.position;
			//explosion.transform.rotation = go.transform.rotation;
			//### Could set velocity so explosion moves as the destroyed ship did ###
			//activate the explosion
			explosion.SetActive(true);
			//repool or destroy object
			// need to get parent of collider to destroy
			// destroy the object the collider is attached to
			OrdnanceManager.current.DestroyObject(transform.parent.gameObject);
		}
	}
}

