using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour {

	Animator anim;
	bool grounded;
	float groundRadius = 0.2f;

	public Transform groundChecker;
	public LayerMask whatIsGround;

	void Start () {
		groundChecker = transform.Find("groundChecker");
		anim = GetComponent<Animator>();
	}
	

	void Update () {
		//print (rigidbody2D.velocity.y);
	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundChecker.position,groundRadius,whatIsGround);

		if(Input.GetButtonDown("Jump"))
		{
			print(1);
			//anim.SetBool("Jump",true);
			rigidbody2D.AddForce(new Vector2(0f,200f * Time.time));
		}
	}
}
