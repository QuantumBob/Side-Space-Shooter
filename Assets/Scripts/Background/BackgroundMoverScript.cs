using UnityEngine;
using System.Collections;
// scroll the background
public class BackgroundMoverScript : MonoBehaviour
{
	// speed at which the background moves
	public float speed;
	public float backgroundWidth;
	public Vector3 resetPosition;
	public Vector3 cameraEdge;

	void Start()
	{
		// get the width of the background sprite
		backgroundWidth = GetComponent<Renderer>().bounds.size.x;
		// set the position the sprite gets reset to
		resetPosition = new Vector3(backgroundWidth, gameObject.transform.position.y, 1);
		cameraEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 1f ));
	}
	// Update is called once per frame
	void Update ()
	{
		//cameraEdge = Camera.current.ViewportToWorldPoint(new Vector3(0f, 0f, 1f ));
		// move the background image left ie backwards at speed.
		gameObject.transform.Translate(Vector3.left * speed);
		// check if we need to move the sprite in front of the other one
		if (gameObject.transform.position.x + (backgroundWidth/2) <= cameraEdge.x)
		{
			gameObject.transform.position = resetPosition;
		}
	}
}
