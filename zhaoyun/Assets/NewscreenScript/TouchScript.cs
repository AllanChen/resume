using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour 
{
	public GUITexture leftController;
	public GUITexture rightController;
	public GUITexture actackController;

	public MPJoystick moveJoystick;
	bool faceingRight;
	public float moveSpeed ;

	Animator anim;
	
	void Start () {
		faceingRight = false;
		moveSpeed = 3.0f;
		anim = GetComponent<Animator>();
	}

	void Update () 
	{

#if UNITY_IOS
		PhoneInput();
#endif

#if UNITY_4_5_1
		PcInput();
#endif
	}

	void PhoneInput()
	{
			int fingerCount = 0;
			foreach(Touch touch in Input.touches)
			{
				if(touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
					fingerCount ++;
			}
			
			Walk();
	}

	void PcInput()
	{
			
		if(Input.GetKeyDown(KeyCode.D))
		{				
			//anim.goToStateIfNotAlreadyThere(Animator.StringToHash( "Base Layer.Walk" ));
			float move = Input.GetAxis("Horizontal");

			anim.animation.Play("walk");
		}
	}
	
	void ControllerSaySomething()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			if(leftController.HitTest(Input.mousePosition))
			{
				Debug.Log(leftController.pixelInset.x);
				Debug.Log("i am leftconteroller");
			}
		}
	}	

	void Walk()
	{
		float touchMoveX = moveJoystick.position.x;
		Flip(touchMoveX);
		anim.SetFloat("Speed",Mathf.Abs(touchMoveX));
		rigidbody2D.velocity = new Vector2(touchMoveX*moveSpeed,rigidbody2D.velocity.y);	
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


	void Flip(float touchMoveX)
	{
		if(touchMoveX<0 && faceingRight)
		{
			transform.localRotation = Quaternion.Euler(0,180,0);
			faceingRight = false;
		}
		else if(touchMoveX>0 && !faceingRight)
		{
			transform.localRotation = Quaternion.Euler(0,0,0);
			faceingRight = true;
		}
	}
}


