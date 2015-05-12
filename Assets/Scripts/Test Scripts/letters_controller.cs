using UnityEngine;
using System.Collections;

public class letters_controller : MonoBehaviour {

	private Animator letter_anim;
	//bool b_moving_up = false;
	//bool b_moving_down = false;

	// Use this for initialization
	void Start () {
		letter_anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//float move_horizontal = Input.GetAxis("Horizontal");
		float move_vertical = Input.GetAxis("Vertical");

		if (move_vertical > 0.1){// && b_moving_up == false ) {
			letter_anim.SetTrigger("moving_up");
			//b_moving_up = true;
		}
		//else if (move_vertical == 0 && b_moving_up == true){
		//	letter_anim.SetTrigger("stop_moving_up");
		//	b_moving_up = false;
		//}
		else if (move_vertical < -0.1){// && b_moving_down == false){
			letter_anim.SetTrigger("moving_down");
			//b_moving_down = true;
		}
		//else if (move_vertical == 0 && b_moving_down == true){
		//	letter_anim.SetTrigger("stop_moving_down");
		//	b_moving_down = false;
		//}
	}
}
