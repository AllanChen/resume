using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
	float lastTapTime = 0.0f;
	float tapSpeed = 0.5f;
	bool faceingRight;
	bool rightRunKeyPressDown;
	bool leftRunKeyPressDown;
	bool grounded;
	public float moveSpeed ;
	Animator anim;

	public Transform groundChecker;
	public LayerMask whatIsGround;

	void Start () {
		faceingRight = true;
		moveSpeed = 3.0f;
		anim = GetComponent<Animator>();
		groundChecker = transform.Find("groundChecker");
	}
	
	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle(groundChecker.position,0.0f,whatIsGround);
		anim.SetBool("Ground",grounded);
		Walk();
	}


	void Update () {
		NomalAcctack();
		WalkActack();
		Run();
		RunActack();
		Jump();
		JumpActack();
		if(anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base Layer.Walk"))
			moveSpeed = 3.0f;
	}

	/*
	| Animation
	 */

	void Walk()
	{
		float move = Input.GetAxis("Horizontal");
		Flip(move);
		anim.SetFloat("Speed",Mathf.Abs(move));
		rigidbody2D.velocity = new Vector2(move*moveSpeed,rigidbody2D.velocity.y);	
	}

	void Run()
	{
		if(Input.GetButtonDown("Walk"))
		{
			if((Input.GetKeyDown(KeyCode.D) && rightRunKeyPressDown)|| (Input.GetKeyDown(KeyCode.A) && leftRunKeyPressDown))
			{
				if((Time.time - lastTapTime)<tapSpeed)
				{
					moveSpeed = 5.0f;
					anim.SetBool("Run",true);
				}
			}

			lastTapTime = Time.time;
			rightRunKeyPressDown = Input.GetKeyDown(KeyCode.D);
			leftRunKeyPressDown = Input.GetKeyDown(KeyCode.A);
		}
		
		if(Input.GetButtonUp("Walk"))
		{
			moveSpeed = 3.0f;
			anim.SetBool("Run",false);
		}
		float move = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2(move*moveSpeed,rigidbody2D.velocity.y);
	}

	void Flip(float move)
	{
		if(move<0 && faceingRight)
		{
			transform.localRotation = Quaternion.Euler(0,180,0);
			faceingRight = false;
		}
		else if(move>0 && !faceingRight)
		{
			transform.localRotation = Quaternion.Euler(0,0,0);
			faceingRight = true;
		}
	}

	void Jump()
	{
		if(Input.GetButtonDown("Jump") && grounded)
		{
			anim.SetBool("Ground",false);
			rigidbody2D.AddForce(new Vector2(0,300f));
		}
	}


	void NomalAcctack()
	{
		if(Input.GetButtonDown("Actack"))
		{
			anim.SetBool("idleActack",true);
		}

		if(Input.GetButtonUp("Actack"))
		{
			anim.SetBool("idleActack",false);
		}
	}

	void WalkActack()
	{
		if(Input.GetButtonDown("Actack") && anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base Layer.Walk"))
		{
			anim.SetBool("walkActack",true);
		}
		if(Input.GetButtonUp("Actack"))
		{
			anim.SetBool("walkActack",false);
		}
	}

	void RunActack()
	{
		if(Input.GetButtonDown("Actack") && anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base Layer.Run"))
		{
			anim.SetTrigger("runActack");
		}
	}


	void JumpActack()
	{
		if(Input.GetButtonDown("Actack") && !grounded)
		{
			//anim.SetTrigger("jumpActack");
			anim.SetBool("jumpActack",true);
		}

		if(Input.GetButtonUp("Actack"))
		{
			anim.SetBool("jumpActack",false);
		}

	}
}
