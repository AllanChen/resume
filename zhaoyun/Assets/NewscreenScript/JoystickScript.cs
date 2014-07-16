using UnityEngine;
using System.Collections;

public class JoystickScript : MonoBehaviour {

	//public joystickPlayer
	public GameObject player;
	public MPJoystick moveJoystick;

	void Update () 
	{
	
		float touchMoveX = moveJoystick.position.x;
		float touchMoveY = moveJoystick.position.y;

	}
}
