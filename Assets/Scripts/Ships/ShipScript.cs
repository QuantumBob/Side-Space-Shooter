using UnityEngine;
using System.Collections;

public class ShipScript : MonoBehaviour 
{
	public float maxSpeed;// max speed of the players ship. Change with power ups
	protected int facingRight = 1; // which way is the ship facing (starts facing right)
	protected Animator shipAnimator; // ref to the animatior object in Unity

	// Use this for initialization
	protected virtual void Start ()
	{
		//Get the anmator object from Unity
		shipAnimator = GetComponent<Animator>();
	}
	// used when the ship is initialised
	protected virtual void Awake()
	{
	}
	// Properties
	public int FacingRight
	{
		get {return facingRight;}
	}
	// changes direction of the sprite
	protected void Flip()
	{
		facingRight *= -1;
		Vector3 the_scale = gameObject.transform.localScale;
		the_scale.x *= -1;
		gameObject.transform.localScale = the_scale;
		// if the ship has a laser flip it too
		if (gameObject.transform.Find("Laser")) 
			gameObject.GetComponentInChildren<LaserScript>().Flip();
	}
}
