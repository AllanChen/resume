using UnityEngine;
using System.Collections;

public class WalkScript : MonoBehaviour {
	public GameObject character;
	public float characterSpeed;
	bool faceingRight;
	Animator anim;
	void Start () {
		characterSpeed = 3.0f;
		anim = GetComponent<Animator>();
		faceingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis("Horizontal");

		if(move<0)
		{
			if(faceingRight)
			{
				character.transform.localRotation = Quaternion.Euler(0, 180, 0);
			}
			faceingRight = false;
		}
		else if(move >0)
		{
			if(!faceingRight)
			{
				character.transform.localRotation = Quaternion.Euler(0, 0, 0);
			}
			faceingRight = true;
		}
		anim.SetFloat("Speed",Mathf.Abs(move));
		rigidbody2D.velocity = new Vector2(move*characterSpeed,rigidbody2D.velocity.y);

	}
	
	
}
