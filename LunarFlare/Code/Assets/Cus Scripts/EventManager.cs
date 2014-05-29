using UnityEngine;
using System.Collections;

public static class EventManger {
	/// <summary>
	///Events will be stored here. Events are used to save memory
	 /// Instead of having to create a new instance of some classes
	/// We can use events to call them once they are created in the scene
	/// This allows us to not have to keep re-creating new instances 
	/// of objects. 
	/// </summary>
	public delegate void UserInput();
	public static event UserInput OnKeyPress; //This event is used called whenever there is a key press. Will will than call the nessesary functions
	public static void KeyPressed(){
		if(OnKeyPress != null){
			OnKeyPress();
		}
	}

}
