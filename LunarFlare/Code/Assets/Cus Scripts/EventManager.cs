using UnityEngine;
using System.Collections;

public static class EventManger {

	public delegate void UserInput();
	public static event UserInput OnKeyPress;
	public static void KeyPressed(){
		if(OnKeyPress != null){
			OnKeyPress();
		}
	}

}
