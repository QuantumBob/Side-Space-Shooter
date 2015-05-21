using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
	public float speed;
	public int facingRight; 
	public bool doesExplode;
	public float damage;
	private GameObject firingShip;
	// do initialzation here
	virtual protected void Start()
	{
		facingRight = 1;
	}

	virtual protected void OnEnable()
	{
		//move the weapon while it is active
		GetComponent<Rigidbody2D>().velocity = transform.right * speed * facingRight; 
	}
	
	virtual protected void OnDisable()
	{
		//when the bolt is used make sure another invoke isn't in the queue
		CancelInvoke();
	}
	// properties
	public int FacingRight
	{
		set {facingRight = value;}
	}
	public GameObject FiringShip
	{
		get { return firingShip; }
		set { firingShip = value; }
	}
	// function called when the weapon triggers another objects collider
	void OnTriggerEnter2D(Collider2D other)
	{
		// don't interact if both colliders are weapons AND have been fired from one ship
		if (other.tag == "Weapon" && this.tag == "Weapon" && other.GetComponent<WeaponScript>().FiringShip == this.FiringShip) return;
		// don't blow up the ship that fired the weapon!
		if(!other.CompareTag("Weapon") && other.transform.parent.gameObject == firingShip) return; //other as a weapon does not have a parent
		//### other.transform.FindChild("name").gameObject;
		// if the weapon explodes on impact
		if (doesExplode)
		{
			// get an explosion from the pool
			GameObject explosion = OrdnanceManager.current.GetPooledObject("Explosion");
			//if the pooler has run out of explosions just return
			if (explosion == null) return;
			// set the position etc to the torp spawn point
			explosion.transform.position = gameObject.transform.position;
			//### Could set velocity so explosion moves as the destroyed ship did ###
			//activate the explosion
			explosion.SetActive(true);
		}
		// set active to false to mimic destruction of the weapon
		gameObject.SetActive(false);
		// check other for shield
		if (other.gameObject.tag == "Shield" && other.gameObject.activeSelf)
		{
			other.GetComponent<ShieldScript>().HitByWeapon(damage);
		}
		if (other.gameObject.tag == "Armour" && other.gameObject.activeSelf)
		{
			other.GetComponent<ArmourScript>().HitByWeapon(damage);
		}

	}
}
