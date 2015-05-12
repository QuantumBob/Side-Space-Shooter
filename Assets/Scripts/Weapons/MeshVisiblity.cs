using UnityEngine;
using System.Collections;

public class MeshVisiblity : MonoBehaviour {
	
	// weapon has gone of the screen
	void OnBecameInvisible()
	{
		transform.root.gameObject.SetActive(false);
	}
}
