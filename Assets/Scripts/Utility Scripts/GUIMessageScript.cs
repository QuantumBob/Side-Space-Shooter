using UnityEngine;
using System.Collections;

public class GUIMessageScript : MonoBehaviour {
	
	void OnGUI ()
	{
		string message = "Message";
		GUI.Label (new Rect(10, 10,150,50), message);
	}
}
