using UnityEngine;
using System.Collections;

public class PlayerWeaponsScript : MonoBehaviour
{
	// Update is called once per frame
	void Update () 
	{
		// controls for the player to fire their weapons
		if(Input.GetButtonDown ("Fire1"))
			OrdnanceManager.current.FireWeapon(gameObject, "HardpointOne");

		if(Input.GetButtonDown ("Fire2"))
			OrdnanceManager.current.FireWeapon(gameObject, "HardpointTwo");
	}
}
