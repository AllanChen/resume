using UnityEngine;
using System.Collections;

public class RunScript : MonoBehaviour {

	float lastTapTime = 0.0f;
	float tapSpeed = 0.5f;
	public float characterSpeed;

	Animator anim;
		
	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update () {
	
		if(Input.GetButtonDown("Walk"))
		{
			if((Time.time - lastTapTime)<tapSpeed)
			{
				characterSpeed = 10.0f;
				anim.SetBool("Run",true);
			}
			lastTapTime = Time.time;
		}

		if(Input.GetButtonUp("Walk"))
		{
			//characterSpeed = 3.0f;
			anim.SetBool("Run",false);
		}
		float move = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2(move*characterSpeed,rigidbody2D.velocity.y);
	}


}
