using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal.Input;

public class Player : MonoBehaviour{
	public float speed = 8f;
	public float maxVelocity = 4f;

	public Rigidbody2D myBody;
	public Animator anim;

	
	private void Awake(){
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	private void FixedUpdate(){
		PlayerMovementKeyboard();
	}

	

	void PlayerMovementKeyboard(){
		float forceX = 0f;
		float vel = Mathf.Abs(myBody.velocity.x);
		float h = Input.GetAxis("Horizontal");

		if (h > 0){
			if (vel < maxVelocity){
				forceX = speed;
			}
			anim.SetBool("walk", true);
			
			Vector3 temp = myBody.transform.localScale;
			temp.x = 1.3f;
			myBody.transform.localScale = temp;
			
		}else if (h < 0){
			if (vel < maxVelocity){
				forceX = -speed;
			}
			Vector3 temp = myBody.transform.localScale;
			temp.x = -1.3f;
			myBody.transform.localScale = temp;
			anim.SetBool("walk", true);
		} else{
			anim.SetBool("walk", false);
		}
//		myBody.AddForce(Vector2.one*forceX);
		myBody.velocity = new Vector2(forceX, 0);
	}
}
