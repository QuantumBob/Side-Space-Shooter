using UnityEngine;
using System.Collections;

public class GameOptions : MonoBehaviour {

	public Texture2D cursorTexture;//non default cursor
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;//where the cursor hotspot is

	void Awake()
	{
		//for testing purposes set the screen res
		Screen.SetResolution(960, 600, false);
	}
	//switch between cursors when hovering over a selectable object
	//and have a select case for different cursors
	public void CursorChange(string pickType)
	{
		pickType = pickType.ToLower();
		switch(pickType)
		{
		case "open":
		{
			//open something
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
			break;
		}
		case "default":
		{
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
			break;
		}
		default:
		{
			Cursor.SetCursor(null, Vector2.zero, cursorMode);
			break;
		}
		}

	}
}
