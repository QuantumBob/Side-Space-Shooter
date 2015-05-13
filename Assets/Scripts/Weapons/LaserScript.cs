using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
	LineRenderer line;
	private int lineLength;

	void Start()
	{
		lineLength = 15;
		line = gameObject.GetComponent<LineRenderer>();
		line.SetPosition(0, Vector2.zero);
		line.enabled = false;
	}

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			StopCoroutine("FireLaser");
			StartCoroutine("FireLaser");
		}
	}

	IEnumerator FireLaser()
	{
		line.enabled = true;

		while (Input.GetButton("Fire1"))
		{
			RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, gameObject.transform.right, lineLength);

			if (hit.collider != null)
			{
				//###need to sort out ship turned left
				print ("hit2 = " + hit.distance);
				line.SetPosition(1, Vector2.right * hit.distance);
			}
			else
				line.SetPosition(1, Vector2.right * lineLength);

			yield return null;
		}
		line.enabled = false;
	}
}
