using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Controls the movement and animation of the ship
public class PlayerShipScript : ShipWithWeaponsScript
{
	// Use this for initialization
	override protected void Start () 
	{
		base.Start();

	}
	override protected void Awake ()
	{
		base.Awake();
	}
	// Update is called once per frame
	void Update () 
	{
		// controls for the player to fire their weapons
		if(Input.GetButtonDown ("Fire1"))
			OrdnanceManager.current.FireWeapon(gameObject, "HardpointOne");
		
		if(Input.GetButtonDown ("Fire2"))
			OrdnanceManager.current.FireWeapon(gameObject, "HardpointTwo");
	}
	// Fixed Update is called at a regular interval
	void FixedUpdate ()
	{
		MoveShip();
	}
	// Controls the players ship animations and movment
	void MoveShip()
	{
		float move_horizontal = Input.GetAxis("Horizontal");
		float move_vertical = Input.GetAxis("Vertical");
		
		//ship_anim.SetFloat("speed_right", Mathf.Abs (move_horizontal)); for when we have horizontal animation
		if (move_vertical > 0.1 && !shipAnimator.GetCurrentAnimatorStateInfo(0).IsName("ship_up"))
		{
			if (!shipAnimator.GetCurrentAnimatorStateInfo(0).IsName("ship_continue_up"))
				shipAnimator.SetTrigger("up_started");
		}
		else if (move_vertical > 0.1 && shipAnimator.GetCurrentAnimatorStateInfo(0).IsName("ship_up"))
			shipAnimator.SetTrigger("still_going_up");
		
		else if (move_vertical == 0 )		
			shipAnimator.SetTrigger("hovering");
		
		else if (move_vertical < -0.1 && !shipAnimator.GetCurrentAnimatorStateInfo(0).IsName("ship_down"))
		{
			if (!shipAnimator.GetCurrentAnimatorStateInfo(0).IsName("ship_continue_down"))
				shipAnimator.SetTrigger("down_started");
		}
		else if (move_vertical <  -0.1 && shipAnimator.GetCurrentAnimatorStateInfo(0).IsName("ship_down"))
			shipAnimator.SetTrigger("still_going_down");
		
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move_horizontal * maxSpeed, move_vertical *maxSpeed);//GetComponent<Rigidbody2D>().velocity.y);
		
		if (move_horizontal > 0 && facingRight < 0)
			Flip();
		else if (move_horizontal < 0 && facingRight > 0)
			Flip();
	}
}
