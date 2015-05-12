using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {

	public void DestroyMe()
	{
		Destroy(gameObject);
	}
}
