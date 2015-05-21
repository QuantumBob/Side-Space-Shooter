using UnityEngine;
using System.Collections;

// Class for any game object which has a shield
public class ShieldScript : MonoBehaviour, IDamagable
{
	public float shieldStrength = 0;

	// Use this for initialization
	void Start ()
	{
		if (shieldStrength > 0)
			this.gameObject.SetActive(true);
		else
			gameObject.SetActive(false);
	}
	// implemented from IDamagable
	public void HitByWeapon(float damage)
	{
		shieldStrength -= damage;
		if (shieldStrength <= 0 )
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
			OrdnanceManager.current.DestroyObject(gameObject);
		}
	}
	void OnGUI ()
	{
		string message = "shieldStrength = " + shieldStrength;
		GUI.Label (new Rect(10, 10,150,50), message);
	}
}
