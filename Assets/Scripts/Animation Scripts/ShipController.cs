using UnityEngine;
using System.Collections;

// Controls the players ship animations and movment
public class ShipController : MonoBehaviour
{

	public float max_speed;// max speed of the players ship. Change with power ups
	private bool facing_right = true; // which way is the ship facing (starts facing right)
	private Animator ship_anim; // ref to the animatior object in Unity

	// Use this for initialization
	void Start ()
	{
		//Get the anmator object from Unity
		ship_anim = GetComponent<Animator>();
	}
	// Fixed Update is called at a regular interval
	void FixedUpdate ()
	{
		float move_horizontal = Input.GetAxis("Horizontal");
		float move_vertical = Input.GetAxis("Vertical");

		//ship_anim.SetFloat("speed_right", Mathf.Abs (move_horizontal)); for when we have horizontal animation
		if (move_vertical > 0.1 && !ship_anim.GetCurrentAnimatorStateInfo(0).IsName("ship_up"))
		{
			if (!ship_anim.GetCurrentAnimatorStateInfo(0).IsName("ship_continue_up"))
				ship_anim.SetTrigger("up_started");
		}
		else if (move_vertical > 0.1 && ship_anim.GetCurrentAnimatorStateInfo(0).IsName("ship_up"))
			ship_anim.SetTrigger("still_going_up");

		else if (move_vertical == 0 )		
			ship_anim.SetTrigger("hovering");

		else if (move_vertical < -0.1 && !ship_anim.GetCurrentAnimatorStateInfo(0).IsName("ship_down"))
		{
			if (!ship_anim.GetCurrentAnimatorStateInfo(0).IsName("ship_continue_down"))
				ship_anim.SetTrigger("down_started");
		}
		else if (move_vertical <  -0.1 && ship_anim.GetCurrentAnimatorStateInfo(0).IsName("ship_down"))
			ship_anim.SetTrigger("still_going_down");

		GetComponent<Rigidbody2D>().velocity = new Vector2 (move_horizontal * max_speed, move_vertical *max_speed);//GetComponent<Rigidbody2D>().velocity.y);

		if (move_horizontal > 0 && !facing_right)
			Flip();
		else if (move_horizontal < 0 && facing_right)
			Flip();
		//}
	}

	public bool FacingRight
	{
		get {return facing_right;}
	}

	void Flip()
	{
		facing_right = !facing_right;
		Vector3 the_scale = transform.localScale;
		the_scale.x *= -1;
		transform.localScale = the_scale;
	}

}
