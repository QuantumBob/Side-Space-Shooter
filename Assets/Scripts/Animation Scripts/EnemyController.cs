using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float max_speed = 2f;// max speed of the players ship. Change with power ups
	//public float move_horizontal;
	//public float move_vertical;
	//public Vector2 newVector;

	// Use this for initialization
	void Start () {
		//newVector = Random.insideUnitCircle;
		//move_horizontal = newVector.x;
		//move_vertical = newVector.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (Random.insideUnitCircle.x * max_speed, Random.insideUnitCircle.y *max_speed);
	}
}
