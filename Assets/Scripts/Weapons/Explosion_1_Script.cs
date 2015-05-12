using UnityEngine;
using System.Collections;

public class Explosion_1_Script : MonoBehaviour {

	private Animator explosionAnimator;

	// Use this for initialization
	void Start () {
		explosionAnimator = GetComponent<Animator>();
	}
	void OnEnabled()
	{
		explosionAnimator.Play("Explosion");

	}

	public Animator ExplosionAnimator
	{
		get { return explosionAnimator; }
	}
}
