using UnityEngine;
using System.Collections;

public class colours_script : MonoBehaviour {
	
	private Animator colour_anim;
	private int count = 0;
	//float move_horizontal;
	float move_vertical;
	
	// Use this for initialization
	void Start () {
		colour_anim = GetComponent<Animator>();
	}

	void FixedUpdate () {
		//move_horizontal = Input.GetAxis("Horizontal");
		move_vertical = Input.GetAxis("Vertical");
		count += 1;

		if (count == 200){
			colour_anim.SetTrigger("timer");
			count = 0;
		}

		if (move_vertical > 0.1 && !colour_anim.GetCurrentAnimatorStateInfo(0).IsName("Blue_to_Red")){
			colour_anim.SetTrigger("up_pressed");
		}

		else if (move_vertical < -0.1 && !colour_anim.GetCurrentAnimatorStateInfo(0).IsName("Red_to_Blue")){
			colour_anim.SetTrigger("down_pressed");
		}
	}

	void OnGUI (){
		string message = "Vert Axis : " + move_vertical;
		GUI.Label (new Rect(10, 10,150,50), message);
	}
}
