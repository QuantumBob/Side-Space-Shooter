using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
	public float damage;
	LineRenderer line; // what the laser will look like
	private int lineLength; // length of the laser
	private int facingRight = 1;// so when the ship moves the laser will too

	void Start()
	{
		// set the lasers damage
		//damage = 0.001f;
		// set the laser length, get ref to the line renderer
		lineLength = 15;
		line = gameObject.GetComponent<LineRenderer>();
		// set the line renderer to false so it doesn't show until it is used
		line.enabled = false;
	}

	void Update()
	{
		// check if we are pressing the fire laser button
		if (Input.GetButtonDown("Fire1"))
		{
			// just incase the coroutine is running
			StopCoroutine("FireLaser");
			// start the version of the coroutine we want
			StartCoroutine("FireLaser");
		}
	}

	IEnumerator FireLaser()
	{
		// now the line can be drawn
		line.enabled = true;
		// loop through the code while the fire button is being held
		while (Input.GetButton("Fire1"))
		{
			// create a ray from the origin of the laser moving out from the ship
			// the facingRight is -1 if the ship is pointing left, flipping the transform in the x axis
			Ray2D ray = new Ray2D(transform.position, transform.right * facingRight);
			// check if the line has hit anything
			RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * facingRight);
			// set the start point of the line to the laser weapon location
			line.SetPosition(0, transform.position);

			// check if the ray has hit and it isn't the ship it is on
			if (hit.collider && hit.fraction > 0)
			{
				// if the ray has hit, curtail the laser to the point where it hits the collider
				line.SetPosition(1, hit.point);
				// do damage to the thing we have hit
				if (hit.collider.gameObject.tag == "Shield" && hit.collider.gameObject.activeSelf)
				{
					hit.collider.GetComponent<ShieldScript>().HitByWeapon(damage);
				}
				if (hit.collider.gameObject.tag == "Armour" && hit.collider.gameObject.activeSelf)
				{
					hit.collider.GetComponent<ArmourScript>().HitByWeapon(damage);
				}
			}
			else
			{
				// we haven't hit anything so just shoot the laser to its full length
				line.SetPosition(1, ray.GetPoint(lineLength));
			}
			// allow other things to run too but exit to the next line of code 
			yield return null;
		}
		// ie this line which just tells the laser to not be drawn
		line.enabled = false;
	}
	// called from the ships code when it flips
	public void Flip()
	{
		facingRight *= -1;
	}
}
