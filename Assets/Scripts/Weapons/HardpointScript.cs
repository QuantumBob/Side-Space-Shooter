using UnityEngine;
using System.Collections;

public class HardpointScript : MonoBehaviour
{
	public int hardpointSize;
	public GameObject weapon;
	public bool isActive;
	//properties
	public int HardpointSize
	{
		get { return hardpointSize; }
		set { hardpointSize = value; }
	}
	public GameObject Weapon
	{
		get { return weapon; }
		set { value = weapon; }
	}
	public bool IsActive
	{
		get { return isActive; }
		set { isActive = value; }
	}
}
