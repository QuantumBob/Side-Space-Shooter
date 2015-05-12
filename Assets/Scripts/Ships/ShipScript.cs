using UnityEngine;
using System.Collections;

public class ShipScript : MonoBehaviour 
{
	public float maxSpeed;// max speed of the players ship. Change with power ups
	protected bool facingRight = true; // which way is the ship facing (starts facing right)
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
	public bool FacingRight
	{
		get {return facingRight;}
	}
	// changes direction of the sprite
	protected void Flip()
	{
		facingRight = !facingRight;
		Vector3 the_scale = transform.localScale;
		the_scale.x *= -1;
		transform.localScale = the_scale;
	}
}
