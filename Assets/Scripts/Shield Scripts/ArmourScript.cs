using UnityEngine;
using System.Collections;

// add this to any collider you want to be destroyable
// and change the collider's tag to "Armour"
public class ArmourScript : MonoBehaviour, IDamagable
{
	public float armourStrength = 0;
	
	// Use this for initialization
	void Start ()
	{
		if (armourStrength > 0)
			this.gameObject.SetActive(true);
		else
			gameObject.SetActive(false);
	}
	// implemented from IDamagable
	public void HitByWeapon(float damage)
	{
		armourStrength -= damage;
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
	void OnGUI ()
	{
		string message = "armourStrength = " + armourStrength;
		GUI.Label (new Rect(10, 60,150,50), message);
	}
}

