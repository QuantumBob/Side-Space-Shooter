using UnityEngine;
using System.Collections;
// Changes the cursor when over different gameobjects.
// used with a Game Manager gameobject
public class Interactor : MonoBehaviour {
	
	private GameOptions gameOptionsScript;//To hold a ref to the options script
	// Use this for initialization
	void Start ()
	{
		//Get the GameManager gameobject once
		GameObject gameManager = GameObject.Find("GameManager");
		//Get the options script once also
		gameOptionsScript = (GameOptions) gameManager.GetComponent(typeof(GameOptions));
	}
	//When the mouse enters the game object this script is attached toos collider
	void OnMouseEnter()
	{
		//change the cursor
		//in this instance just a simple change
		//but can check to see what type of object and use a cursor that indicates what can be done
		//if more than one action can be performed have a dual cursor
		//and switch between the actions with [Shift] or [Ctrl]
		gameOptionsScript.CursorChange("open");
	}
	//When the mouse leaves the game object this script is attached toos collider
	void OnMouseExit()
	{
		//reset the cursor to its default state
		gameOptionsScript.CursorChange("");
	}
}
