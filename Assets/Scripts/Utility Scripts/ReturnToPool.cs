using UnityEngine;
using System.Collections;

public class ReturnToPool : MonoBehaviour {

	public void ReturnMeToPool()
	{
		gameObject.SetActive(false);
	}
}
