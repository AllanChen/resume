using UnityEngine;
using System.Collections;

public class CameraMoveScript : MonoBehaviour {
	public GameObject cameraObject;
	public GameObject characterObject;

	void Start()
	{
		characterObject.GetComponent<Animation>();
			
#if UNITY_4_5
		//characterObject.GetComponent(MoveScript);
#endif
	}

	void Update () {
		//characterObject.animation.CrossFade("walk");
		//characterObject.animation.CrossFade("walk",0.25f);

		cameraObject.transform.position = new Vector3(characterObject.transform.position.x,-1.05f, -10);
	}
}
